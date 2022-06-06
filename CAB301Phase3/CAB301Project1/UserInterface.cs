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
        MemberCollection memberCollection = new MemberCollection(1000);
        MovieGenre validGenre;
        MovieClassification validClassification;
        IMember CurrentlyLoggedInUser;

        //test method to initalise the system with 6 movies and 11 members
        public void Initalise()
        {
            Movie movie1 = new Movie("Revenge of the Sith", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie2 = new Movie("Die Hard", MovieGenre.Action, MovieClassification.G, 65, 4);
            Movie movie3 = new Movie("Willy Wonker", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie4 = new Movie("Lord of the Rings", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie5 = new Movie("The Clone Wars", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie6 = new Movie("Harry Potter 1", MovieGenre.Action, MovieClassification.G, 65, 11);

            movieCollection.Insert(movie1);
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie3);
            movieCollection.Insert(movie4);
            movieCollection.Insert(movie5);
            movieCollection.Insert(movie6);

            Member member1 = new Member("John", "Kelly", "0404444544", "4837"); //3
            Member member2 = new Member("Harry", "Last", "0404234444", "4837"); //5
            Member member3 = new Member("Peter", "Smith", "0404445674", "4837"); //4
            Member member4 = new Member("John", "Alpha", "0423444441", "4837"); //2
            Member member5 = new Member("Chris", "Zebra", "0404444554", "4837"); //1
            Member member6 = new Member("James", "Wyatt", "0422977674", "1313"); //1
            Member member7 = new Member("Jacky", "Smith", "0422977674", "1414"); //1
            Member member8 = new Member("Larry", "Smith", "0422977674", "1414"); //1
            Member member9 = new Member("Betty", "Smith", "0422977674", "1414"); //1
            Member member10 = new Member("Chuck", "Smith", "0422977674", "1414"); //1
            Member member11 = new Member("David", "Smith", "0422977674", "1414"); //1
            memberCollection.Add(member1);
            memberCollection.Add(member2);
            memberCollection.Add(member3);
            memberCollection.Add(member4);
            memberCollection.Add(member5);
            memberCollection.Add(member6);
            memberCollection.Add(member7);
            memberCollection.Add(member8);
            memberCollection.Add(member9);
            memberCollection.Add(member10);
            memberCollection.Add(member11);

            // movie2.AddBorrower(member2); //Die Hard
            // movie2.AddBorrower(member3); //Die Hard
            // movie2.AddBorrower(member1); //Die Hard
            // movie1.AddBorrower(member6); //Revenge of the Sith
            // movie2.AddBorrower(member6); //Die Hard
            // movie3.AddBorrower(member6); //Willy Wonker 
            // movie4.AddBorrower(member6); //Lord of the Rings
            // movie5.AddBorrower(member6); //The Clone Wars
            // movie1.AddBorrower(member5); //Revenge of the Sith
            //Top 3 Expected Results:
            // Die Hard - 4
            //Revenge of the Sith - 2
            //Lord of the Rings - 1

            /* test case: add more than 10 members to 1 movie 
            movie6.AddBorrower(member1);
            movie6.AddBorrower(member2);
            movie6.AddBorrower(member3);
            movie6.AddBorrower(member4);
            movie6.AddBorrower(member5);
            movie6.AddBorrower(member6);
            movie6.AddBorrower(member7);
            movie6.AddBorrower(member8);
            movie6.AddBorrower(member9);
            movie6.AddBorrower(member10);
            */
        }



        //main menu
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
                        MemberLogin();
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



        //staff menu
        public void StaffMenu()
        {
            Console.Clear();
            Console.Write("=========================Staff Menu=========================\n" +
                          " 1. Add new DVDs of a new movie to the system\n" +
                          " 2. Remove DVDs of a movie from the system\n" +
                          " 3. Register a new Member with the system\n" +
                          " 4. Remove a registered member from the system\n" +
                          " 5. Display a member's contact phone number, given the member's name\n" +
                          " 6. Display all members who are currently renting a particular movie\n" +
                          " 0. Return to the main menu\n\n" +
                          "Enter your choice ==> (1/2/3/4/5/6/0)\n");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddDvds();
                        break;
                    case 2:
                        RemoveDVDs();
                        break;
                    case 3:
                        RegisterMember();
                        break;
                    case 4:
                        DeleteRegisteredMember();
                        break;
                    case 5:
                        DisplayMemberContact();
                        break;
                    case 6:
                        DisplayMovieBorrowers();
                        break;
                    case 0:
                        Console.WriteLine("\n Logging out staff account - Press any key to continue...");
                        Console.ReadKey();
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



        //Member menu
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
                        BorrowMovie(CurrentlyLoggedInUser);
                        break;
                    case 4:
                        ReturnMovie(CurrentlyLoggedInUser);
                        break;
                    case 5:
                        CurrentlyBorrowed(CurrentlyLoggedInUser);
                        break;
                    case 6:
                        Top3Movies();
                        break;
                    case 0:
                        MemberLogout();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Press any key to continue.");
                        Console.ReadKey();
                        MemberMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to continue.");
                Console.ReadKey();
                MemberMenu();
            }
        }



        //staff login
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
                Console.WriteLine("\n Staff login verified.\n" +
                    "\nPress any key to continue...");

                Console.ReadKey();
                StaffMenu();
            }
            else
            {
                Console.WriteLine("\nIncorrect Username or Password. Press any key to continue...");
                Console.ReadKey();
                MainMenu();
            }
        }


        //=====================================Staff Menu Methods ====================
        //Add Movie To Collection
        public void AddDvds()
        {
            Console.Clear();
            Console.WriteLine("============= Add DVDs to a Movie or new Movie to this Collection ============");

            //Title
            //A title is valid if its length is greater than 1 - no empty stings will be accepeted
            Console.WriteLine("Title:");
            string movieTitlePrompt = Console.ReadLine();
            bool validTitleChecker = movieTitlePrompt.Length > 0;
            while (validTitleChecker == false)
            {
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Title:");
                movieTitlePrompt = Console.ReadLine();
                validTitleChecker = movieTitlePrompt.Length > 0;
                if (int.TryParse(movieTitlePrompt, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            string validMovieTitle = movieTitlePrompt;

            //check if movie already exists by title then ask to add dvds
            Movie validMovie = (Movie)movieCollection.Search(validMovieTitle);
            if (validMovie != null)
            {
                Console.Write($"\nMovie Found in this Collection:\n\n");
                Console.WriteLine($"{ validMovie.ToString().Replace(',', '\n')} \n Total Copies: {validMovie.TotalCopies}");
                Console.WriteLine("\n Please enter amount of DVDs to add for this movie:");
                string smovie = Console.ReadLine();
                bool validCount = int.TryParse(smovie, out int addCount);
                validCount = addCount > 0;
                while (validCount == false)
                {
                    Console.WriteLine("\nInvalid Input, must be greater than 0 and numeric. Press 0 to exit.");
                    Console.WriteLine("Please enter amount of DVDs to add for this movie:");
                    smovie = Console.ReadLine();
                    int.TryParse(smovie, out addCount);
                    validCount = addCount > 0;
                    if (int.TryParse(smovie, out int quit))
                    {
                        if (quit == 0)
                        {
                            StaffMenu();
                        }
                    }
                }
                if (validCount == true)
                {

                    validMovie.TotalCopies += addCount;
                    validMovie.AvailableCopies += addCount;
                    Console.WriteLine($"\n Adding {addCount} copies of DVDs to {validMovie.Title} - Total Copies {validMovie.TotalCopies}");
                    Console.WriteLine("\nPress any key to return to the staff menu.");
                    Console.ReadKey();
                    StaffMenu();
                }
            }
            else
            {
                Console.WriteLine($"\n Movie '{movieTitlePrompt}' is not found in this Collection.");
                Console.WriteLine($" Please enter the new details of '{movieTitlePrompt}'");
            }

            //Genre
            //Here we check if the input is a valid Genre, a Genre must be one of the following:
            //Allowed Genre: Action (1), Comedy (2), History (3), Drama (4) or Western (5)
            //A user can either enter in the number associcated with the Genre, i.e "1" or can write the full name of the genre, i.e "Action"
            bool validGenreChecker;
            Console.WriteLine("\nAllowed Genre: Action (1), Comedy (2), History (3), Drama (4) or Western (5).");
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
            //Here we check if the input is a valid Classification, a Classification must be one of the following:
            //Allowed Classification: G (1), PG (2), M (3) or M15Plus (4).
            //A user can either enter in the number associcated with the Classification, i.e "1" or can write the full name of the genre, i.e "M15Plus"
            bool validClassificationChecker;
            Console.WriteLine("\nAllowed Classification: G (1), PG (2), M (3) or M15Plus (4).");
            Console.WriteLine("Classification:");
            string movieClassificationPrompt = Console.ReadLine();
            validClassificationChecker = Enum.TryParse(movieClassificationPrompt, out validClassification);
            if (!Enum.IsDefined(typeof(MovieClassification), validClassification) && !validClassification.ToString().Contains(","))
            {
                validClassificationChecker = false;
            }
            while (validClassificationChecker == false)
            {
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Allowed Classification: G (1), PG (2), M (3) or M15Plus (4)");
                Console.WriteLine("Classification:");
                string movieClassificationPrompt2 = Console.ReadLine();
                validClassificationChecker = Enum.TryParse(movieClassificationPrompt2, out validClassification);
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
            //A Duration is valid if > 0 - no empty strings will be accepted.
            bool validDuration;
            Console.WriteLine("\nDuration:");
            string movieDurationPrompt = Console.ReadLine();
            int.TryParse(movieDurationPrompt, out int movieDuration);
            validDuration = movieDuration > 0;
            while (validDuration == false)
            {
                Console.WriteLine("Duration must be greater than 0 and Numeric.");
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Duration:");
                movieDurationPrompt = Console.ReadLine();
                int.TryParse(movieDurationPrompt, out movieDuration);
                validDuration = movieDuration > 0;
                if (int.TryParse(movieDurationPrompt, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            int validMovieDuration = movieDuration;

            //Copies
            //Total copies is valid if > 0 - no empty strings will be accepeted.
            bool validCopies;
            Console.WriteLine("\nTotal Copies:");
            string movieCopiesPrompt = Console.ReadLine();
            int.TryParse(movieCopiesPrompt, out int movieCopies);
            validCopies = movieCopies > 0;
            while (validCopies == false)
            {
                Console.WriteLine("Total Copies must be greater than 0 and Numeric.");
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Total Copies:");
                movieCopiesPrompt = Console.ReadLine();
                int.TryParse(movieCopiesPrompt, out movieCopies);
                validCopies = movieCopies > 0;
                if (int.TryParse(movieCopiesPrompt, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            int validMovieCopies = movieCopies;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Movie movie = new Movie(validMovieTitle, validGenre, validClassification, validMovieDuration, validMovieCopies);
            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Movie Details==========\n\n");
                Console.WriteLine(movie.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To add this movie, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        Console.WriteLine();
                        movieCollection.Insert(movie);
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    case "n":
                        Console.WriteLine("\n Cancelling...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input - try again.");
                        break;
                }
            }
        }



        //remove dvd or movie
        public void RemoveDVDs()
        {
            Console.Clear();
            Console.WriteLine("=============Remove DVDs from a Movie in the Collection============\n");
            IMovie[] movieArray = movieCollection.ToArray();

            Console.WriteLine("Current collection of movies:\n");
            if (!movieCollection.IsEmpty())
            {
                foreach (IMovie imovie in movieArray)
                {
                    Console.WriteLine($"{imovie.ToString()}, Total Copies: " + imovie.TotalCopies);
                }
            }
            else
            {
                Console.WriteLine(" No movies exist in the movie collection.");
                Console.WriteLine("\nPress any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }
            Console.WriteLine("\n=====================================================\n");
            Console.Write("Please enter a movie title: ");
            string movie = Console.ReadLine();

            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("\nPlease enter a valid movie title (Press 0 to Exit): ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
                if (int.TryParse(smovie, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            if (validMovie.AvailableCopies > 0)
            {
                Console.Write("\nEnter number of DVDs to be removed: ");
                string DVDPrompt = Console.ReadLine();
                bool validNum = int.TryParse(DVDPrompt, out int DVDnumber);

                //Assume DVDs being borrowed cannot be deleted
                while (!validNum || !(1 <= DVDnumber && DVDnumber <= validMovie.AvailableCopies))
                {
                    Console.Write($"\nPlease enter a number between 1 and {validMovie.AvailableCopies} (Press 0 to Exit): ");
                    string prompt = Console.ReadLine();
                    validNum = int.TryParse(prompt, out DVDnumber);

                    if (int.TryParse(prompt, out int quit))
                    {
                        if (quit == 0)
                        {
                            StaffMenu();
                        }
                    }
                }
                //can delete this if u dont like
                int validNum1 = validMovie.TotalCopies - DVDnumber;
                if (validMovie.TotalCopies == 1 || validNum1 == 0)
                {
                    bool validinput = false;
                    while (!validinput)
                    {
                        Console.WriteLine("\n Warning! - Removing the last copy of a DVD from a movie will remove the movie from the collection." +
                            "\n Press 'Y' continue or Press or press 'N' to exit ");
                        string choice = Console.ReadLine();
                        choice = choice.ToLower();
                        if (choice == "y")
                        {
                            validinput = true;
                        }
                        if (choice == "n")
                        {
                            StaffMenu();
                        }
                    }
                }
                //Decrement Total Copies and Available Copies Count
                validMovie.TotalCopies = validMovie.TotalCopies - DVDnumber;
                validMovie.AvailableCopies = validMovie.AvailableCopies - DVDnumber;
                Console.WriteLine("\n============================");
                Console.WriteLine($"\n {DVDnumber} DVD copies removed from Movie '{validMovie.Title}'.\n");
                Console.WriteLine($" There are {validMovie.TotalCopies} total copies remaining for '{validMovie.Title}', " +
                                  $"with {validMovie.TotalCopies - validMovie.AvailableCopies} currently on borrow.");
            }
            else
            {
                Console.WriteLine($"\n Error - There is no available copies to remove.");
                Console.WriteLine($" There are {validMovie.TotalCopies} total copies remaining for '{validMovie.Title}', " +
                                  $"with {validMovie.TotalCopies - validMovie.AvailableCopies} currently on borrow.");
                Console.WriteLine("\nPress any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }
            if (validMovie.TotalCopies == 0)
            {
                Console.WriteLine($"\n Movie '{validMovie.Title}' has been removed from the system as there are no copies left.");
                movieCollection.Delete(validMovie);
            }
            Console.WriteLine("\n============================");
            Console.WriteLine("\nPress any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }



        //Register Member
        public void RegisterMember()
        {
            Console.Clear();
            Console.WriteLine("=================Register a Member===================\n");
            //loop till valid first name > 0
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            //this uses System.Linq - can delete if needed ( its checks if theres any numbers in first name)
            bool validfirstName = firstName.Length > 0 && firstName.Any(letter => char.IsDigit(letter)) == false;
            while (!validfirstName)
            {
                Console.Write("Please enter a valid First Name (press 0 to exit): ");
                firstName = Console.ReadLine();
                validfirstName = firstName.Length > 0 && firstName.Any(letter => char.IsDigit(letter)) == false;
                if (int.TryParse(firstName, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            //loop till valid last name > 0
            Console.Write("\nLast Name: ");
            string lastName = Console.ReadLine();
            bool validLastName = lastName.Length > 0 && lastName.Any(letter => char.IsDigit(letter)) == false;
            while (!validLastName)
            {
                Console.Write("Please enter a valid Last Name (press 0 to exit): ");
                lastName = Console.ReadLine();
                validLastName = lastName.Length > 0 && lastName.Any(letter => char.IsDigit(letter)) == false;
                if (int.TryParse(lastName, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            //loop till a valid phone number is given
            Console.Write("\nContact Number:");
            string contactNumber = Console.ReadLine();
            bool validPhoneNumber = IMember.IsValidContactNumber(contactNumber);
            while (!validPhoneNumber)
            {
                Console.Write("Please enter a valid contact number (press 0 to exit): ");
                contactNumber = Console.ReadLine();
                validPhoneNumber = IMember.IsValidContactNumber(contactNumber);
                if (int.TryParse(contactNumber, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            //loop til a valid pin is given
            Console.Write("\nPIN: ");
            string pin = Console.ReadLine();
            bool validPIN = IMember.IsValidPin(pin);
            while (!validPIN)
            {
                Console.Write("Please enter a valid pin (press 0 to exit): ");
                pin = Console.ReadLine();
                validPIN = IMember.IsValidPin(pin);
                if (int.TryParse(pin, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Create Member object with valid phone number, pin and name 
            Member validMember = new Member(firstName, lastName, contactNumber, pin);

            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Add Member ==========\n\n");
                Console.WriteLine($" First Name: {validMember.FirstName} \n Last Name: {validMember.LastName} \n Ph: { validMember.ContactNumber} \n Pin: { validMember.Pin}");
                Console.WriteLine("\n To add this member, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        if (!memberCollection.Search(validMember))
                        {
                            memberCollection.Add(validMember);
                            Console.WriteLine($"\n {validMember.FirstName} {validMember.LastName} succesfully registered.");
                        }
                        else
                        {
                            Console.WriteLine($"\n Error - {validMember.FirstName} {validMember.LastName} Member already existis.");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    case "n":
                        Console.WriteLine("\n Cancelling...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input - try again.");
                        break;
                }
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }




        //Delete Member
        public void DeleteRegisteredMember()
        {
            /* precondition: member needs to have 0 movies currently borrowed before able to be deleted */
            Console.Clear();
            Console.WriteLine("================= Delete a Registered Member ===================\n");
            if (memberCollection.IsEmpty())
            {
                Console.WriteLine(" Error - No members in the Member Collection");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                StaffMenu();

            }
            Console.WriteLine(" Members found in collection (Last name, First name):\n");
            Console.WriteLine(memberCollection.ToString());
            Console.WriteLine("=====================================================\n");
            Console.WriteLine("Please enter a valid member from the collection:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine();
            Member member = new Member(firstName, lastName);
            IMember validMember = memberCollection.Find(member);
            //bool validMember = memberCollection.Search(member);
            while (validMember == null)
            {
                Console.WriteLine("Please enter a valid member from the collection (press 0 to quit): ");
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                if (int.TryParse(firstName, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
                if (int.TryParse(lastName, out int quit1))
                {
                    if (quit1 == 0)
                    {
                        StaffMenu();
                    }
                }
                Console.WriteLine();
                member = new Member(firstName, lastName);
                validMember = memberCollection.Find(member);
                //validMember = memberCollection.Search(member);
                Console.WriteLine();
            }
            bool validInput = false;
            int counter = 0;
            IMovie[] tempArray = movieCollection.ToArray();
            //check if validmember is in any of the borrowers array for each movie in the collection
            foreach (IMovie movie in tempArray)
            {
                if (movie.Borrowers.Search(validMember))
                {
                    counter++;
                    validInput = true;
                }
            }
            if (validInput == true)
            {
                Console.WriteLine($" Error - Cannot remove '{validMember.FirstName} {validMember.LastName}' as they have DVDs on borrow.");
                Console.WriteLine($" Number of DVDs on borrow: {counter}");
                Console.WriteLine("\nPress any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Delete Member ==========\n\n");
                Console.WriteLine(" " + validMember.FirstName + "\n " + validMember.LastName + "\n Ph:" + validMember.ContactNumber + "\n Pin:" + validMember.Pin);
                Console.WriteLine("\n To DELETE this member, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        memberCollection.Delete(member);
                        Console.WriteLine($"\n {member.FirstName} {member.LastName} succesfully deleted.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    case "n":
                        Console.WriteLine("\n Cancelling...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        StaffMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input - try again.");
                        break;
                }
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }




        //Display member ph number
        public void DisplayMemberContact()
        {
            Console.Clear();
            Console.WriteLine("========= Obtain a Member's Contact Number ==========\n");
            if (memberCollection.IsEmpty())
            {
                Console.WriteLine(" Error - No members in the Member Collection");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                StaffMenu();

            }
            Console.WriteLine(" Members found in collection (Last name, First name):\n");
            Console.WriteLine(memberCollection.ToString());
            Console.WriteLine("=====================================================\n");
            Console.WriteLine("Please enter a valid member from the collection:");
            Console.Write("First Name: ");
            string memberFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string memberLastName = Console.ReadLine();

            Member temp = new Member(memberFirstName, memberLastName);
            //bool validMember = memberCollection.Search(temp);
            Console.WriteLine();
            IMember validMember = memberCollection.Find(temp);
            Console.WriteLine();
            while (validMember == null)
            {
                Console.WriteLine("Please enter a valid member from the collection (press 0 to quit): ");
                Console.Write("First Name: ");
                memberFirstName = Console.ReadLine();
                if (int.TryParse(memberFirstName, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
                Console.Write("Last Name: ");
                memberLastName = Console.ReadLine();
                if (int.TryParse(memberLastName, out int quit1))
                {
                    if (quit1 == 0)
                    {
                        StaffMenu();
                    }
                }
                temp = new Member(memberFirstName, memberLastName);
                Console.WriteLine();
                validMember = memberCollection.Find(temp);

            }
            Console.WriteLine("=============================================\n");
            Console.WriteLine($" {temp.FirstName} {temp.LastName}'s contact number is {validMember.ContactNumber}.\n");
            Console.WriteLine("=============================================\n");
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }




        //Display movies borrowed
        public void DisplayMovieBorrowers()
        {
            Console.Clear();
            Console.WriteLine("=========== Display Borrowers of a Movie ===============\n");
            IMovie[] movieArray = movieCollection.ToArray();

            Console.WriteLine(" Current collection of movies:\n");
            if (!movieCollection.IsEmpty())
            {
                foreach (IMovie imovie in movieArray)
                {
                    Console.WriteLine($"{imovie.ToString()}, Total Copies: " + imovie.TotalCopies);
                }
            }
            else
            {
                Console.WriteLine(" No movies exist in the movie collection.");
                Console.WriteLine("\nPress any key to return to the staff menu.");
                Console.ReadKey();
                StaffMenu();
            }
            Console.WriteLine("\n=====================================================\n");
            Console.Write("Please enter a movie title: ");
            string movie = Console.ReadLine();

            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("\nPlease enter a valid movie title (press 0 to quit): ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
                if (int.TryParse(smovie, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            if (validMovie.Borrowers.Number == 0)
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine($"\n No one is currently borrowing out '{validMovie.Title}'.\n");
                Console.WriteLine("=============================================\n");
            }
            else
            {
                Console.WriteLine("\n=============================================");
                Console.WriteLine($"\n List of members currently borrowing out '{validMovie.Title}':\n");
                Console.WriteLine(validMovie.Borrowers.ToString());
                Console.WriteLine("=============================================\n");
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }




        //=====================================Member Menu Methods ====================
        //Member login
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

            Member member = new Member(memberFirstName, memberLastName);
            IMember validMember = memberCollection.Find(member);

            if (validMember != null)
            {
                if (validMember.Pin == memberPIN)
                {
                    Console.WriteLine($"\n Verfication Successful - Now Logging In '{validMember.FirstName} {validMember.LastName}'.");
                    CurrentlyLoggedInUser = validMember;
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    MemberMenu();
                }
                else
                {
                    Console.WriteLine($"\n Error - Pin number is not valid for member '{validMember.FirstName} {validMember.LastName}'.");
                    Console.WriteLine("\nPress any key to return to the main menu.");
                    Console.ReadKey();
                    MainMenu();
                }
            }
            else
            {
                Console.WriteLine($"\n Error - '{memberFirstName} {memberLastName}' does not exists in this collection.");
                Console.WriteLine("\nPress any key to return to the main menu.");
                Console.ReadKey();
                MainMenu();

            }
        }



        //Browse all movies
        public void BrowseAllMovies()
        {
            Console.Clear();
            Console.WriteLine("================Browsing All Movies=================\n");
            IMovie[] movieArray = movieCollection.ToArray();
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($" There are currently no movies available.");
                Console.WriteLine("\nPress any key to return to the member menu.");
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



        //Display all movies
        public void DisplayMovieInfo()
        {
            Console.Clear();
            Console.WriteLine("================Obtain Movie Info=================\n");
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($" There are currently no movies in the movie collection.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }
            Console.WriteLine("Please enter a movie title:");
            string movie = Console.ReadLine();
            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title (press 0 to quit): ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
                if (int.TryParse(smovie, out int quit))
                {
                    if (quit == 0)
                    {
                        MemberMenu();
                    }
                }
            }
            Console.WriteLine("\n===============================");
            Console.WriteLine();
            Console.WriteLine(validMovie.ToString() + "\n");
            Console.WriteLine("===============================");
            Console.WriteLine("Press any key to return to the member menu.");
            Console.ReadKey();
            MemberMenu();
        }



        //Member borrow dvd
        public void BorrowMovie(IMember member1)
        {
            Console.Clear();
            Console.WriteLine("================ Borrow Movie =================\n");
            IMovie[] movieArray = movieCollection.ToArray();
            List<IMovie> moviesNotBorrowing = new List<IMovie>();

            int borrowCount = 0;
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($" There are currently no movies in the movie collection.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }

            //display movies currently borrowing - can delete if we want
            Console.WriteLine("Movies currently borrowing:\n");

            foreach (IMovie imovie in movieArray)
            {
                if (imovie.Borrowers.Search(member1))
                {
                    Console.WriteLine($"{imovie.ToString()}");
                    borrowCount++;
                }
                else
                {
                    moviesNotBorrowing.Add(imovie);
                }
            }

            if (borrowCount < 1)
            {
                Console.WriteLine($" {CurrentlyLoggedInUser.FirstName} {CurrentlyLoggedInUser.LastName} has no movies currently on borrow.");
            }

            //display movies that are not being borrowed - can delte if we want
            Console.WriteLine("\nMovies available for borrow:\n");
            foreach (IMovie imovie in moviesNotBorrowing)
            {
                Console.WriteLine($"{imovie.ToString()}");
            }

            Console.WriteLine("\n=====================================\n");

            if (borrowCount < 5)
            {
                Console.Write("Please enter a movie title: ");
                string movie = Console.ReadLine();
                Movie validMovie = (Movie)movieCollection.Search(movie);
                while (validMovie == null)
                {
                    Console.Write("Please enter a valid movie title (press 0 to quit): ");
                    string smovie = Console.ReadLine();
                    validMovie = (Movie)movieCollection.Search(smovie);
                    if (int.TryParse(smovie, out int quit))
                    {
                        if (quit == 0)
                        {
                            MemberMenu();
                        }
                    }
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                bool validReviewInput = false;
                while (validReviewInput == false)
                {
                    Console.Clear();
                    Console.Write("========== Confirm Borrow Movie ==========\n\n");
                    Console.WriteLine(validMovie.ToString().Replace(',', '\n'));
                    Console.WriteLine("\n To borrow this movie, press 'Y' or Press or press 'N' to exit ");
                    string choice = Console.ReadLine();
                    switch (choice.ToLower())
                    {
                        case "y":
                            if (validMovie.AddBorrower(member1) == true)
                            {
                                Console.WriteLine($"\n {validMovie.Title} has been successfully borrowed.");
                            }
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            MemberMenu();
                            break;
                        case "n":
                            Console.WriteLine("\n Cancelling...");
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            MemberMenu();
                            break;
                        default:
                            Console.WriteLine("Invalid Input - try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"\n You have {borrowCount} DVDs already borrowed. This is the Maxmimum limit.");
                Console.WriteLine(" Please return a DVD before borrowing another.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();

            }
        }



        //member return a dvd
        public void ReturnMovie(IMember member)
        {
            Console.Clear();
            Console.WriteLine("================ Return Movie =================\n");
            IMovie[] movieArray = movieCollection.ToArray();
            int borrowCount = 0;
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($" There are currently no movies in the movie collection.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }
            Console.WriteLine("Movies currently borrowing:\n");
            foreach (IMovie imovie in movieArray)
            {
                if (imovie.Borrowers.Search(member))
                {
                    Console.WriteLine($"{imovie.ToString()}");
                    borrowCount++;

                }

            }
            if (borrowCount == 0)
            {
                Console.WriteLine($" {CurrentlyLoggedInUser.FirstName} {CurrentlyLoggedInUser.LastName} has no movies currently on borrow.");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                MemberMenu();

            }
            Console.WriteLine("\n=====================================");

            Console.Write("Please enter a movie title: ");
            string movie = Console.ReadLine();
            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title (press 0 to quit): ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
                if (int.TryParse(smovie, out int quit))
                {
                    if (quit == 0)
                    {
                        MemberMenu();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("========== Confirm Return Movie ==========\n\n");
                Console.WriteLine(validMovie.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To return this movie, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        if (validMovie.RemoveBorrower(member))
                        {
                            Console.WriteLine($"\n{validMovie.Title} has been successfully returned.");
                        }
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        MemberMenu();
                        break;
                    case "n":
                        Console.WriteLine("\n Cancelling...");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        MemberMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Input - try again.");
                        break;
                }
            }
        }

        //Currently Borrowed movies of a member
        public void CurrentlyBorrowed(IMember member)
        {
            Console.Clear();
            Console.WriteLine("============= Current Borrowing Movies =============\n");
            IMovie[] movieArray = movieCollection.ToArray();
            int borrowCount = 0;
            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($" There are currently no movies in the movie collection.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }

            foreach (IMovie imovie in movieArray)
            {
                if (imovie.Borrowers.Search(member))
                {
                    Console.WriteLine($"{imovie.ToString()}");
                    borrowCount++;
                }
            }
            if (borrowCount == 0)
            {
                Console.WriteLine($" {CurrentlyLoggedInUser.FirstName} {CurrentlyLoggedInUser.LastName} has no movies currently on borrow.");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MemberMenu();
        }




        //Display to 3 borrowed movies
        public void Top3Movies()
        {
            int top3Counter = 0;
            Console.Clear();

            Console.WriteLine("============= Top 3 Borrowed Movies =============\n");
            MovieCollection Collectiontemp = movieCollection;
            IMovie[] movieArray = Collectiontemp.ToArray(); // input size
            if (movieArray == null)
            {
                Console.WriteLine($" There are currently no movies in the movie collection.");
                Console.WriteLine("\nPress any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }
            else
            {
                IMovie tempMovie = new Movie("temp");
                IMovie first, second, third;
                //need a temp movie with NoBorrowings = 0
                first = second = third = tempMovie;
                for (int i = 0; i < movieArray.Length; i++)
                {
                    if (movieArray[i].NoBorrowings > first.NoBorrowings) //basic operation
                    {
                        top3Counter++;
                        third = second;
                        second = first;
                        first = movieArray[i];
                    }
                    else if (movieArray[i].NoBorrowings > second.NoBorrowings) //basic operation
                    {
                        top3Counter++;
                        third = second;
                        second = movieArray[i];
                    }
                    else if (movieArray[i].NoBorrowings > third.NoBorrowings) //basic operation
                    {
                        top3Counter++;
                        third = movieArray[i];
                    }
                }
                if (movieArray.Length > 2)
                {

                    int j = 1;
                    if (first.NoBorrowings != 0)
                    {
                        Console.WriteLine($" {j++} - {first.Title} - Total times borrowed: {first.NoBorrowings}");
                    }
                    else
                    {
                        Console.WriteLine($" {j++} - nil");
                    }
                    if (second.NoBorrowings != 0)
                    {
                        Console.WriteLine($" {j++} - {second.Title} - Total times borrowed: {second.NoBorrowings}");
                    }
                    else
                    {
                        Console.WriteLine($" {j++} - nil");
                    }
                    if (third.NoBorrowings != 0)
                    {
                        Console.WriteLine($" {j++} - {third.Title} - Total times borrowed: {third.NoBorrowings}");
                    }
                    else
                    {
                        Console.WriteLine($" {j++} - nil");
                    }

                }
                else if (movieArray.Length == 2)
                {
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
                    Console.WriteLine($" {j++}) - nil");

                }
                else if (movieArray.Length == 1)
                {
                    int j = 1;
                    if (first.NoBorrowings != 0)
                    {
                        Console.WriteLine($" {j++}) {first.Title} - Total times borrowed: {first.NoBorrowings}");
                    }
                    else
                    {
                        Console.WriteLine($" {j++}) - nil");
                    }
                    Console.WriteLine($" {j++}) - nil");
                    Console.WriteLine($" {j++}) - nil");
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MemberMenu();
        }




        //logout a member return to main menu
        public void MemberLogout()
        {
            Console.WriteLine($"\nLogging out '{CurrentlyLoggedInUser.FirstName} {CurrentlyLoggedInUser.LastName}'");
            CurrentlyLoggedInUser = null;
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MainMenu();
        }
    }
}