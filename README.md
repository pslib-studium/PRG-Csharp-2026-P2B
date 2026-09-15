# Ukázkové kódy z hodin programování C# 2026

Tento repozitář obsahuje ukázkové kódy z hodin programování v jazyce C# pro třídu P2B. Materiály slouží k zopakování výkladu z hodin, lepšímu pochopení probíraných konstrukcí a k samostatnému studiu.

Každé téma je uloženo v samostatném projektu. Zdrojový kód obsahuje komentované příklady a u vybraných lekcí je doplněn podrobnějším souborem `README.md`.

## Požadavky

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/cs/vs/) s nainstalovanou podporou pro vývoj desktopových aplikací v .NET
- Git pro stažení a aktualizaci repozitáře

Projekt lze otevřít také v jiném editoru s podporou C# a spouštět pomocí příkazů `dotnet`.

## Stažení repozitáře

```bash
git clone https://github.com/pslib-studium/PRG-Csharp-2026-P2B.git
cd PRG-Csharp-2026-P2B
```

## Otevření a spuštění ve Visual Studiu

1. Otevřete soubor `PRG-2026.sln`.
2. V okně **Solution Explorer** vyberte projekt, který chcete spustit.
3. Nastavte jej jako spouštěný projekt pomocí **Set as Startup Project**.
4. Program spusťte klávesou `F5`, případně bez ladění kombinací `Ctrl+F5`.

## Sestavení a spuštění z příkazové řádky

Celé řešení sestavíte příkazem:

```bash
dotnet build PRG-2026.sln
```

První lekci spustíte příkazem:

```bash
dotnet run --project 01-zaklady/01-zaklady.csproj
```

## Přehled lekcí

| Lekce | Téma | Obsah |
|---|---|---|
| [01 – Základy](01-zaklady/README.md) | Základní konstrukce C# | Proměnné, konzole, převody, podmínky, cykly, pole a číselné typy |

Další projekty a odkazy budou přibývat postupně podle probírané látky.

## Jak s materiály pracovat

1. Nejdříve si přečtěte README příslušné lekce.
2. Otevřete zdrojový soubor `Program.cs` a projděte jednotlivé komentované části.
3. Program spusťte a sledujte, jak se výstup mění podle zadaných hodnot.
4. Zkuste měnit jednotlivé hodnoty a podmínky a před spuštěním odhadnout výsledek.

## Další doporučené výukové materiály

### Kniha

- **Bory, Pavel:** *C# bez předchozích znalostí*, Computer Press

### Oficiální dokumentace

- [Dokumentace k jazyku C# – Microsoft Learn](https://learn.microsoft.com/cs-cz/dotnet/csharp/)
- [Interaktivní úvod do C# – Microsoft Learn](https://learn.microsoft.com/cs-cz/dotnet/csharp/tour-of-csharp/tutorials/)
- [.NET API browser](https://learn.microsoft.com/cs-cz/dotnet/api/)

### Další online kurzy

- [Online kurzy programování C#.NET – ITnetwork.cz](https://www.itnetwork.cz/csharp)
- [C# Tutorial – W3Schools](https://www.w3schools.com/cs/)
- [Learn C# – Codecademy](https://www.codecademy.com/learn/learn-c-sharp)

## Licence

Podmínky použití jsou uvedeny v souboru [LICENSE](LICENSE).
