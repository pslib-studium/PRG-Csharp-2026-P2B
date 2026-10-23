/*
 * MANIPULACE S POLEM
 *
 * Třída Array nabízí hotové metody pro běžné operace s poli:
 * - Array.Reverse()  – otočí pořadí prvků
 * - Array.Clear()    – nastaví prvky na výchozí hodnotu (0, null, false)
 * - Array.Fill()     – vyplní pole zadanou hodnotou
 * - Array.Sort()     – seřadí prvky vzestupně
 * - Array.IndexOf()  – vrátí index hledaného prvku (nebo -1)
 * - Array.Resize()   – změní velikost pole (vytvoří nové pole)
 *
 * Pro pochopení si u některých operací ukážeme i vlastní implementaci.
 */

// Pole, se kterým budeme pracovat
int[] ints2 = { 5, 8, 4, 98, 5, 21, 398, 477, 4 };

// Pomocná funkce pro výpis pole ve tvaru [5, 8, 4]
void PrintArray(string popis, int[] arr)
{
    Console.WriteLine(popis + ": [" + string.Join(", ", arr) + "]");
}

PrintArray("Původní pole", ints2);

// -------------------------------------------------------------------------
// 1. Otočení pole
// -------------------------------------------------------------------------

Console.WriteLine("------------ OTOČENÍ pole -------------");

// Vlastní implementace: do nového pole zapisujeme prvky od konce.
int[] intsReverse = new int[ints2.Length];
for (int i = 0; i < ints2.Length; i++)
{
    intsReverse[i] = ints2[ints2.Length - i - 1];
}
PrintArray("Vlastní otočení (nové pole)", intsReverse);

// Hotová metoda: otočí přímo původní pole (nevytváří nové)
Array.Reverse(ints2);
PrintArray("Array.Reverse", ints2);

// -------------------------------------------------------------------------
// 2. Odkaz na pole vs. kopie pole
// -------------------------------------------------------------------------

Console.WriteLine("------------ KOPIE pole -------------");

// Pole je referenční typ – intsRef ukazuje na STEJNÉ pole jako ints2
int[] intsRef = ints2;
intsRef[0] = -1;
Console.WriteLine("ints2[0] po změně intsRef[0]: " + ints2[0]); // -1, změnilo se i ints2!

ints2[0] = 5; // vrátíme hodnotu zpět

// Clone() vytvoří NOVÉ pole se stejnými hodnotami
int[] ints1 = (int[])ints2.Clone();
ints1[0] = -999;
Console.WriteLine("ints2[0] po změně kopie ints1[0]: " + ints2[0]); // 5, originál zůstal

// -------------------------------------------------------------------------
// 3. Vymazání a vyplnění pole
// -------------------------------------------------------------------------

Console.WriteLine("------------ CLEAR a FILL -------------");

int[] pole = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };

// Array.Clear nastaví všechny prvky na výchozí hodnotu (u int je to 0)
Array.Clear(pole);
PrintArray("Array.Clear", pole); // 0, 0, 0, ...

// Array.Fill vyplní všechny prvky zadanou hodnotou
Array.Fill(pole, 5);
PrintArray("Array.Fill(pole, 5)", pole); // 5, 5, 5, ...

// -------------------------------------------------------------------------
// 4. Řazení pole
// -------------------------------------------------------------------------

Console.WriteLine("------------ ŘAZENÍ pole -------------");

// Array.Sort seřadí prvky vzestupně (od nejmenšího po největší)
Array.Sort(ints2);
PrintArray("Seřazené pole", ints2);

// Sestupné řazení: nejprve seřadíme, potom otočíme
int[] sestupne = (int[])ints2.Clone();
Array.Sort(sestupne);
Array.Reverse(sestupne);
PrintArray("Sestupně seřazené pole", sestupne);

// -------------------------------------------------------------------------
// 5. Vyhledávání v poli
// -------------------------------------------------------------------------

Console.WriteLine("------------ HLEDÁNÍ v poli -------------");

