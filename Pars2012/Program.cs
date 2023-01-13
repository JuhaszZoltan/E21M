using Pars2012;

List<Versenyzo> versenyzok = new();

using StreamReader sr = new(@"..\..\..\RES\Selejtezo2012.txt");
_ = sr.ReadLine();
while (!sr.EndOfStream)
    versenyzok.Add(new Versenyzo(sr.ReadLine()!));

Console.WriteLine($"5. feladat: Versenyzők száma a selejtezőben: {versenyzok.Count} fő");

int atj = versenyzok.Count(x => x.Dobasok.Contains(-2f));
Console.WriteLine($"6. feladat: 78,00 méter feletti eredménnyel továbbjutott: {atj} fő");

var lje = versenyzok.OrderBy(x => x.Eredmeny).Last();
Console.WriteLine("9. feladat: A selejtező nyertese:\n" +
    $"\tNév: {lje.Nev}\n" +
    $"\tCsoport: {lje.Csoport}\n" +
    $"\tNemzet: {lje.Nemzet}\n" +
    $"\tNemzet kód: {lje.Kod}\n" +
    $"\tSorozat: {lje.Sorozat}\n" +
    $"\tEredmény: {lje.Eredmeny}");

Console.ReadKey(true);