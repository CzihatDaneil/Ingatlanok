using System;
using System.Collections.Generic;
using System.Text;

namespace Ingatlanok
{
    internal class Class1
    {
    }
}
using System.IO;
using Dolgozat_gyakorló_feladat;

List<Eszkoz> eszkozok = new List<Eszkoz>();
if (!File.Exists("eszkozok.txt"))
{
    Console.WriteLine("A fájl nem található.");
    return;
}
else
{
    string[] sorok = File.ReadAllLines("eszkozok.txt");

    foreach (string sor in sorok)
    {
        if (string.IsNullOrWhiteSpace(sor))
        {
            continue;
        }
        string[] adatok = sor.Split(';');
        if (adatok.Length < 4)
        {
            continue;
        }
        string azonosito = adatok[0];
        string nev = adatok[1];
        string kategoria = adatok[2];
        if (adatok.Length == 4)
        {
            if (int.TryParse(adatok[3], out int napiDij))
            {


                eszkozok.Add(new Eszkoz(azonosito, nev, kategoria, napiDij));
            }
            else
            {
                Console.WriteLine($"[HIBA] A(z) {azonosito} azonosítójú eszköz adatai hibásak, átugorva!");
            }
        }
        if (adatok.Length == 5)
        {
            int.TryParse(adatok[3], out int napiDij);
            int.TryParse(adatok[4], out int keszlet);

            eszkozok.Add(new Eszkoz(azonosito, nev, kategoria, napiDij, keszlet));

        }
    }
}
foreach (var a in eszkozok)
{
    Console.WriteLine(a.ToString());
}
Console.WriteLine($"Regisztrált eszközök száma a rendszerben: {Eszkoz.OsszesRegisztraltEszkoz} db");