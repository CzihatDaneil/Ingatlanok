using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ingatlanok;

List<Ingatlan> Ingatlanok = new List<Ingatlan>();
if (!File.Exists("ingatlanok.txt"))
{
    Console.WriteLine("A fájl nem található.");
    return;
}
else
{
    string[] sorok = File.ReadAllLines("ingatlanok.txt");

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
        string cim = adatok[1];
        string kategoria = adatok[2];
        if (adatok.Length == 4)
        {
            if (int.TryParse(adatok[3], out int alapteruletM2))
            {


                Ingatlanok.Add(new(azonosito, cim, kategoria, alapteruletM2));
            }
            else
            {
                Console.WriteLine($"[HIBA] A(z) {azonosito} azonosítójú ingatlan adatai hibásak, átugorva!");
            }
        }
        if (adatok.Length == 5)
        {
            int.TryParse(adatok[3], out int alapteruletM2);
            int.TryParse(adatok[4], out int osszesRegisztraltIngatlan);
            Ingatlanok.Add(new Ingatlan(azonosito, cim, kategoria, alapteruletM2, osszesRegisztraltIngatlan));
        }
    }
foreach (var a in Ingatlanok)
{
    Console.WriteLine(a.ToString());
}
Console.WriteLine($"Regisztrált ingatlanok száma a rendszerben: {Ingatlanok.Ossre} db");