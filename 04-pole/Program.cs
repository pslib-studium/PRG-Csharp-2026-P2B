/*
 * POLE (ARRAY)
 *
 * Pole je datová struktura, která uchovává více hodnot STEJNÉHO datového typu.
 * - Velikost pole se určuje při jeho vytvoření a poté ji nelze změnit.
 * - K prvkům přistupujeme pomocí indexu v hranatých závorkách [ ].
 * - První prvek má index 0, poslední má index Length - 1.
 *
 * datovýTyp[] název = new datovýTyp[velikost];
 */


// -------------------------------------------------------------------------
// 0. Opakování: celočíselné a desetinné dělení
// -------------------------------------------------------------------------

int modulo = 10 % 3;     // zbytek po dělení -> 1
int deleni = 10 / 3;     // dělení dvou int -> 3 (desetinná část se zahodí)
double deset = 10.0 / 3; // alespoň jeden double -> 3.333...

Console.WriteLine($"10 % 3 = {modulo}, 10 / 3 = {deleni}, 10.0 / 3 = {deset}");
Console.WriteLine("----------------");

// -------------------------------------------------------------------------
// 1. Vytvoření pole a přístup k prvkům
// -------------------------------------------------------------------------

// Pole pro 10 celých čísel. Všechny prvky mají výchozí hodnotu 0.
int[] ints = new int[10];

// Pole pro 2 texty. Výchozí hodnota prvků je null.
string[] strings = new string[2];
strings[0] = "Ahoj";
strings[1] = "světe";
Console.WriteLine(strings[0] + " " + strings[1]);

// Zápis hodnot do pole pomocí indexu
ints[0] = 5;
ints[1] = 6;
ints[2] = 7;

// Hodnotu prvku můžeme přepsat
ints[0] = 1;

// Čtení hodnot z pole: 1 + 6 = 7
Console.WriteLine("ints[0] + ints[1] = " + (ints[0] + ints[1]));

// ints[10] = 3; // CHYBA! Index 10 neexistuje (IndexOutOfRangeException)

// -------------------------------------------------------------------------
// 2. Inicializace pole hodnotami
// -------------------------------------------------------------------------

// Velikost pole se určí automaticky podle počtu hodnot (zde 9)
int[] ints2 = { 5, 8, 4, 98, 5, 21, 398, 477, 4 };

// Vlastnost Length vrací počet prvků pole
Console.WriteLine("Velikost pole: " + ints2.Length);
Console.WriteLine("Poslední prvek: " + ints2[ints2.Length - 1]);

// -------------------------------------------------------------------------
// 3. Procházení pole cyklem
// -------------------------------------------------------------------------

// foreach: projde postupně všechny prvky (prvek in kolekce)
// Index zde nemáme k dispozici a prvky nelze měnit.
Console.WriteLine("Všechny prvky pole ints:");
foreach (int prvek in ints)
{
    Console.WriteLine(prvek);
}

// for: máme k dispozici index, můžeme tedy např. přeskakovat prvky
Console.WriteLine("Každý druhý prvek pole ints2:");
for (int i = 0; i < ints2.Length; i = i + 2)
{
    Console.WriteLine(ints2[i]);
}

Console.WriteLine("----------------");

// -------------------------------------------------------------------------
// 4. Dvourozměrné (obdélníkové) pole
// -------------------------------------------------------------------------

// Pole 2 x 2 – představme si ho jako tabulku s řádky a sloupci
int[,] pole2d = { { 5, 4 }, { 5, 8 } };

// Prvek zadáváme indexem řádku a sloupce
Console.WriteLine("pole2d[1, 0] = " + pole2d[1, 0]); // 5

// Rank vrací počet rozměrů pole (zde 2)
Console.WriteLine("Počet rozměrů: " + pole2d.Rank);

// GetLength(n) vrací velikost n-tého rozměru
for (int radek = 0; radek < pole2d.GetLength(0); radek++)
{
    for (int sloupec = 0; sloupec < pole2d.GetLength(1); sloupec++)
    {
        Console.Write(pole2d[radek, sloupec] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("----------------");

// -------------------------------------------------------------------------
// 5. Zubaté pole (pole polí)
// -------------------------------------------------------------------------

// Pole obsahující 3 další pole. Každé vnitřní pole může mít jinou délku.
int[][] zubatePole = new int[3][];
zubatePole[0] = [4, 5, 8, 1];          // zkrácený zápis (collection expression)
zubatePole[1] = new int[] { 4, 1 };    // klasický zápis
zubatePole[2] = [1, 5, 1];

// Vnější cyklus prochází řádky (vnitřní pole), vnitřní cyklus jejich prvky
foreach (int[] pole in zubatePole)
{
    Console.Write("[ ");
    foreach (int i in pole)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine("]");
}

Console.WriteLine("----------------");

// -------------------------------------------------------------------------
// 6. Hodnotový vs. referenční typ
// -------------------------------------------------------------------------

// int je HODNOTOVÝ typ – při přiřazení se zkopíruje hodnota
int n = 10;
int m = n;   // m dostane kopii hodnoty 10
m = 999;     // změní se jen m
Console.WriteLine("n: " + n); // 10
Console.WriteLine("m: " + m); // 999

// Pole je REFERENČNÍ typ – proměnná obsahuje odkaz na pole v paměti
int[] a = { 5, 4, 1 };
int[] b = a; // b odkazuje na STEJNÉ pole jako a (nevzniká kopie!)

b[0] = 999;  // změna přes b je vidět i přes a

Console.WriteLine("Pole A:");
foreach (int i in a)
{
    Console.Write(i + " "); // 999 4 1
}
Console.WriteLine();

Console.WriteLine("Pole B:");
foreach (int i in b)
{
    Console.Write(i + " "); // 999 4 1
}
Console.WriteLine();

// Pokud chceme skutečnou kopii pole, musíme ji vytvořit
int[] kopie = (int[])a.Clone();
kopie[0] = 1;
Console.WriteLine("a[0] = " + a[0] + ", kopie[0] = " + kopie[0]); // 999, 1

// -------------------------------------------------------------------------
// VYSVĚTLIVKY K POUŽITÝM KONSTRUKCÍM
// -------------------------------------------------------------------------
/*
- int[]: jednorozměrné pole celých čísel.
- new int[10]: vytvoří pole o 10 prvcích s výchozími hodnotami (0).
- Length: počet prvků pole.
- index: pozice prvku, začíná od 0.
- int[,]: dvourozměrné (obdélníkové) pole, GetLength(n) vrací velikost rozměru.
- int[][]: zubaté pole – pole polí s různou délkou.
- referenční typ: přiřazení zkopíruje jen odkaz, ne samotná data.
- Clone(): vytvoří kopii pole.
*/
