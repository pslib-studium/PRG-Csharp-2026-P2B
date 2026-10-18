# 04 – Pole v C#

Tento projekt obsahuje ukázky práce s poli v jazyce C#. Všechny příklady najdete v souboru [`Program.cs`](Program.cs).

[Zpět na přehled repozitáře](../README.md)

## 1. Co je pole

Pole uchovává více hodnot **stejného datového typu** pod jedním názvem. Velikost pole se určuje při vytvoření a později ji nelze změnit.

```csharp
int[] ints = new int[10];          // 10 celých čísel, všechna mají hodnotu 0
string[] strings = new string[2];  // 2 texty, výchozí hodnota je null
```

| Typ prvků | Výchozí hodnota |
|---|---|
| `int`, `double` | `0` |
| `bool` | `false` |
| `string` | `null` |

## 2. Přístup k prvkům

K prvkům přistupujeme pomocí **indexu** v hranatých závorkách. První prvek má index `0`, poslední `Length - 1`.

```csharp
ints[0] = 5;   // zápis
ints[0] = 1;   // přepsání hodnoty
Console.WriteLine(ints[0] + ints[1]); // čtení
```

Přístup mimo rozsah pole (např. `ints[10]` u pole o 10 prvcích) způsobí chybu `IndexOutOfRangeException`.

## 3. Inicializace hodnotami a `Length`

Pole můžeme rovnou naplnit hodnotami. Velikost se určí podle jejich počtu.

```csharp
int[] ints2 = { 5, 8, 4, 98, 5, 21, 398, 477, 4 };

Console.WriteLine(ints2.Length);               // 9
Console.WriteLine(ints2[ints2.Length - 1]);    // poslední prvek: 4
```

## 4. Procházení pole

### `foreach`

Projde postupně všechny prvky. Nemáme k dispozici index.

```csharp
foreach (int prvek in ints)
{
	Console.WriteLine(prvek);
}
```

### `for`

Pracuje s indexem, takže můžeme například vypsat každý druhý prvek.

```csharp
for (int i = 0; i < ints2.Length; i = i + 2)
{
	Console.WriteLine(ints2[i]);
}
```

## 5. Dvourozměrné pole

Obdélníkové pole si můžeme představit jako tabulku s řádky a sloupci.

```csharp
int[,] pole2d = { { 5, 4 }, { 5, 8 } };

Console.WriteLine(pole2d[1, 0]); // řádek 1, sloupec 0 -> 5
Console.WriteLine(pole2d.Rank);  // počet rozměrů -> 2
```

Velikost jednotlivých rozměrů zjistíme pomocí `GetLength()`:

```csharp
for (int radek = 0; radek < pole2d.GetLength(0); radek++)
{
	for (int sloupec = 0; sloupec < pole2d.GetLength(1); sloupec++)
	{
		Console.Write(pole2d[radek, sloupec] + " ");
	}
	Console.WriteLine();
}
```

## 6. Zubaté pole

Zubaté pole je **pole polí**. Každé vnitřní pole může mít jinou délku.

```csharp
int[][] zubatePole = new int[3][];
zubatePole[0] = [4, 5, 8, 1];        // zkrácený zápis
zubatePole[1] = new int[] { 4, 1 };  // klasický zápis
zubatePole[2] = [1, 5, 1];

foreach (int[] pole in zubatePole)
{
	foreach (int i in pole)
	{
		Console.Write(i + " ");
	}
	Console.WriteLine();
}
```

| Zápis | Druh pole | Délka řádků |
|---|---|---|
| `int[,]` | obdélníkové | všechny stejné |
| `int[][]` | zubaté | každý může být jiný |

## 7. Hodnotový a referenční typ

`int` je **hodnotový typ** – při přiřazení se zkopíruje hodnota.

```csharp
int n = 10;
int m = n;
m = 999;   // n zůstává 10
```

Pole je **referenční typ** – proměnná obsahuje jen odkaz na data v paměti. Po přiřazení obě proměnné ukazují na stejné pole.

```csharp
int[] a = { 5, 4, 1 };
int[] b = a;
b[0] = 999;  // změní se i a[0]
```

Skutečnou kopii pole vytvoříme například pomocí `Clone()`:

```csharp
int[] kopie = (int[])a.Clone();
kopie[0] = 1;  // a[0] se nezmění
```

## Spuštění projektu

Ve Visual Studiu otevřete řešení `PRG-2026.sln`, nastavte projekt `04-pole` jako spouštěný a použijte `F5` nebo `Ctrl+F5`.

Z příkazové řádky můžete projekt spustit takto:

```bash
dotnet run --project 04-pole/04-pole.csproj
```

## Shrnutí

- Pole uchovává více hodnot stejného typu a má pevnou velikost.
- Indexy začínají od `0`, poslední index je `Length - 1`.
- `foreach` prochází všechny prvky, `for` pracuje s indexem.
- `int[,]` je obdélníkové pole, `int[][]` je zubaté pole.
- Pole je referenční typ – přiřazení nevytváří kopii.
- Kopii pole vytvoříme pomocí `Clone()`.
