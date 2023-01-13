namespace Pars2012
{
    internal class Versenyzo
    {
        public string Nev { get; set; }
        public char Csoport { get; set; }
        private string NemzetEsKod { get; set; }
        public string Sorozat { get; private set; }
        public float[] Dobasok { get; set; }
        public float Eredmeny => Dobasok.Max();

        public string Nemzet =>
            NemzetEsKod[..NemzetEsKod.LastIndexOf(' ')];

        public string Kod =>
            NemzetEsKod[(NemzetEsKod.LastIndexOf(' ') + 1)..].Trim('(', ')');

        public Versenyzo(string sor)
        {
            string[] splts = sor.Split(';');

            Nev = splts[0];
            Csoport = char.Parse(splts[1]);
            NemzetEsKod = splts[2];
            Dobasok = new float[3];
            for (int i = 0; i < Dobasok.Length; i++)
            {
                Dobasok[i] = splts[i + 3] switch
                {
                    "X" => -1f,
                    "-" => -2f,
                    _ => float.Parse(splts[i + 3])
                };
                Sorozat += $"{splts[i + 3]};";
            }
            Sorozat = Sorozat![..^1];
        }
    }
}
