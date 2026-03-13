using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace MusicAlbumCatalog
{
    class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public bool IsFavorite { get; set; }
        public Album(int id, string name, string artist, string category, string description, int year, int rating, bool favorite)
        {
            Id = id;
            Name = name;
            Artist = artist;
            Category = category;
            Description = description;
            Year = year;
            Rating = rating;
            IsFavorite = favorite;
        }
    }
    class AlbumManager
    {
        public List<Album> Albums = new List<Album>();
        public void AddAlbum()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Album name: ");
            string name = Console.ReadLine();
            Console.Write("Artist: ");
            string artist = Console.ReadLine();
            Console.Write("Genre: ");
            string category = Console.ReadLine();
            Console.Write("Description: ");
            string description = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Rating (1-10): ");
            int rating = int.Parse(Console.ReadLine());
            Console.Write("Favorite (true/false): ");
            bool fav = bool.Parse(Console.ReadLine());
            Album album = new Album(id, name, artist, category, description, year, rating, fav);
            Albums.Add(album);
            Console.WriteLine("Album added.");
        }
        public void ListAlbums()
        {
            foreach (var album in Albums)
            {
                Console.WriteLine($"{album.Id} | {album.Name} | {album.Artist} | {album.Category} | {album.Year} | Rating:{album.Rating}");
            }
        }
        public void Search()
        {
            Console.Write("Search name: ");
            string name = Console.ReadLine().ToLower();
            var results = Albums.Where(a => a.Name.ToLower().Contains(name));
            foreach (var album in results)
            {
                Console.WriteLine($"{album.Name} - {album.Artist}");
            }
        }
        public void FilterCategory()
        {
            Console.Write("Genre: ");
            string category = Console.ReadLine();
            var results = Albums.Where(a => a.Category == category);
            foreach (var album in results)
            {
                Console.WriteLine($"{album.Name} - {album.Artist}");
            }
        }
        public void SortByYear()
        {
            Albums = Albums.OrderBy(a => a.Year).ToList();
            Console.WriteLine("Sorted by year.");
        }
        public void SaveCSV()
        {
            Directory.CreateDirectory("data");
            using (StreamWriter sw = new StreamWriter("data/albums.csv"))
            {
                foreach (var a in Albums)
                {
                    sw.WriteLine($"{a.Id},{a.Name},{a.Artist},{a.Category},{a.Description},{a.Year},{a.Rating},{a.IsFavorite}");
                }
            }
            Console.WriteLine("CSV saved.");
        }
        public void LoadCSV()
        {
            if (!File.Exists("data/albums.csv"))
            {
                Console.WriteLine("CSV not found.");
                return;
            }
            var lines = File.ReadAllLines("data/albums.csv");
            Albums.Clear();
            foreach (var line in lines)
            {
                var d = line.Split(",");
                Album a = new Album(
                    int.Parse(d[0]),
                    d[1],
                    d[2],
                    d[3],
                    d[4],
                    int.Parse(d[5]),
                    int.Parse(d[6]),
                    bool.Parse(d[7])
                );
                Albums.Add(a);
            }
            Console.WriteLine("CSV loaded.");
        }
        public void GenerateHTML()
        {
            Directory.CreateDirectory("output");
            GenerateItems();
            GenerateFavorites();
            GenerateIndex();
            Console.WriteLine("HTML pages generated in /output folder.");
        }
        void GenerateItems()
        {
            string rows = "";
            foreach (var a in Albums)
            {
                rows += $@"
<tr>
<td>{a.Name}</td>
<td>{a.Artist}</td>
<td>{a.Category}</td>
<td>{a.Year}</td>
<td>{a.Rating}</td>
</tr>";
            }
            string html = $@"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<title>Albums</title>
<link rel='stylesheet' href='style.css'>
</head>
<body>
<header>
<h1>Music Albums</h1>
</header>
<nav>
<a href='index.html'>Home</a>
<a href='items.html'>Albums</a>
<a href='favorites.html'>Favorites</a>
</nav>
<main>
<table>
<tr>
<th>Name</th>
<th>Artist</th>
<th>Genre</th>
<th>Year</th>
<th>Rating</th>
</tr>
{rows}
</table>
</main>
</body>
</html>";
            File.WriteAllText("output/items.html", html);
        }
        void GenerateFavorites()
        {
            string cards = "";
            foreach (var a in Albums.Where(a => a.IsFavorite))
            {
                cards += $@"
<div class='card'>
<h2>{a.Name}</h2>
<p>{a.Artist}</p>
<p>{a.Category}</p>
<p>Rating: {a.Rating}</p>
</div>";
            }
            string html = $@"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<title>Favorites</title>
<link rel='stylesheet' href='style.css'>
</head>
<body>
<header>
<h1>Favorite Albums</h1>
</header>
<nav>
<a href='index.html'>Home</a>
<a href='items.html'>Albums</a>
<a href='favorites.html'>Favorites</a>
</nav>
<main>
{cards}
</main>
</body>
</html>";
            File.WriteAllText("output/favorites.html", html);
        }
        void GenerateIndex()
        {
            int count = Albums.Count;
            int genres = Albums.Select(a => a.Category).Distinct().Count();
            int fav = Albums.Count(a => a.IsFavorite);
            string html = $@"
<!DOCTYPE html>
<html>
<head>
<meta charset='UTF-8'>
<title>Music Catalog</title>
<link rel='stylesheet' href='style.css'>
</head>
<body>
<header>
<h1>Music Album Catalog</h1>
</header>
<nav>
<a href='index.html'>Home</a>
<a href='items.html'>Albums</a>
<a href='favorites.html'>Favorites</a>
</nav>
<main>
<h2>Statistics</h2>
<p>Total albums: {count}</p>
<p>Genres: {genres}</p>
<p>Favorites: {fav}</p>
</main>
</body>
</html>";
            File.WriteAllText("output/index.html", html);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AlbumManager manager = new AlbumManager();
            while (true)
            {
                Console.WriteLine("\n--- Music Album Catalog ---");
                Console.WriteLine("1 - Add album");
                Console.WriteLine("2 - List albums");
                Console.WriteLine("3 - Search");
                Console.WriteLine("4 - Filter by genre");
                Console.WriteLine("5 - Sort by year");
                Console.WriteLine("6 - Save CSV");
                Console.WriteLine("7 - Load CSV");
                Console.WriteLine("8 - Generate HTML");
                Console.WriteLine("0 - Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        manager.AddAlbum();
                        break;
                    case "2":
                        manager.ListAlbums();
                        break;
                    case "3":
                        manager.Search();
                        break;
                    case "4":
                        manager.FilterCategory();
                        break;
                    case "5":
                        manager.SortByYear();
                        break;
                    case "6":
                        manager.SaveCSV();
                        break;
                    case "7":
                        manager.LoadCSV();
                        break;
                    case "8":
                        manager.GenerateHTML();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}