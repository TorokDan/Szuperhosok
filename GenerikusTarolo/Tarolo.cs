namespace GenerikusTarolo
{
    public class Tarolo
    {
        private string[] tomb;

        public Tarolo()
        {
            tomb = new string[0];
        }

        public void Hozzaadas(string elem)
        {
            string[] tmp = new string[tomb.Length + 1];
            for (int i = 0; i < tomb.Length; i++)
            {
                tmp[i] = tomb[i];
            }
            tmp[tmp.Length - 1] = elem;
            tomb = tmp;
        }
    }
}