using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301Project
{
    class UserInterface
    {
        MovieCollection movieCollection = new MovieCollection();
        MemberCollection memberCollection = new MemberCollection(10);
        MovieGenre validGenre;
        MovieClassification validClassification;
        public void MainMenu()
        {
         

            Console.Clear();
            Console.Write("============================================================\n" +
                          "Welcome to the Community Library Movie DVD Management System\n" +
                          "============================================================\n" + "\n" +
                          "=========================Main Menu==========================\n" +
                          " 1. Staff Login\n" +
                          " 2. Member Login\n" +
                          " 0. Exit\n\n" +
                          "Enter your choice ==> (1/2/0)\n ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        StaffLogin();
                        break;
                    case 2:
                        /*something here */
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to continue.");
                Console.ReadKey();
                MainMenu();
            }
        }

        public void StaffMenu()
        {
            Console.Clear();
            Console.Write("=========================Staff Menu=========================\n" +
                          " 1. Add new DVDs of a new movie to the system\n" +
                          " 2. Remove DVDs of a movie from the system\n" +
                          " 3. Register a new Member with the system\n" +
                          " 4. Remove a resgistered member from the system\n" +
                          " 5. Display a member's contact phone number, given the member's name\n" +
                          " 6. Display all numbers who are currently renting a particular movie\n" +
                          " 0. Return to the main menu\n\n" +
                          "Enter your choice ==> (1/2/3/4/5/6/0)\n");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddMovieToCollection();
                        break;
                    case 2:
                        /*something here */
                        break;
                    case 3:
                        /*something here */
                        break;
                    case 4:
                        /*something here */
                        break;
                    case 5:
                        /*something here */
                        break;
                    case 6:
                        /*something here */
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to continue.");
                Console.ReadKey();
                MainMenu();
            }
        }

        public void MemberMenu()
        {
            Console.Clear();
            Console.Write("========================Member Menu=========================\n" +
                          " 1. Browse all the movies\n" +
                          " 2. Display all the information about a movie, given the title of the movie\n" +
                          " 3. Borrow a movie DVD\n" +
                          " 4. Return a movie DVD\n" +
                          " 5. List current borrowing movies\n" +
                          " 6. Display the top 3 movies rented by the members\n" +
                          " 0. Return to the main menu\n\n" +
                          "Enter your choice ==> (1/2/3/4/5/6/0)\n");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        /*something here */
                        break;
                    case 2:
                        /*something here */
                        break;
                    case 3:
                        /*something here */
                        break;
                    case 4:
                        /*something here */
                        break;
                    case 5:
                        /*something here */
                        break;
                    case 6:
                        /*something here */
                        break;
                    case 0:
                        MainMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to continue.");
                Console.ReadKey();
                MainMenu();
            }
        }
        public void StaffLogin()
        {
            Console.Clear();
            Console.WriteLine("=========Staff Login==========");
            Console.WriteLine("Please Enter Username:");
            string staffUserName = Console.ReadLine();
            Console.WriteLine("Please Enter Password:");
            string staffPassword = Console.ReadLine();
            if(staffUserName == "staff" && staffPassword == "today123")
            {
                StaffMenu();
            }
            else
            {
                Console.WriteLine("\nIncorrect Username or Password. Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
        }

        public void AddMovieToCollection()
        {
            Console.Clear();
            Console.WriteLine("=============Add New Movie To Collection============");
            
            //Title
            Console.WriteLine("Title:");
            string movieTitle = Console.ReadLine();

            //Genre
            bool validGenreChecker;
            Console.WriteLine("\nAllowed Genre: Action (1), Comedy (2), History (3), Drama (4) or Western (5).");
            //MovieGenre validGenre = (MovieGenre)Enum.Parse(typeof(MovieGenre), movieGenre);
            Console.WriteLine("Genre:");
            string movieGenrePrompt = Console.ReadLine();
            validGenreChecker = Enum.TryParse(movieGenrePrompt, out validGenre);
            if (!Enum.IsDefined(typeof(MovieGenre), validGenre) && !validGenre.ToString().Contains(","))
            {
                validGenreChecker = false;
            }
            while (validGenreChecker == false)
            {
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Allowed Genre: Action (1), Comedy (2), History (3), Drama (4) or Western (5).");
                Console.WriteLine("Genre:");
                string movieGenrePrompt2 = Console.ReadLine();
                validGenreChecker = Enum.TryParse(movieGenrePrompt2, out validGenre);
                if (!Enum.IsDefined(typeof(MovieGenre), validGenre) && !validGenre.ToString().Contains(","))
                {
                    validGenreChecker = false;
                }
                if (int.TryParse(movieGenrePrompt2, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }

            //Classification
            bool validClassificationChecker;
            Console.WriteLine("Allowed Classification: G (1), PG (2), M (3) or M15Plus (4).");
            Console.WriteLine("Classification:");
            string movieClassificationPrompt = Console.ReadLine();
            validClassificationChecker = Enum.TryParse(movieClassificationPrompt, out validClassification);
            //MovieClassification validClassification = (MovieClassification)Enum.Parse(typeof(MovieClassification), movieClassification);
            if (!Enum.IsDefined(typeof(MovieClassification), validClassification) && !validClassification.ToString().Contains(","))
            {
                validClassificationChecker = false;
            }
            while (validClassificationChecker == false)
            {
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Allowed Classification: G, PG, M or M15Plus");
                Console.WriteLine("Classification:");
                string movieClassificationPrompt2 = Console.ReadLine();
                validClassificationChecker = Enum.TryParse(movieClassificationPrompt, out validClassification);
                if (!Enum.IsDefined(typeof(MovieClassification), validClassification) && !validClassification.ToString().Contains(","))
                {
                    validClassificationChecker = false;
                }
                if (int.TryParse(movieClassificationPrompt2, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }

            //Duration
            Console.WriteLine("Duration:");
            string movieDuration = Console.ReadLine();
            int.TryParse(movieDuration, out int validDuration);

            //Copies
            Console.WriteLine("Available Copies:");
            string movieAvailableCopies = Console.ReadLine();
            int.TryParse(movieAvailableCopies, out int validCopies);

            Movie movie = new Movie(movieTitle, validGenre, validClassification, validDuration, validCopies);
            movieCollection.Insert(movie);
            Console.WriteLine($"{movie.ToString()}");
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            
            StaffMenu();


        }



    }
}
