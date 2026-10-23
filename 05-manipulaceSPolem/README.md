# 05 – Manipulace s polem v C#

Tento projekt obsahuje ukázky běžných operací s poli v jazyce C#. Všechny příklady najdete v souboru [`Program.cs`](Program.cs).

[Zpět na přehled repozitáře](../README.md)

## 1. Třída `Array`

Pro běžné operace s poli nemusíme psát vlastní kód. Třída `Array` nabízí hotové metody.

| Metoda | Co dělá |
|---|---|
| `Array.Reverse(pole)` | otočí pořadí prvků |
| `Array.Clear(pole)` | nastaví prvky na výchozí hodnotu |
| `Array.Fill(pole, hodnota)` | vyplní pole zadanou hodnotou |
| `Array.Sort(pole)` | seřadí prvky vzestupně |
| `Array.IndexOf(pole, prvek)` | vrátí index prvku, nebo `-1` |
| `Array.Resize(ref pole, velikost)` | změní velikost pole |

Pro přehledný výpis pole používáme `string.Join()`:

```csharp
Console.WriteLine("[" + string.Join(", ", ints2) + "]"); // [5, 8, 4, ...]
```

## 2. Otočení pole

Vlastní implementace zapisuje prvky do nového pole od konce. Prvek na indexu `i` bereme z indexu `Length - 1 - i`.

```csharp
int[] intsReverse = new int[ints2.Length];
for (int i = 0; i < ints2.Length; i++)
{
    intsReverse[i] = ints2[ints2.Length - i - 1];
}
```

Hotová metoda otočí přímo původní pole:

```csharp
Array.Reverse(ints2);
```

## 3. Odkaz na pole a kopie pole

Pole je **referenční typ**. Přiřazením nevznikne kopie, obě proměnné ukazují na stejné pole.

```csharp
int[] intsRef = ints2;
intsRef[0] = -1;   // změní se i ints2[0]
```

Skutečnou kopii vytvoříme pomocí `Clone()`:

```csharp
int[] ints1 = (int[])ints2.Clone();
ints1[0] = -999;   // ints2 se nezmění
```

## 4. Vymazání a vyplnění pole

```csharp
int[] pole = { 1, 2, 4, 8, 2, 9, 6, 11, 3 };

Array.Clear(pole);    // 0, 0, 0, ...
Array.Fill(pole, 5);  // 5, 5, 5, ...
```

`Array.Clear()` nastaví prvky na výchozí hodnotu datového typu (`0` u `int`, `null` u `string`, `false` u `bool`).

## 5. Řazení pole

`Array.Sort()` seřadí pole vzestupně, tedy od nejmenšího prvku po největší.

```csharp
Array.Sort(ints2);    // [4, 5, 5, 8, 21, 98, 398, 477]
```

Sestupné pořadí získáme tak, že pole nejdříve seřadíme a potom otočíme:

```csharp
Array.Sort(pole);
Array.Reverse(pole);
```

## 6. Vyhledávání v poli

```csharp
int index = Array.IndexOf(ints2, 5);  // index prvního výskytu
bool je = ints2.Contains(55);         // true / false
```

- `Array.IndexOf()` vrátí index **prvního** výskytu prvku.
- Pokud prvek v poli není, vrátí `-1`.
- `Contains()` pouze zjistí, zda pole prvek obsahuje.

## 7. Změna velikosti pole

Velikost pole nelze změnit. `Array.Resize()` proto vytvoří **nové pole**, zkopíruje do něj hodnoty a proměnnou přesměruje na nové pole. Proto se používá `ref`.

```csharp
Array.Resize(ref ints2, ints2.Length + 2); // nové prvky mají hodnotu 0
```

Vlastní implementace funguje stejně:

```csharp
void ResizeArray(ref int[] arr, int newSize)
{
    int[] result = new int[newSize];
    for (int i = 0; i < result.Length; i++)
    {
        if (i < arr.Length) result[i] = arr[i];
    }
    arr = result;
}
```

Pokud je nové pole menší, přebývající prvky se ztratí.

## 8. Pole jako parametr funkce

Do funkce se předává **odkaz** na pole. Funkce proto může měnit prvky původního pole i bez `ref`.

```csharp
void MultiplyExistingArray(int[] arr, int value)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] *= value;
    }
}

int[] cisla = { 1, 2, 3 };
MultiplyExistingArray(cisla, 10); // cisla: 10, 20, 30
```

| Situace | Je potřeba `ref`? |
|---|---|
| změna prvků pole (`arr[i] = ...`) | ne |
| přiřazení nového pole (`arr = new int[5]`) | ano |

Pokud nechceme původní pole měnit, vytvoří funkce **nové** pole a vrátí ho:

```csharp
int[] MultiplyAndReturn(int[] arr, int value)
{
    int[] result = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        result[i] = arr[i] * value;
    }
    return result;
}

int[] cisla = { 1, 2, 3 };
int[] vysledek = MultiplyAndReturn(cisla, 2); // vysledek: 2, 4, 6
                                              // cisla: 1, 2, 3 (beze změny)
```

## Spuštění projektu

Ve Visual Studiu otevřete řešení `PRG-2026.sln`, nastavte projekt `05-manipulaceSPolem` jako spouštěný a použijte `F5` nebo `Ctrl+F5`.

Z příkazové řádky můžete projekt spustit takto:

```bash
dotnet run --project 05-manipulaceSPolem/05-manipulaceSPolem.csproj
```

## Shrnutí

- Třída `Array` obsahuje hotové metody pro práci s poli.
- `Reverse`, `Sort`, `Clear` a `Fill` mění přímo původní pole.
- `IndexOf` vrací `-1`, pokud prvek nenajde.
- Přiřazení pole nevytváří kopii, kopii vytvoří `Clone()`.
- `Resize` vytváří nové pole, proto potřebuje `ref`.
- Funkce může měnit prvky předaného pole i bez `ref`.
- Pokud má původní pole zůstat beze změny, funkce vytvoří a vrátí nové pole.
