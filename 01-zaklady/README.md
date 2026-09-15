# 01 – Základy programování v C#

Tento projekt obsahuje ukázky základních konstrukcí jazyka C#. Všechny příklady najdete v souboru [`Program.cs`](Program.cs).

[Zpět na přehled repozitáře](../README.md)

## 1. Proměnné a datové typy

Proměnná slouží k uložení hodnoty. Při jejím vytvoření určujeme datový typ, název a hodnotu.

```csharp
int vek = 16;
double prumer = 1.75;
char skupina = 'A';
bool jeStudent = true;
string predmet = "Programování";
```

| Typ | Ukládá | Příklad |
|---|---|---|
| `int` | celé číslo | `10` |
| `double` | desetinné číslo | `10.5` |
| `char` | jeden znak | `'A'` |
| `bool` | pravdu nebo nepravdu | `true` |
| `string` | text | `"Ahoj"` |

C# je typový jazyk. Proměnnou můžeme nejdříve vytvořit a hodnotu jí přiřadit později. Nové přiřazení původní hodnotu přepíše.

```csharp
int cislo;      // deklarace proměnné
cislo = 10;     // první přiřazení
cislo = 20;     // nové přiřazení
int druhe = 30; // deklarace a přiřazení v jednom kroku
```

Do proměnné typu `int` nelze uložit text: `cislo = "Ahoj";` by způsobilo chybu.

Hodnotu konstanty po vytvoření nelze změnit:

```csharp
const string Skola = "SPŠSE a VOŠ Liberec";
```

## 2. Výstup a vstup z konzole

Pro práci s konzolí používáme třídu `Console`.

```csharp
Console.WriteLine("Napiš nějaký text:");
var text = Console.ReadLine();
Console.WriteLine("Napsal jsi: " + text);
```

- `Console.Write()` vypíše text a zůstane na stejném řádku.
- `Console.WriteLine()` vypíše text a přejde na nový řádek.
- `Console.ReadLine()` načte řádek napsaný uživatelem.

## 3. Převod textu na číslo

Vstup z konzole je text. Na číslo jej můžeme převést pomocí `Parse()` nebo `TryParse()`.

### `Parse()`

`Parse()` použijeme, když víme, že text obsahuje platné číslo.

```csharp
string text = "100";
int cislo = int.Parse(text);
Console.WriteLine(cislo); // vypíše 100
```

Pokud text číslo neobsahuje, `Parse()` ukončí program chybou.

### `TryParse()`

U vstupu od uživatele nevíme, co bude zadáno. Proto je bezpečnější použít `TryParse()`.

```csharp
var vstup = Console.ReadLine();

if (int.TryParse(vstup, out int cislo))
{
    Console.WriteLine("Zadané číslo je " + cislo);
}
else
{
    Console.WriteLine("Konverze se nezdařila");
}
```

Při úspěšném převodu metoda vrátí `true` a číslo uloží do proměnné `cislo`. Při neúspěchu vrátí `false` a program může pokračovat.

## 4. Podmínky `if-else`

Podmínky používáme, když se má program rozhodnout podle hodnoty výrazu.

```csharp
if (cislo >= 0 && cislo < 10)
{
    Console.WriteLine("Číslo je nezáporné a menší než 10");
}
else if (cislo >= 10)
{
    Console.WriteLine("Číslo je větší nebo rovno 10");
}
else
{
    Console.WriteLine("Číslo je záporné");
}
```

Podmínky mohou porovnávat také text:

```csharp
if (jmeno == "Karel")
{
    Console.WriteLine("Ahoj Karle!");
}
```

Základní operátory:

| Operátor | Význam |
|---|---|
| `==` | rovná se |
| `!=` | nerovná se |
| `<`, `>` | menší než, větší než |
| `<=`, `>=` | menší nebo rovno, větší nebo rovno |
| `&&` | obě podmínky musí platit |
| `\|\|` | musí platit alespoň jedna podmínka |

## 5. Příkaz `switch`

`switch` porovnává jednu hodnotu s několika možnostmi.

```csharp
switch (cislo)
{
    case 0:
        Console.WriteLine("nula");
        break;
    case 10:
        Console.WriteLine("deset");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("číslo 3, 4 nebo 5");
        break;
    default:
        Console.WriteLine("něco jiného");
        break;
}
```

`default` se provede, pokud neodpovídá žádná z uvedených hodnot.

## 6. Cykly

Cyklus opakuje stejný blok příkazů.

### `for`

Používáme jej, když známe počet opakování.

```csharp
for (int i = 1; i <= 10; i = i + 2)
{
    Console.WriteLine(i);
}
```

### `while`

Opakuje se, dokud platí podmínka.

```csharp
int cislo = 3;
while (cislo > 0)
{
    Console.WriteLine(cislo);
    cislo = cislo - 1;
}
```

### `do-while`

Nejdříve provede příkazy a až potom kontroluje podmínku. Proto se provede vždy alespoň jednou.

```csharp
do
{
    Console.WriteLine("Provede se alespoň jednou");
} while (cislo > 0);
```

## 7. Pole a `foreach`

Pole uchovává více hodnot stejného typu.

```csharp
string[] ovoce = { "jablko", "hruška", "banán" };
```

Prvky pole můžeme projít pomocí indexu. První prvek má index `0` a `Length` vrací počet prvků.

```csharp
for (int i = 0; i < ovoce.Length; i++)
{
    Console.WriteLine(ovoce[i]);
}
```

Pokud index nepotřebujeme, použijeme `foreach`:

```csharp
foreach (string polozka in ovoce)
{
    Console.WriteLine(polozka);
}
```

### `continue` a `break`

- `continue` přeskočí aktuální průchod cyklu.
- `break` ukončí celý cyklus.

## 8. Převody číselných typů

Převod z menšího typu na větší proběhne automaticky:

```csharp
byte maleCislo = 255;
int celeCislo = maleCislo;
```

Převod z většího typu na menší musíme zapsat do závorek:

```csharp
long velkeCislo = 100;
int prevedeneCislo = (int)velkeCislo;

double desetinneCislo = 10.5;
int celaCast = (int)desetinneCislo; // výsledkem je 10
```

Při takovém převodu může dojít ke ztrátě části hodnoty.

## Spuštění projektu

Ve Visual Studiu otevřete řešení `PRG-2026.sln`, nastavte projekt `01-zaklady` jako spouštěný a použijte `F5` nebo `Ctrl+F5`.

Z příkazové řádky můžete projekt spustit takto:

```bash
dotnet run --project 01-zaklady/01-zaklady.csproj
```

## Shrnutí

- Proměnná má název, datový typ a hodnotu.
- `Console` slouží ke vstupu a výstupu.
- `Parse()` převádí text, o kterém víme, že obsahuje číslo.
- `TryParse()` bezpečně zkouší převést neznámý vstup na číslo.
- `if-else` a `switch` větví program.
- `for`, `while`, `do-while` a `foreach` opakují příkazy.
- Pole uchovává více hodnot stejného typu.
- Číselné typy lze mezi sebou převádět.
