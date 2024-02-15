class Program
{
    static List<int> Prime(int n)
    {
        List<int> Mas1 = new List<int>();
        for (int i = 2; i < Convert.ToInt32(Math.Sqrt(n)); i++)
        {
            Mas1.Add(i);
        }
        for (int i = 2; i < Mas1.Count(); i++)
            for (int j = i + i; j < (int)Math.Sqrt(n); j += i)
                Mas1.Remove(j);
        return Mas1;
    }

    static List<int> fPrime(List<int> bM, int n)
    {
        List<int> fM = new List<int>();
        bool t = true;
        for (int i = Convert.ToInt32(Math.Sqrt(n)); i < n; i++)
        {
            t = true;
            for (int j = 0; j < bM.Count(); j++)
            {
                if (i % bM[j] == 0)
                {
                    t = false;
                }
            }
            if (t)
                fM.Add(i);
        }
        return (fM);
    }

    static void printM(List<int> mas)
    {
        for (int i = 0; i < mas.Count(); i++)
            if (mas[i] != 0) Console.Write(mas[i] + " ");
        Console.WriteLine();
    }

    static void addList(List<int> bM, List<int> fM)
    {
        for (int i = bM.Count() - 1; i >= 0; i--)
        {
            fM.Insert(0, bM[i]);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение N: ");
        int n = Convert.ToInt32(Console.ReadLine());
        List<int> baseMas = Prime(n);
        DateTime t1, t2;
        t1 = DateTime.Now;
        List<int> fM = fPrime(baseMas, n);
        t2 = DateTime.Now;
        TimeSpan dt = t2 - t1;
        addList(baseMas, fM);
        printM(fM);
        Console.WriteLine(dt.TotalMilliseconds);
    }
}