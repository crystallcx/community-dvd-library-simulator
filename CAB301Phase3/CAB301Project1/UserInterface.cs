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

        public void Initalise()
        {
            Movie movie1 = new Movie("Revenge of the Sith", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie2 = new Movie("Die Hard", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie3 = new Movie("Willy Wonker", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie4 = new Movie("Lord of the Rings", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie5 = new Movie("The Clone Wars", MovieGenre.Action, MovieClassification.G, 65, 3);
            movieCollection.Insert(movie1);
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie3);
            movieCollection.Insert(movie4);
            movieCollection.Insert(movie5);

            Member member1 = new Member("Aone", "Onelast", "0404444444", "4837"); //3
            Member member2 = new Member("Btwo", "Twolast", "0404444444", "4837"); //5
            Member member3 = new Member("Cthree", "Threelast", "0404444444", "4837"); //4
            Member member4 = new Member("Dfour", "Fourlast", "0404444444", "4837"); //2
            Member member5 = new Member("five", "Fivelast", "0404444444", "4837"); //1
            memberCollection.Add(member1);
            memberCollection.Add(member2);
            memberCollection.Add(member3);
            memberCollection.Add(member4);
            memberCollection.Add(member5);

            movie2.AddBorrower(member2);
            movie2.AddBorrower(member3);
            movie2.AddBorrower(member1);
        }

        public void MainMenu()
        {
            Initalise(); /*   delete this line later   */


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
                        MemberLogin(); /* incomplete */
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
                          " 4. Remove a registered member from the system\n" +
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
                        RemoveMoviefromCollection();
                        break;
                    case 3:
                        RegisterMember();
                        break;
                    case 4:
                        /*something here */
                        break;
                    case 5:
                        DisplayMemberContact();/*dont know */
                        break;
                    case 6:
                        DisplayMovieBorrowers();/*something here */
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
                        BrowseAllMovies();
                        break;
                    case 2:
                        DisplayMovieInfo();
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
            if (staffUserName == "staff" && staffPassword == "today123")
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




        public void RemoveMoviefromCollection()
        {
            /* add case insensitivity */

            Console.Clear();
            Console.WriteLine("=============Remove Movie From Collection============\n");
            IMovie[] movieArray = movieCollection.ToArray();

            Console.WriteLine("Current collection of movies:");
            if (!movieCollection.IsEmpty())
            {
                foreach (IMovie imovie in movieArray)
                {
                    Console.WriteLine($"{imovie.ToString()}");
                }
            }
            else
            {
                Console.WriteLine("No movies exist in the movie collection.");
                Console.WriteLine("Press any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }

            Console.WriteLine("=====================================================\n" +
                              "\nEnter the title of the movie to be removed:");

            bool validMovieChecker = false;
            while (validMovieChecker == false)
            {
                string movieTitlePrompt = Console.ReadLine();
                Movie movie = (Movie)movieCollection.Search(movieTitlePrompt);
                Console.WriteLine($"Movie {movieTitlePrompt} does not exist in the movie collection, please try again or enter 0 to quit.");
                Console.WriteLine("Enter the title of the movie to be removed:");
                if (movieTitlePrompt == "0")
                    StaffMenu();
                if (movie != null)
                {
                    Console.WriteLine($"{movie.Title} has successfully been deleted from the movie collection.");
                    movieCollection.Delete(movie);
                    validMovieChecker = true;
                }
                //Console.ReadKey();
                //RemoveMoviefromCollection();
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

        public void RegisterMember()
        {
            Console.Clear();
            Console.WriteLine("=================Register a Member===================\n");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Contact Number: ");
            string contactNumber = Console.ReadLine();
            Console.Write("PIN: ");
            string pin = Console.ReadLine();
            Console.WriteLine();

            Member member = new Member(firstName, lastName, contactNumber, pin);

            bool validPhoneNumber = IMember.IsValidContactNumber(member.ContactNumber);
            bool validPIN = IMember.IsValidPin(member.Pin);

            while (!validPhoneNumber)
            {

                Console.Write("Please enter a valid contact number: ");
                string input = Console.ReadLine();
                member.ContactNumber = input;
                if (IMember.IsValidContactNumber(member.ContactNumber))
                    validPhoneNumber = true;
            }

            while (!validPIN)
            {
                Console.Write("Please enter a valid pin: ");
                string input = Console.ReadLine();
                member.Pin = input;
                if (IMember.IsValidPin(member.Pin))
                    validPIN = true;
            }

            //Create Member object with valid phone number & pin 
            Member validMember = new Member(firstName, lastName, member.ContactNumber, member.Pin);
            memberCollection.Add(validMember);
            Console.WriteLine($"{validMember.FirstName} {validMember.LastName} succesfully registered.");
            //Console.WriteLine($"{validMember.FirstName},{validMember.LastName},{validMember.ContactNumber},{validMember.Pin}");
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

        public void DisplayMemberContact()
        {
            Console.Clear();
            Console.WriteLine("========= Obtain a Member's Contact Number ==========");
            Console.WriteLine("Please enter a member's first name:");
            string memberFirstName = Console.ReadLine();
            Console.WriteLine("Please enter a member's last name:");
            string memberLastName = Console.ReadLine();

            /* something here */

            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

        public void DisplayMovieBorrowers() /*in progress*/
        {
            Console.Clear();
            Console.WriteLine("=========== Display Borrowers of a Movie ===============\n");
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($"There are currently no movies available.");
                Console.WriteLine("Press any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }
            Console.WriteLine("\nEnter the title of the movie:");

            Movie test = CheckMovieInput();
            Console.WriteLine(test.Borrowers.ToString());

            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

        public Movie CheckMovieInput()
        {
            Movie validMovie = null;
            bool validMovieCheck = false;
            while (validMovieCheck == false)
            {
                string movieTitle = Console.ReadLine();
                Movie movie = (Movie)movieCollection.Search(movieTitle);
                Console.WriteLine($"Movie {movieTitle} does not exist in the movie collection. Enter 0 to exit.");
                Console.WriteLine("Enter a valid movie title:");
                if (movie != null)
                {
                    validMovie = movie;
                    validMovieCheck = true;
                    return validMovie;
                }
                if (movieTitle == "0")
                    StaffMenu();
            }
            return validMovie;
        }

        public void MemberLogin()
        {
            Console.Clear();
            Console.WriteLine("=========Member Login==========");
            Console.WriteLine("Please enter first name:");
            string memberFirstName = Console.ReadLine();
            Console.WriteLine("Please enter last name:");
            string memberLastName = Console.ReadLine();
            Console.WriteLine("Please Enter PIN:"); //password
            string memberPIN = Console.ReadLine();

            /* something here 
            //Member member = new Member(memberFirstName, memberLastName, "", memberPIN);
            Member member = memberCollection.Search()


             */
            Console.WriteLine("Member login verification has yet to be implemented.\n" +
                              "Press any key to continue to the member menu.");
            Console.ReadKey();
            //Member member = memberCollection.Search(userName, password);
            MemberMenu();
        }

        public void BrowseAllMovies()
        {
            Console.Clear();
            Console.WriteLine("================Browsing All Movies=================\n");
            IMovie[] movieArray = movieCollection.ToArray();
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($"There are currently no movies available.");
                Console.WriteLine("Press any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }

            foreach (IMovie imovie in movieArray)
            {
                Console.WriteLine($"{imovie.ToString()}");
            }

            Console.WriteLine("\nPress any key to return to the member menu.");
            Console.ReadKey();
            MemberMenu();
        }

        public void DisplayMovieInfo()
        {
            Console.Clear();
            Console.WriteLine("================Obtain Movie Info=================\n");
            Console.WriteLine("Please enter a movie title:");
            bool validmovieQuery = false;

            while (!validmovieQuery)
            {
                string movieTitleInput = Console.ReadLine();
                Movie movie = (Movie)movieCollection.Search(movieTitleInput);
                Console.WriteLine("Please enter a valid movie title:");
                if (movieTitleInput == "0")
                    MemberMenu();
                if (movie != null)
                {
                    Console.WriteLine(movie.ToString() + "\n");
                    validmovieQuery = true;
                }
            }
            Console.WriteLine("Press any key to return to the member menu.");
            Console.ReadKey();
            MemberMenu();
        }

    }
}
