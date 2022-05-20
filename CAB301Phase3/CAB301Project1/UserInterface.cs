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
            Movie movie2 = new Movie("Die Hard", MovieGenre.Action, MovieClassification.G, 65, 6);
            Movie movie3 = new Movie("Willy Wonker", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie4 = new Movie("Lord of the Rings", MovieGenre.Action, MovieClassification.G, 65, 3);
            Movie movie5 = new Movie("The Clone Wars", MovieGenre.Action, MovieClassification.G, 65, 3);
            movieCollection.Insert(movie1);
            movieCollection.Insert(movie2);
            movieCollection.Insert(movie3);
            movieCollection.Insert(movie4);
            movieCollection.Insert(movie5);

            Member member1 = new Member("Aone", "Onelast", "0404444544", "4837"); //3
            Member member2 = new Member("Btwo", "Twolast", "0404234444", "4837"); //5
            Member member3 = new Member("Cthree", "Threelast", "0404445674", "4837"); //4
            Member member4 = new Member("Dfour", "Fourlast", "0423444444", "4837"); //2
            Member member5 = new Member("five", "Fivelast", "0404444554", "4837"); //1
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
                        DeleteRegisteredMember();
                        break;
                    case 5:
                        DisplayMemberContact();
                        break;
                    case 6:
                        DisplayMovieBorrowers();
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
            Member member1 = new Member("Aone", "Onelast", "0404444544", "4837"); //3

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
                        BorrowMovie(member1);/*something here */
                        break;
                    case 4:
                        ReturnMovie(member1);/*something here */
                        break;
                    case 5:
                        CurrentlyBorrowed(member1);/*something here */
                        break;
                    case 6:
                        Top3Movies();/*something here */
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
            //A title is valid if its length is greater than 1 - no empty stings will be accepeted
            Console.WriteLine("Title:");
            string movieTitlePrompt = Console.ReadLine();
            bool validTitleChecker = movieTitlePrompt.Length > 0;
            while(validTitleChecker == false)
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
                if (int.TryParse(movieTitlePrompt, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            int validMovieDuration = movieDuration;

            //Copies
            //Available copies is valid if > 0 - no empty strings will be accepeted.
            bool validCopies;
            Console.WriteLine("\nAvailable Copies:");
            string movieCopiesPrompt = Console.ReadLine();
            int.TryParse(movieCopiesPrompt, out int movieCopies);
            validCopies = movieCopies > 0;
            while (validCopies == false)
            {
                Console.WriteLine("Available Copies must be greater than 0 and Numeric.");
                Console.WriteLine("\nInvalid Input, Try again. Press 0 to exit.");
                Console.WriteLine("Available Copies:");
                movieCopiesPrompt = Console.ReadLine();
                int.TryParse(movieCopiesPrompt, out movieCopies);
                validCopies = movieCopies > 0;
                if (int.TryParse(movieTitlePrompt, out int quit))
                {
                    if (quit == 0)
                    {
                        StaffMenu();
                    }
                }
            }
            int validMovieCopies = movieCopies;


            //add temp movie object
            Movie movie = new Movie(validMovieTitle, validGenre, validClassification, validMovieDuration, validMovieCopies);


            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while(validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Movie Details==========\n\n");
                Console.WriteLine(movie.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To add this movie, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch(choice.ToLower())
                {
                    case "y":
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













        public void RemoveDVDs()
        {
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
            Console.WriteLine("=====================================================\n");
            Console.Write("Please enter a movie title: ");
            string movie = Console.ReadLine();

            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title: ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
            }
            Console.Write("Enter number of DVDs to be removed:");
            string DVDPrompt = Console.ReadLine();
            bool validNum = int.TryParse(DVDPrompt, out int DVDnumber);

            //Assume DVDs being borrowed cannot be deleted
            while (!validNum || !(0 <= DVDnumber && DVDnumber <= validMovie.AvailableCopies))
            {
                Console.Write($"Please enter a number between 0 and {validMovie.AvailableCopies}: ");
                string prompt = Console.ReadLine();
                validNum = int.TryParse(prompt, out DVDnumber);
            }

            //Decrement Total Copies and Available Copies Count
            validMovie.TotalCopies = validMovie.TotalCopies - DVDnumber;
            validMovie.AvailableCopies = validMovie.AvailableCopies - DVDnumber;
            Console.WriteLine($"{DVDnumber} DVD copies removed from Movie {validMovie.Title}.");
            Console.WriteLine($"There are {validMovie.TotalCopies} total copies remaining for {validMovie.Title}, "+
                              $"with {validMovie.TotalCopies - validMovie.AvailableCopies} currently on borrow.");

            if (validMovie.TotalCopies == 0)
            {
                Console.WriteLine($"Movie {validMovie.Title} has been removed from the system as there are no copies left.");
                movieCollection.Delete(validMovie);
            }

            Console.WriteLine("\nPress any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

<<<<<<< HEAD










        public void RemoveMoviefromCollection()
=======
        /* public void RemoveMoviefromCollection()
>>>>>>> 5f0c655cd2ff70e4f51a05e661d563d7841d78f1
        {
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
                Console.WriteLine();
                Movie movie = (Movie)movieCollection.Search(movieTitlePrompt);
                if (movie != null)
                {
                    //Review input
                    // y for yes, n for no.
                    bool validReviewInput = false;
                    while (validReviewInput == false)
                    {
                        if (movie.TotalCopies == movie.AvailableCopies)
                        {
                            Console.Clear();
                            Console.Write("========== Confirm Delete Movie ==========\n\n");
                            Console.WriteLine(movie.ToString().Replace(',', '\n'));
                            Console.WriteLine("\n To DELETE this movie, press 'Y' or Press or press 'N' to exit ");
                            string choice = Console.ReadLine();
                            switch (choice.ToLower())
                            {
                                case "y":
                                    Console.WriteLine($"\n{movie.Title} has successfully been deleted from the movie collection.");
                                    movieCollection.Delete(movie);
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
                        else
                        {
                            Console.WriteLine($"Unable to Delete {movie.Title} - Copies of the movie are currently rented out.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            StaffMenu();
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Movie {movieTitlePrompt} does not exist in the movie collection, please try again or enter 0 to quit.");
                    Console.WriteLine("Enter the title of the movie to be removed:");
                    if (movieTitlePrompt == "0")
                        StaffMenu();
                }
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
<<<<<<< HEAD
        }
        








        //Resgtier Member method to register a member with the system
=======
        } */

>>>>>>> 5f0c655cd2ff70e4f51a05e661d563d7841d78f1
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

            //loop till a valid phone number is given
            while (!validPhoneNumber)
            {
                Console.Write("Please enter a valid contact number: ");
                string input = Console.ReadLine();
                member.ContactNumber = input;
                if (IMember.IsValidContactNumber(member.ContactNumber))
                    validPhoneNumber = true;
            }

            //loop til a valid pin is given
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

            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Add Member ==========\n\n");
                Console.WriteLine(validMember.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To add this member, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        memberCollection.Add(validMember);
                        Console.WriteLine($"{validMember.FirstName} {validMember.LastName} succesfully registered.");
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













        public void DeleteRegisteredMember()
        {
            /* precondition: member needs to have 0 movies currently borrowed before able to be deleted */
            Console.Clear();
            Console.WriteLine("=================Delete a Registered Member===================\n");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine();
            Member member = new Member(firstName, lastName);
            bool validMember = memberCollection.Search(member);
            while (!validMember)
            {

                Console.Write("First Name: ");
                firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
                //may need to add here to break out of loop
                Console.WriteLine();
                member = new Member(firstName, lastName);
                validMember = memberCollection.Search(member);
            }
            //Review input
            // y for yes, n for no.
            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("==========Confirm Delete Member ==========\n\n");
                Console.WriteLine(member.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To DELETE this member, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        memberCollection.Delete(member);
                        Console.WriteLine($"{member.FirstName} {member.LastName} succesfully deleted.");
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










        public void DisplayMemberContact() 
        {
            Console.Clear();
            Console.WriteLine("========= Obtain a Member's Contact Number ==========");
            Console.WriteLine(memberCollection.ToString());
            Console.WriteLine("=====================================================\n");
            Console.Write("Please enter a member's first name:");
            string memberFirstName = Console.ReadLine();
            Console.Write("Please enter a member's last name:");
            string memberLastName = Console.ReadLine();

            Member temp = new Member(memberFirstName, memberLastName);
            bool validMember = memberCollection.Search(temp);

            while(!validMember)
            {
                Console.Write("Please enter an existing member's first name:");
                string firstName = Console.ReadLine();
                Console.Write("Please enter an existing member's last name:");
                string lastName = Console.ReadLine();
                //may need to add here to break out of loop
                Console.WriteLine();
                temp = new Member(firstName, lastName);
                validMember = memberCollection.Search(temp);
            }

            string contactNo = memberCollection.Find(temp).ContactNumber;
            Console.WriteLine($"{temp.FirstName} {temp.LastName}'s contact number is {contactNo}.\n");

            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }








        public void DisplayMovieBorrowers() /*in progress*/
        {
            Console.Clear();
            Console.WriteLine("=========== Display Borrowers of a Movie ===============\n");
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
            Console.WriteLine("=====================================================\n");
            Console.Write("Please enter a movie title: ");
            string movie = Console.ReadLine();

            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title: ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
            }

            if(validMovie.Borrowers.Number == 0)
            {
                Console.WriteLine($"\nNo one is currently borrowing out {validMovie.Title}.");
            }
            else
            {
                Console.WriteLine($"\nList of members currently borrowing out {validMovie.Title}:");
                Console.WriteLine(validMovie.Borrowers.ToString());
            }
            Console.WriteLine("Press any key to return to the staff menu.");
            Console.ReadKey();
            StaffMenu();
        }

<<<<<<< HEAD










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
=======
>>>>>>> 5f0c655cd2ff70e4f51a05e661d563d7841d78f1
















        public void MemberLogin()
        {
            Console.Clear();
            Console.WriteLine("=========Member Login==========");
            Console.WriteLine("Please enter first name:");

            string memberFirstName = Console.ReadLine();            

            //string memberFirstName = Console.ReadLine();

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
            string movie = Console.ReadLine();
            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title: ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
            }

            Console.WriteLine(validMovie.ToString() + "\n");

            Console.WriteLine("Press any key to return to the member menu.");
            Console.ReadKey();
            MemberMenu();
        }

<<<<<<< HEAD






        public void BrowseAllMovies1()
=======
        public void BrowseAllMovies1() /* what's this? */
>>>>>>> 5f0c655cd2ff70e4f51a05e661d563d7841d78f1
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

        public void BorrowMovie(Member member)
        {
            Console.Clear();
            Console.WriteLine("================ Borrow Movie =================\n");
            Console.WriteLine("Please enter a movie title:");
            string movie = Console.ReadLine();
            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title: ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
            }


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
                        if (!validMovie.Borrowers.Search(member))
                        {
                            Console.WriteLine($"\n{validMovie.Title} has been successfully borrowed.");
                            validMovie.AddBorrower(member);
                        }
                        else
                        {
                            Console.WriteLine($"You already have {validMovie.Title} on borrow.");
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

        public void ReturnMovie(Member member)
        {
            Console.Clear();
            Console.WriteLine("================ Return Movie =================\n");
            Console.Write("Please enter a movie title:");
            string movie = Console.ReadLine();
            Movie validMovie = (Movie)movieCollection.Search(movie);
            while (validMovie == null)
            {
                Console.Write("Please enter a valid movie title: ");
                string smovie = Console.ReadLine();
                validMovie = (Movie)movieCollection.Search(smovie);
            }

            bool validReviewInput = false;
            while (validReviewInput == false)
            {
                Console.Clear();
                Console.Write("========== Confirm Borrow Movie ==========\n\n");
                Console.WriteLine(validMovie.ToString().Replace(',', '\n'));
                Console.WriteLine("\n To return this movie, press 'Y' or Press or press 'N' to exit ");
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "y":
                        if (validMovie.Borrowers.Search(member))
                        {
                            Console.WriteLine($"\n{validMovie.Title} has been successfully returned.");
                            validMovie.RemoveBorrower(member);
                        }
                        else
                        {
                            Console.WriteLine($"You don't have {validMovie.Title} on borrow to return.");
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

        public void CurrentlyBorrowed(Member member)
        {
            Console.Clear();
            Console.WriteLine("============= Current Borrowing Movies =============\n");
            IMovie[] movieArray = movieCollection.ToArray();

            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($"There are currently no movies in the movie collection.");
                Console.WriteLine("Press any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }

            foreach (IMovie imovie in movieArray)
            {
                if(imovie.Borrowers.Search(member))
                    Console.WriteLine($"{imovie.ToString()}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MemberMenu();
        }

        public void Top3Movies()
        {
            Console.Clear();
            Console.WriteLine("============= Top 3 Borrowed Movies =============\n");
            IMovie[] movieArray = movieCollection.ToArray();

            if (movieCollection.IsEmpty())
            {
                Console.WriteLine($"There are currently no movies in the movie collection.");
                Console.WriteLine("Press any key to return to the member menu.");
                Console.ReadKey();
                MemberMenu();
            }

            foreach (IMovie imovie in movieArray)
            {
                    Console.WriteLine($"{imovie.Title} has been borrowed a number of {imovie.NoBorrowings} times.");
            }


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            MemberMenu();
        }


    }
}