// Array.IndexOf vrátí index PRVNÍHO výskytu prvku
Console.WriteLine("Index prvku 5 v seřazeném poli: " + Array.IndexOf(ints2, 5)); // 1

// Contains vrátí true/false podle toho, zda pole prvek obsahuje
if (ints2.Contains(55))
{
    Console.WriteLine("Prvek 55 v poli je.");
}
else
{
    Console.WriteLine("Prvek 55 v poli není.");
    // Pokud prvek v poli není, IndexOf vrátí -1
    Console.WriteLine("Array.IndexOf(ints2, 55) vrátí: " + Array.IndexOf(ints2, 55)); // -1
}

// -------------------------------------------------------------------------
// 6. Změna velikosti pole
// -------------------------------------------------------------------------

Console.WriteLine("------------ ZMĚNA VELIKOSTI pole -------------");

// Velikost pole nelze změnit. Array.Resize proto vytvoří NOVÉ pole,
// zkopíruje do něj hodnoty a proměnnou přesměruje na nové pole (proto ref).
Array.Resize(ref ints2, ints2.Length + 2);
PrintArray("Array.Resize (+2 prvky)", ints2); // nové prvky mají hodnotu 0

/// <summary>
/// Vlastní implementace Resize: vytvoří nové pole a zkopíruje do něj staré hodnoty.
/// Pokud je nové pole menší, přebývající prvky se ztratí.
/// </summary>
void ResizeArray(ref int[] arr, int newSize)
{
    int[] result = new int[newSize];
    for (int i = 0; i < result.Length; i++)
    {
        if (i < arr.Length) result[i] = arr[i];
    }
    arr = result; // díky ref se změní i proměnná mimo funkci
}

ResizeArray(ref ints2, 3);
PrintArray("Vlastní ResizeArray (3 prvky)", ints2);

// -------------------------------------------------------------------------
// 7. Pole jako parametr funkce
// -------------------------------------------------------------------------

Console.WriteLine("------------ POLE JAKO PARAMETR -------------");

/// <summary>
/// Vytvoří NOVÉ pole, do kterého uloží prvky původního pole vynásobené hodnotou.
/// Původní pole zůstane beze změny.
/// </summary>
int[] MultiplyAndReturn(int[] arr, int value)
{
    int[] result = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        result[i] = arr[i] * value;
    }
    return result;
}

/// <summary>
/// Vynásobí všechny prvky existujícího pole hodnotou.
/// Pro změnu prvků ref není potřeba – stačí odkaz na pole.
/// ref by byl potřeba jen při přiřazení úplně nového pole (viz ResizeArray).
/// </summary>
void MultiplyExistingArray(int[] arr, int value)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] *= value;
    }
}

int[] cisla = { 1, 2, 3 };
int[] vysledek = MultiplyAndReturn(cisla, 2);
PrintArray("Vrácené pole", vysledek); // 2, 4, 6
PrintArray("Původní pole", cisla);    // 1, 2, 3 – zůstalo beze změny

MultiplyExistingArray(cisla, 10);
PrintArray("Po MultiplyExistingArray", cisla); // 10, 20, 30

// -------------------------------------------------------------------------
// VYSVĚTLIVKY K POUŽITÝM KONSTRUKCÍM
// -------------------------------------------------------------------------
/*
- Array.Reverse(pole): otočí pořadí prvků přímo v poli.
- Array.Clear(pole): nastaví prvky na výchozí hodnotu.
- Array.Fill(pole, hodnota): vyplní pole jednou hodnotou.
- Array.Sort(pole): seřadí pole vzestupně.
- Array.IndexOf(pole, prvek): index prvního výskytu, nebo -1.
- pole.Contains(prvek): true, pokud pole prvek obsahuje.
- Array.Resize(ref pole, velikost): vytvoří nové pole jiné velikosti.
- Clone(): vytvoří kopii pole.
- string.Join(", ", pole): spojí prvky pole do jednoho textu.
- Pole předané do funkce se dá měnit i bez ref, ref je nutné jen pro přiřazení nového pole.
*/
