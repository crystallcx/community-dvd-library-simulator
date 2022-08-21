using System;

namespace CAB301Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Member member1 = new Member("Aone", "Onelast", "0404444444", "4837"); //3
            Member member2 = new Member("Btwo", "Twolast", "0404444444", "4837"); //5
            Member member3 = new Member("Cthree", "Threelast", "0404444444", "4837"); //4
            Member member4 = new Member("Dfour", "Fourlast", "0404444444", "4837"); //2
            Member member5 = new Member("five", "Fivelast", "0404444444", "4837"); //1
            Member member6 = new Member("Dsix", "Sixlast", "0404444444", "4837"); //4            Member member4 = new Member("Dfour", "Fourlast", "0404444444", "4837"); //2
            Member member7 = new Member("ad", "Fivelast", "0404444444", "4837"); //1
            Member member8 = new Member("fidave", "Fivelast", "0404444444", "4837"); //1
            Member member9 = new Member("fivsse", "Fivelast", "0404444444", "4837"); //1
            Member member10 = new Member("fasive", "Fivelast", "0404444444", "4837"); //1
            Member member11 = new Member("Dsssix", "Sixlast", "0404444444", "4837"); //4

            Movie movie9 = new Movie("Star Wars", MovieGenre.Action, MovieClassification.G, 60, 12);
            Movie movie10 = new Movie("My Mister", MovieGenre.Action, MovieClassification.G, 60, 3);
            Movie movie11 = new Movie("Scarlet Heart Ryeo", MovieGenre.Action, MovieClassification.G, 60, 3);

            movie9.ToString();
            movie9.AddBorrower(member1);
            movie9.AddBorrower(member2);
            movie9.AddBorrower(member3);
            movie9.AddBorrower(member4);
            movie9.AddBorrower(member5);
            movie9.AddBorrower(member6);            
            movie9.AddBorrower(member7);
            movie9.AddBorrower(member8);
            movie9.AddBorrower(member9);
            movie9.AddBorrower(member10);
            movie9.AddBorrower(member11);
            Console.WriteLine(movie9.Borrowers.ToString());
            movie9.ToString();

            movie9.RemoveBorrower(member5);
            Console.WriteLine(movie9.Borrowers.ToString());
            movie9.ToString();

            //create movie objects with only title name (for now)
            Movie movie1 = new Movie("Revenge of the Sith", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie2 = new Movie("Die Hard", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie3 = new Movie("Willy Wonker", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie4 = new Movie("Lord of the rings", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie5 = new Movie("The Clone Wars", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie6 = new Movie("Plup Fiction", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie7 = new Movie("Casino Royal", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie8 = new Movie("The Wizard of Oz", MovieGenre.Action, MovieClassification.G, 65, 3);

            //create a new Bianry Tree Search - MovieCollection
            MovieCollection newMovieCollections = new MovieCollection();

            //Insert 8 members, try add a duplicate movie title 
            //Console.WriteLine($"Inserting movie: {movie1.Title} == {newMovieCollections.Insert(movie1)}");
            //Console.WriteLine($"Inserting movie: {movie2.Title} == {newMovieCollections.Insert(movie2)}");
            //Console.WriteLine($"Inserting movie: {movie3.Title} == {newMovieCollections.Insert(movie3)}");
            //Console.WriteLine($"Inserting movie: {movie4.Title} == {newMovieCollections.Insert(movie4)}");
            //Console.WriteLine($"Inserting movie: {movie5.Title} == {newMovieCollections.Insert(movie5)}");
            //Console.WriteLine($"Inserting movie: {movie6.Title} == {newMovieCollections.Insert(movie6)}");
            //Console.WriteLine($"Inserting movie: {movie5.Title} == {newMovieCollections.Insert(movie5)}");
            //Console.WriteLine($"Inserting movie: {movie7.Title} == {newMovieCollections.Insert(movie7)}");
            //Console.WriteLine($"Inserting movie: {movie8.Title} == {newMovieCollections.Insert(movie8)}");
            //Console.WriteLine($"Inserting movie: {movie9.Title} == {newMovieCollections.Insert(movie9)}");
            //Console.WriteLine($"Inserting movie: {movie10.Title} == {newMovieCollections.Insert(movie10)}");
            //Console.WriteLine($"Inserting movie: {movie11.Title} == {newMovieCollections.Insert(movie11)}");
 
            Console.WriteLine();

            IMovie[] testArray = newMovieCollections.ToArray();
               foreach (IMovie movie in testArray)
               {
                   if (movie != null)
                   {
                       Console.WriteLine($"Movies in To Array = {movie.Title}");
                   }
               }

            //Console.WriteLine("Test Search");
            //IMovie test = newMovieCollections.Search("my Mister");
            //Console.WriteLine(test.ToString());

            //EXPECTED RESULTS
            // Casino Royal
            // Die Hard
            // Lord of the rings
            // Pulp Fiction
            // Revenge of the Sith
            // The Clone Wars
            // The Wizard of Oz
            // Willy Wonker



        }
    }
}






