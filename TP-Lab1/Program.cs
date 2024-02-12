class Program
{
    static void RandFilMatrx(float[,] matrx, int n)
    {
        Random r = new Random();
        float strF = 0.1f;
        float endF = 100.1f;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrx[i, j] = (float)(r.NextDouble() * (endF - strF));
            }
        }
    }
    static void SumMatrix(float[,] matrx1, float[,] matrx2, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrx1[i, j] += matrx2[i, j];
            }
        }
    }

    static void SumMatrixParall(float[,] matrx1, float[,] matrx2, int st, int end, int n)
    {
        for (int i = st; i < end; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrx1[i, j] += matrx2[i, j];
            }
        }
    }
    static void printM(List<float> mas)
    {
        for (int i = 0; i < mas.Count(); i++)
            Console.WriteLine(mas[i]);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите значение N: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int m = 8;

        float[,] matrix1 = new float[n, n];
        float[,] matrix2 = new float[n, n];
        RandFilMatrx(matrix1, n);
        RandFilMatrx(matrix2, n);
        DateTime t1, t2;
        t1 = DateTime.Now;
        SumMatrix(matrix1, matrix2, n);
        t2 = DateTime.Now;
        TimeSpan dt = t2 - t1;
        Console.WriteLine("Time m = 1 : " + dt.TotalMilliseconds);
        RandFilMatrx(matrix1, n);
        RandFilMatrx(matrix2, n);

        int p = 0;
        //for (int k = 0; k < 6; k++)
        //{
        for (int j = 2; j < m + 1; j++)
            {
                RandFilMatrx(matrix1, n);
                RandFilMatrx(matrix2, n);   
                DateTime tth1, tth2;
                Thread[] threads = new Thread[j];
                p = n / j;
                tth1 = DateTime.Now;
                for (int i = 0; i < j; i++)
                {
                    int stTh = i * p;
                    int enTh = (i == j - 1) ? n : (i + 1) * p;
                    threads[i] = new Thread(() =>
                        SumMatrixParall(matrix1, matrix2, stTh, enTh, n)

                        );
                    threads[i].Start();
                }
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }
                tth2 = DateTime.Now;
                TimeSpan tths = tth2 - tth1;
                Console.WriteLine("Time m = " + j + " : " + tths.TotalMilliseconds);
            }
        }
    //}

}