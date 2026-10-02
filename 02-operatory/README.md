Tento projekt obsahuje ukázky operátorů v jazyce C#. Všechny příklady najdete v souboru [`Program.cs`](Program.cs).

[Zpět na přehled repozitáře](../README.md)

## 1. Aritmetické operátory

| Operátor | Význam | Příklad | Výsledek |
|---|---|---|---|
| `+` `-` `*` | sčítání, odčítání, násobení | `7 * 2` | `14` |
| `/` | dělení | `7 / 2` | `3` (celá čísla) |
| `/` | dělení | `7 / 2.0` | `3.5` |
| `%` | zbytek po dělení | `7 % 2` | `1` |

Při dělení dvou `int` je výsledek také `int` – desetinná část se zahodí.

### Inkrementace a zkrácené zápisy

```csharp
int i = 0;
i++;     // i = i + 1 (postfix)
++i;     // prefix
i += 1;  // zkrácený zápis
```

- **postfix** (`a--`): použije se původní hodnota, poté se změní proměnná,
- **prefix** (`--a`): proměnná se změní a poté se použije nová hodnota.

## 2. Priorita operátorů

Násobení a dělení má přednost před sčítáním a odčítáním. Pořadí změníme závorkami.

```csharp
10 + 5 * 4    // 30
(10 + 5) * 4  // 60
```

## 3. Bitové operátory

Pracují s jednotlivými bity čísel (`5 = 101`, `3 = 011`).

| Operátor | Význam | `5 ? 3` |
|---|---|---|
| `&` | bitové AND | `1` |
| `\|` | bitové OR | `7` |
| `^` | bitové XOR | `6` |
| `<<` | posun doleva | `1 << 3` = `8` |
| `>>` | posun doprava | `16 >> 2` = `4` |

## 4. Porovnávací a logické operátory

Porovnání (`==`, `!=`, `<`, `>`, `<=`, `>=`) vrací hodnotu typu `bool`.

| Operátor | Význam |
|---|---|
| `&&` | logické AND (platí obě podmínky) |
| `\|\|` | logické OR (platí alespoň jedna) |
| `!` | negace |

Operátory `&&` a `||` používají zkrácené vyhodnocení – pokud je výsledek jasný z levé strany, pravá se už nevyhodnocuje.

## 5. Ternární operátor

```csharp
string text = (j > 0) ? "Kladné" : "Záporné nebo nula";
```

Je to zkrácený zápis `if` / `else`, který vrací hodnotu.

## 6. Nullable typy a operátor `??`

Typ `int?` může obsahovat číslo nebo `null`.

```csharp
int? num = null;
int d = num ?? 10;  // 10, protože num je null
num ??= 7;          // přiřadí 7 jen pokud je num null
```

## 7. Výchozí hodnoty (`default`)

| Typ | Výchozí hodnota |
|---|---|
| `int` | `0` |
| `bool` | `false` |
| `int?` | `null` |

## 8. Náhodná čísla

```csharp
int rand = Random.Shared.Next(1, 10); // 1 až 9
```

Horní mez se nezahrnuje.
