using System;
using System.IO;

namespace CAB301Project
{
    class Program
    {

        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();

            //Top3Tester(); //uncomment this line if you wish to run tests on top3
            
            ui.Initalise(); /*   uncomment this if you wish to run the program with movies and users   */

            ui.MainMenu(); // comment this line if testing top3

        }

        //Test the Top3 method by feeding it arrays of length 1000-20000
        //Input: Top3 method
        //Output: Display results to console.
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
                    IMovie[] data = new IMovie[n];
                    int myCounter = 0;
                    for (int k = 0; k < data.Length; k++)
                    {
                        data[k] = new Movie($"test {myCounter++}");
                    }
                    for (int j = 0; j < numPerN; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            data[k].NoBorrowings = rand.Next(0, n * 2);
                        }
                        int opCount = 0;
                        long startTicks = DateTime.Now.Ticks;
                        opCount = Top3Movies(data);
                        long totalTicks = DateTime.Now.Ticks - startTicks;
                        double elapsedTime = (double)totalTicks / (double)TimeSpan.TicksPerSecond;
                        totalOps += opCount;
                        totalTime += elapsedTime;
                    }
                    long avOps = totalOps / numPerN;
                    double avTime = totalTime / numPerN;
                    sw.WriteLine("{0}, {1}, {2}", n, avOps, avTime);
                }
            }
        }

        //Method to find and display (to console) the top 3 movies in array A
        //input: array A of type IMovie
        //output: opCount - counter of basic operations
        public static int Top3Movies(IMovie[] A)
        {
            int opCount = 0;
            IMovie tempMovie = new Movie("temp");
            IMovie first, second, third;
            int n = A.Length;
            if (A == null)
            {
                Console.WriteLine(" Error - No movies in this movie collection.");
                return 0;
            }
            else
            {
                first = second = third = tempMovie;
                for (int i = 0; i < n; i++)
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

                //debug to print to console
                int j = 1;
                if (first.NoBorrowings != 0)
                {
                    Console.WriteLine($" {j++}) {first.Title} - Total times borrowed: {first.NoBorrowings}");
                }
                else
                {
                    Console.WriteLine($" {j++}) - nil");
                }
                if (second.NoBorrowings != 0)
                {
                    Console.WriteLine($" {j++}) {second.Title} - Total times borrowed: {second.NoBorrowings}");
                }
                else
                {
                    Console.WriteLine($" {j++}) - nil");
                }
                if (third.NoBorrowings != 0)
                {
                    Console.WriteLine($" {j++}) {third.Title} - Total times borrowed: {third.NoBorrowings}");
                }
                else
                {
                    Console.WriteLine($" {j++}) - nil");
                }
                Console.WriteLine($"Counter = {opCount}\n");
                Console.WriteLine();
                //debug end
            }
            return opCount;
        }
    }
}
