// OPERÁTORY V C#
// Každá sekce je samostatná ukázka. Spusťte program a sledujte výstup.

// 1. Aritmetické operátory a inkrementace
Console.WriteLine("=== 1. Aritmetické operátory ===");
int i = 0;
i = i + 1; // 1
i++;       // 2 (postfix: nejdřív použije hodnotu, pak zvýší)
i += 1;    // 3 (zkrácený zápis i = i + 1)
++i;       // 4 (prefix: nejdřív zvýší, pak použije hodnotu)
Console.WriteLine($"i = {i}");

Console.WriteLine($"7 + 2 = {7 + 2}, 7 - 2 = {7 - 2}, 7 * 2 = {7 * 2}");
Console.WriteLine($"7 / 2 = {7 / 2}");     // 3 – celočíselné dělení
Console.WriteLine($"7 / 2.0 = {7 / 2.0}"); // 3.5 – jeden operand je double
Console.WriteLine($"7 % 2 = {7 % 2}");     // 1 – zbytek po dělení

int a = 2;
int b = 3;
int c = a-- * b; // použije a = 2, až potom sníží a na 1
Console.WriteLine($"c = {c}, a = {a}"); // c = 6, a = 1

// 2. Priorita operátorů
Console.WriteLine("\n=== 2. Priorita operátorů ===");
int d = 10 + 5 * 4; // násobení má přednost -> 30
Console.WriteLine($"10 + 5 * 4 = {d}");
d = (10 + 5) * 4;   // závorky mění pořadí -> 60
Console.WriteLine($"(10 + 5) * 4 = {d}");

// 3. Bitové operátory (5 = 101, 3 = 011)
Console.WriteLine("\n=== 3. Bitové operátory ===");
Console.WriteLine($"5 | 3 = {5 | 3}");   // OR  -> 111 = 7
Console.WriteLine($"5 & 3 = {5 & 3}");   // AND -> 001 = 1
Console.WriteLine($"5 ^ 3 = {5 ^ 3}");   // XOR -> 110 = 6
Console.WriteLine($"1 << 3 = {1 << 3}"); // posun doleva  -> 8
Console.WriteLine($"16 >> 2 = {16 >> 2}"); // posun doprava -> 4

// 4. Porovnávací a logické operátory
Console.WriteLine("\n=== 4. Porovnávací a logické operátory ===");
int x = 5;
Console.WriteLine($"x == 5: {x == 5}");
Console.WriteLine($"x != 5: {x != 5}");
Console.WriteLine($"x > 3:  {x > 3}");
Console.WriteLine($"x <= 4: {x <= 4}");

bool f = true;
bool g = false;
Console.WriteLine($"f && g = {f && g}"); // AND – obě musí platit
Console.WriteLine($"f || g = {f || g}"); // OR – stačí jedna
Console.WriteLine($"!f = {!f}");         // NOT – negace
// Zkrácené vyhodnocení: pravá strana se nevyhodnotí, pokud je výsledek jasný.

// 5. Ternární operátor
Console.WriteLine("\n=== 5. Ternární operátor ===");
int j = 5;
// podmínka ? hodnotaPokudPravda : hodnotaPokudNepravda
string textCislo = (j > 0) ? "Kladné" : "Záporné nebo nula";
Console.WriteLine(textCislo);

// Totéž pomocí if – ternární operátor je jen kratší zápis
if (j > 0)
{
    Console.WriteLine("Kladné");
}
else
{
    Console.WriteLine("Záporné nebo nula");
}

// 6. Nullable typy a operátor ??
Console.WriteLine("\n=== 6. Nullable a operátor ?? ===");
int? num = null; // int? může obsahovat i null
d = num ?? 10;   // num je null -> použije se 10
num = 1;
c = num ?? 5;    // num má hodnotu -> použije se 1
Console.WriteLine(d); // 10
Console.WriteLine(c); // 1

int? nula = null;
nula ??= 7;      // přiřadí pouze pokud je proměnná null
Console.WriteLine(nula); // 7

// 7. Výchozí hodnoty
Console.WriteLine("\n=== 7. Výchozí hodnoty ===");
int m = default;  // 0
int? n = default; // null
bool l = default; // false
Console.WriteLine($"int: {m}, int?: {n?.ToString() ?? "null"}, bool: {l}");

// 8. Náhodná čísla
Console.WriteLine("\n=== 8. Náhodné číslo ===");
int rand = Random.Shared.Next(1, 10); // 1 až 9 (horní mez se nezahrnuje)
Console.WriteLine($"Náhodné číslo: {rand}");