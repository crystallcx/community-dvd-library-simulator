using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301Project1
{
    class Menu
    {
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
                          "Enter your choice ==> (1/2/0) ");
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
                    case 0:
                        /*something here */
                        break;
                    default:
                        /*something here */
                        break;
                }
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
                          "Enter your choice ==> (1/2/3/4/5/6/0)");
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
                        /*something here */
                        break;
                    default:
                        /*something here */
                        break;
                }
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
                          "Enter your choice ==> (1/2/3/4/5/6/0)");
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
                        /*something here */
                        break;
                    default:
                        /*something here */
                        break;
                }
            }
        }
    }
}
