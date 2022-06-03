using System;
using System.IO;

namespace CAB301Project
{
    class Program
    {
        
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            //Top3Tester();
            ui.MainMenu();

        }

        public static void Top3Tester()
        {
            int stepChange = 1000;
            int numPerN = 10;
            Random rand = new Random((int)DateTime.Now.Ticks);

            using (StreamWriter sw = new StreamWriter("results.csv"))
            {
                sw.WriteLine("n, opCount, runTime");

                for (int i = 0; i < 20; i++)
                {

                    int n = (i + 1) * stepChange;
                    Console.WriteLine("testing n={0}", n);

                    long totalOps = 0;
                    double totalTime = 0;

                    for (int j = 0; j < numPerN; j++)
                    {
                        //Console.WriteLine("Data is: [{0}]", string.Join(",", data));


                        //Console.WriteLine("Searching for {0}", search);

                        IMovie[] data = new IMovie[n];
                        int myCounter = 0;
                        for (int k = 0; k < data.Length; k++)
                        {
                            data[k] = new Movie($"test {myCounter++}");
                        }
                        for (int k = 0; k < n; k++)
                        {
                            data[k].NoBorrowings = rand.Next(0, n * 2);
                        }

                        int opCount = 0;

                        long startTicks = DateTime.Now.Ticks;
                        Top3(data, out opCount);
                        long totalTicks = DateTime.Now.Ticks - startTicks;

                        double elapsedTime = (double)totalTicks / (double)TimeSpan.TicksPerSecond;

                        totalOps += opCount;
                        totalTime += elapsedTime;

                        //Console.WriteLine("Result idx: {0}, Value: {1}, opCount: {2}, elapsedTime: {3}", result, result != -1 ? data[result] : -1, opCount, elapsedTime);
                    }

                    long avOps = totalOps / numPerN;
                    double avTime = totalTime / numPerN;

                    sw.WriteLine("{0}, {1}, {2}", n, avOps, avTime);
                }
            }
        }

        public static void Top3(IMovie[] A, out int opCount)
        {
            opCount = 0;
            //MovieCollection Collectiontemp = movieCollection;
            // IMovie[] A = Collectiontemp.ToArray();
            IMovie tempMovie = new Movie("temp");
            IMovie first, second, third;
            //need a temp movie with NoBorrowings = 0
            first = second = third = tempMovie;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i].NoBorrowings > first.NoBorrowings)
                {
                    opCount++;
                    third = second;
                    second = first;
                    first = A[i];
                }
                else if (A[i].NoBorrowings > second.NoBorrowings)
                {
                    opCount++;
                    third = second;
                    second = A[i];
                }
                else if (A[i].NoBorrowings > third.NoBorrowings)
                {
                    opCount++;
                    third = A[i];
                }
            }
        }

        public static void InsertionSort(IMovie[] A, out int opCount)
        {
            opCount = 0;

            int n = A.Length;
            for (int i = 1; i < n; i++)
            {
                IMovie v = A[i];
                int j = i - 1;

                while (j >= 0 && A[j].NoBorrowings > v.NoBorrowings)
                {
                    opCount += 1;
                    A[j + 1] = A[j];
                    j = j - 1;
                }

                if (j >= 0)
                {
                    opCount += 1;
                }

                A[j + 1] = v;
            }
        }
    
    }
}
