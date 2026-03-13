### Projektfeladat
## Tematikus adatkezelő alkalmazás és többoldalas HTML katalógus generálása
# Munkaforma
    2 fős csapatmunka, otthoni projekt
# Verziókezelés
A projekt teljes fejlesztése GitHub repository-ban történik.
### A feladat célja
A projekt célja, hogy a diákok egy olyan rendszert készítsenek, amely:
    • C# konzolos alkalmazásként adatokat kezel objektumorientált módon
    • a kezelt adatokból automatikusan generál egy többoldalas HTML weboldalt
    • a weboldal HTML/CSS sablonra épül, amelyet a csapat saját maga készít
    • a weboldal stílusos és reszponzív bemutató felületként szolgál
### Projekt témája
A csapat válasszon egy tematikus gyűjteményt, amelynek elemeit a program kezelni tudja.
Példák:
    • videojáték gyűjtemény
    • filmadatbázis
    • könyvajánló
    • receptgyűjtemény
    • túrahelyek
    • búvárhelyek
    • autók
    • sportolók
    • állatfajok
    • társasjátékok
    • zenei albumok
Más téma is választható, ha az adatmodell értelmesen kialakítható, viszont arra figyeljenek, 
hogy az osztályban nem készíthető több csapatban ugyanaz a téma.
### A rendszer működése
A projekt két fő részből áll.
## 1. C# konzolos alkalmazás
A program képes egy tematikus adatgyűjtemény kezelésére.
A programban az adatok objektumokként jelennek meg, és egy listában kerülnek tárolásra.
A felhasználó a konzolban menürendszeren keresztül tud műveleteket végezni.
A program képes az adatokból HTML oldalakat generálni.
A program képes az adatokat menteni és újra betölteni.
## 2. HTML/CSS sablon
A csapat készít egy HTML sablonrendszert, amelyet a C# program tölt fel adatokkal.
A sablon feladata:
    • a weboldal szerkezetének biztosítása
    • a vizuális megjelenítés kialakítása (modern, látványos)
    • reszponzív design megvalósítása (PC, Telefon)
A C# alkalmazás feladata:
    • az ismétlődő tartalmi blokkok generálása
    • a sablon kitöltése adatokkal
    • adatok tárolása
    • a végleges HTML fájlok létrehozása
### Kötelező C# funkciók
A programnak minimum az alábbi funkciókat kell biztosítania.
# Menü alapú működés
A program induláskor jelenítsen meg menüt, például:
1 - Elem hozzáadása
2 - Lista megjelenítése
3 - Keresés
4 - Szűrés kategória szerint
5 – CSV Mentés
6 – CSV Betöltés
7 - HTML export
0 - Kilépés
# Kötelező műveletek
A programnak támogatnia kell:
    • új elem hozzáadását
    • az elemek listázását
    • keresést név alapján
    • szűrést kategória alapján
    • rendezést legalább egy mező szerint
    • CSV export, import
    • HTML export generálását
### Adatmodell követelmények
A projektnek tartalmaznia kell legalább egy a témának fő adatosztályt.
Példa:
Item
Az osztálynak minimum az alábbi típusú mezőket kell tartalmaznia:
    • Id
    • Name (string)
    • Category (string)
    • Description (string)
    • két numerikus mező (pl. rating, difficulty, year)
    • egy logikai mező (pl. favorite, visited, completed)
# Példa struktúra
class Item
{
    int Id
    string Name
    string Category
    string Description
    int Rating
    int Diffiulty
    bool IsFavorite
}
### Kötelező OOP elemek
A projektnek tartalmaznia kell:
    • legalább 2 saját osztály
    • legalább 1 adatszerkezet osztályt (lista objektumok tárolására)
    • metódusok az üzleti logikához
    • konstruktor használatát
    • property-k használatát
### HTML generálás követelményei
A C# programnak több HTML oldalt kell generálnia.
Minimum 3 oldal (navigáció minden oldalon elérhető menü segítségével):
index.html
items.html
favorites.html
## 1. index.html
A weboldal főoldala.
Tartalmazza:
    • projekt címe
    • rövid leírás
    • statisztikai adatok (pl. elemek száma, kategóriák száma)
    • néhány kiemelt elem
## 2. items.html
Az összes elem listája.
Az elemek jelenjenek meg:
    • táblázatban
    • kategóriával
    • rövid leírással
    • egyéb adatokkal
## 3. favorites.html
A kedvenc elemek listája.
Csak azok az elemek jelenjenek meg kártyák formájában, ahol pl:
IsFavorite == true
### HTML sablon működése
A csapat készít egy template.html fájlt.
Ebben helyőrzők szerepelnek, például:
{{TITLE}}
{{DESCRIPTION}}
{{ITEMS}}
A C# program:
    1. beolvassa a template fájlt
    2. generálja az elemek HTML blokkjait
    3. behelyettesíti a helyőrzőket
    4. elmenti a végleges HTML fájlokat a megadott nevű mappába
### HTML/CSS követelmények
A generált weboldalnak esztétikusnak, modernek kell lennie.
# Kötelező HTML elemek
    • header
    • nav
    • main
    • section
    • footer
# Kötelező CSS elemek
A CSS-nek tartalmaznia kell:
    • külső stylesheet használatát
    • Flexbox és/vagy CSS Grid
    • reszponzív layout
    • hover effekteket
    • egységes színpalettát
    • olvasható tipográfiát
# Kötelező vizuális elemek
Az elemek jelenjenek meg:
    • táblázatban/kártyákban
    • kategória címkékkel
    • kedvenc elemek kiemeléssel
    • képek
### Projekt struktúra (javasolt)
project-root
├── template
│ ├── template.html
│ ├── style.css
│ ├── images
│ ├── index.html
│ ├── items.html
│ └── favorites.html
│ 
│
├── outputs
│ └── mappa1
│ ├── style.css
│ ├── images
│ ├── index.html
│ ├── items.html
│ └── favorites.html
│
└── README.md
### GitHub követelmények
A projektet GitHub repository-ban kell elkészíteni.
A repository tartalmazza:
    • teljes forráskódot
    • HTML sablont
    • CSS fájlokat
    • README dokumentációt
## Git használati elvárások
A csapat használja:
    • (branch-eket)
    • commit üzeneteket
    • rendszeres feltöltést
Minimum elvárás:
    • több commit
    • mindkét csapattag hozzájárulása látható
### Dokumentáció
A repository tartalmazzon egy README.md fájlt.
A README tartalmazza:
    • projekt címe
    • csapattagok neve
    • választott téma
    • adatmodell rövid leírása
    • a program funkciói
    • a generált oldalak rövid bemutatása
    • rövid képernyőképek