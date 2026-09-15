// =========================================================
// Základy programování v C#
// =========================================================
// Program postupně ukazuje základní konstrukce jazyka C#.
// Jednotlivé části jsou oddělené, aby bylo možné je studovat samostatně.

// ---------------------------------------------------------
// 1. Proměnné, datové typy a konstanta
// ---------------------------------------------------------

int a;      // deklarace proměnné
a = 10;     // první přiřazení hodnoty
a = 20;     // nové přiřazení přepíše původní hodnotu
int b = 30; // deklarace a přiřazení v jednom kroku

int vek = 16;                       // celé číslo
double prumer = 1.75;               // desetinné číslo
char skupina = 'A';                 // jeden znak se zapisuje do apostrofů
bool jeStudent = true;              // logická hodnota true nebo false
bool jePlnolety = vek >= 18;         // výsledkem porovnání je true nebo false
string predmet = "Programování";   // textový řetězec se zapisuje do uvozovek
const string Skola = "SPŠSE a VOŠ Liberec"; // hodnotu konstanty nelze změnit

Console.WriteLine("=== Proměnné a datové typy ===");
Console.WriteLine("a: " + a + ", b: " + b);
Console.WriteLine("Předmět: " + predmet);
Console.WriteLine("Věk: " + vek + ", průměr: " + prumer + ", skupina: " + skupina);
Console.WriteLine("Je student: " + jeStudent);
Console.WriteLine("Je plnoletý: " + jePlnolety);
Console.WriteLine("Škola: " + Skola);

// ---------------------------------------------------------
// 2. Vstup a výstup z konzole
// ---------------------------------------------------------

Console.WriteLine("\n=== Vstup a výstup ===");
Console.Write("Jak se jmenuješ? ");
var jmeno = Console.ReadLine();
Console.WriteLine("Ahoj, " + jmeno + "!");

if (jmeno == "Karel")
{
    Console.WriteLine("Ahoj Karle!");
}
else if (jmeno == "Alena")
{
    Console.WriteLine("Ahoj Aleno!");
}
else
{
    Console.WriteLine("Tvoje jméno zatím neznám");
}

// ---------------------------------------------------------
// 3. Převod textu na číslo pomocí Parse a TryParse
// ---------------------------------------------------------

// Parse použijeme, když víme, že text opravdu obsahuje číslo.
string textCisla = "100";
int cisloZParse = int.Parse(textCisla);
Console.WriteLine("Výsledek Parse: " + cisloZParse);

// Samostatná ukázka TryParse
string ukazkovyText = "123";
if (int.TryParse(ukazkovyText, out int ukazkoveCislo))
{
    // out určuje proměnnou, do které TryParse uloží převedené číslo
    Console.WriteLine("Ukázka TryParse: " + ukazkoveCislo);
}

// TryParse použijeme, když si nejsme jistí, co uživatel zadá.
Console.Write("Zadej celé číslo: ");
var vstup = Console.ReadLine();

// TryParse vrátí true při úspěchu a převedené číslo uloží do zadaneCislo.
if (int.TryParse(vstup, out int zadaneCislo))
{
    Console.WriteLine("Konverze se zdařila, zadané číslo je " + zadaneCislo);
    Console.WriteLine("Dvojnásobek je " + zadaneCislo * 2);

    if (zadaneCislo >= 0 && zadaneCislo < 10)
    {
        Console.WriteLine("Číslo je nezáporné a menší než 10");
    }
    else if (zadaneCislo >= 10)
    {
        Console.WriteLine("Číslo je větší nebo rovno 10");
    }
    else
    {
        Console.WriteLine("Číslo je záporné");
    }

    // -----------------------------------------------------
    // 4. Větvení pomocí switch
    // -----------------------------------------------------

    switch (zadaneCislo)
    {
        case 0:
            Console.WriteLine("Pomocí switch: nula");
            break;
        case 10:
            Console.WriteLine("Pomocí switch: deset");
            break;
        case 3:
        case 4:
        case 5:
            Console.WriteLine("Pomocí switch: číslo 3, 4 nebo 5");
            break;
        default:
            Console.WriteLine("Pomocí switch: jiné číslo");
            break;
    }
}
else
{
    Console.WriteLine("Konverze se nezdařila, nebylo zadáno celé číslo");
}

// ---------------------------------------------------------
// 5. Cykly
// ---------------------------------------------------------

Console.WriteLine("\n=== Cyklus for: lichá čísla od 1 do 9 ===");
for (int i = 1; i <= 10; i = i + 2)
{
    Console.WriteLine(i);
}

Console.WriteLine("\n=== Cyklus while: odpočet ===");
int odpocet = 3;
while (odpocet > 0)
{
    Console.WriteLine(odpocet);
    odpocet = odpocet - 1;
}

Console.WriteLine("\n=== Cyklus do-while ===");
int pocetPruchodu = 0;
do
{
    Console.WriteLine("Tento příkaz se provede alespoň jednou");
    pocetPruchodu = pocetPruchodu + 1;
} while (pocetPruchodu < 1);

// ---------------------------------------------------------
// 6. Pole a cyklus foreach
// ---------------------------------------------------------

string[] ovoce = { "jablko", "hruška", "banán" };

Console.WriteLine("\n=== Pole pomocí indexů ===");
for (int i = 0; i < ovoce.Length; i++)
{
    Console.WriteLine("ovoce[" + i + "] = " + ovoce[i]);
}

Console.WriteLine("\n=== Pole pomocí foreach ===");
foreach (string polozka in ovoce)
{
    Console.WriteLine(polozka);
}

// ---------------------------------------------------------
// 7. Příkazy continue a break
// ---------------------------------------------------------

Console.WriteLine("\n=== Cyklus s continue a break ===");
for (int i = 0; i < 10; i++)
{
    if (i == 2)
    {
        continue; // přeskočí zbytek aktuálního průchodu
    }

    Console.WriteLine(i);

    if (i == 5)
    {
        break; // ukončí celý cyklus
    }
}

// ---------------------------------------------------------
// 8. Číselné typy, jejich rozsahy a konverze
// ---------------------------------------------------------

byte maleCislo = 255;

// Převod z menšího typu na větší je implicitní.
int celeCislo = maleCislo;

// Převod z většího typu na menší musí být explicitní.
// Pokud se hodnota do cílového typu nevejde, může dojít ke ztrátě dat.
long velkeCislo = 100;
int prevedeneCislo = (int)velkeCislo;

// Při převodu double na int se odstraní desetinná část.
double desetinneCislo = 10.5;
int celaCast = (int)desetinneCislo;

Console.WriteLine("\n=== Číselné typy a konverze ===");
Console.WriteLine("byte: " + maleCislo);
Console.WriteLine("Implicitní převod byte -> int: " + celeCislo);
Console.WriteLine("Explicitní převod long -> int: " + prevedeneCislo);
Console.WriteLine("Explicitní převod double -> int: " + celaCast);
Console.WriteLine("Rozsah int: " + int.MinValue + " až " + int.MaxValue);
Console.WriteLine("Rozsah uint: " + uint.MinValue + " až " + uint.MaxValue);
