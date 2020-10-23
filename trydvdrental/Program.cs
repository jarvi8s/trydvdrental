using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;


namespace trydvdrental
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Pres any key to continue");

            ConsoleKeyInfo selection;
           
            Console.Clear();
           
           string title;
            int clientID, movieID, copyID, year;
            double price;
       


            bool exit = false;




            while (!exit)
            {
                Console.WriteLine("_______ınfo about homework______ press 9");
                Console.WriteLine("1.List of avaiable movie");
                Console.WriteLine("2.Customer rental information");
                Console.WriteLine("3.Create a new renting");
                Console.WriteLine("4.Register for return");
                Console.WriteLine("5.Create a new user");
                Console.WriteLine("6.Create a new movie");
                Console.WriteLine("7.Rental statistics");
                Console.WriteLine("8.List of overdue rental");
                Console.Write("\nEnter your selection: ");


                selection = Console.ReadKey();
                switch (selection.KeyChar)
                {

                    case '1':
                        Console.Clear();
                        Displaymovieandcopy();
                        Console.WriteLine("tryworking");
                        toMainMenu();
                        break;

                          case '2':
                        Console.Clear();
                        Console.Write("Please enter user id: ");
                        userthings.DisplayUserRentalDetail(int.Parse(Console.ReadLine()));
                        
                        toMainMenu();
                        break;

                    case '3':
                        Console.WriteLine("Create a rental\n");

                        Console.Clear();
                        Console.Write("Enter client id: ");
                        clientID = int.Parse(Console.ReadLine());
                        Console.Write("Enter copy id: ");
                        copyID = int.Parse(Console.ReadLine());
                        Console.WriteLine("rent day(YYYY-MM-DD): ");
                        string rentdate = Console.ReadLine();
                        rentthings.renting(clientID, copyID,rentdate);
                        toMainMenu();
                        break;
                           case '4':
                               Console.Clear();
                               Console.WriteLine("Enter client id: ");
                               clientID = int.Parse(Console.ReadLine());
                               Console.WriteLine("Enter copy id: ");
                               copyID = int.Parse(Console.ReadLine());
                               Console.WriteLine("Enter return date: ");
                               string returnDate = Console.ReadLine();
                               rentthings.returning(clientID, copyID, returnDate);
                        toMainMenu();
                        break;

                           case '5':
                                 Console.Clear();
                                 Console.Write("Enter client id: ");
                                 clientID = int.Parse(Console.ReadLine());
                                 userthings.CreateNewUser(clientID);
                        toMainMenu();
                        break;
                        
                           case '6':
                               Console.Clear();

                              Console.WriteLine("movie name");
                              title = Console.ReadLine();
                                 Console.Write("Enter movie id: ");
                               movieID = int.Parse(Console.ReadLine());
                               Console.Write("Enter copy id: ");
                               copyID = int.Parse(Console.ReadLine());
                        Console.WriteLine("enter year");
                        year = int.Parse(Console.ReadLine());
                                  Console.WriteLine("price");
                                price = int.Parse(Console.ReadLine());
                                
                               moviethings.CreateNewMovie(movieID, copyID,title,price,year);
                        Console.WriteLine("ADDED!")
                            ;
                        toMainMenu();
                        break;
                        
                           case '7':
                        Console.Clear();
                        Console.WriteLine("Statistics between dates\n");

                        Console.Write("Day1 (YYYY-MM-DD): ");
                        string date = Console.ReadLine();


                        statistic(date);
                        toMainMenu();

                        break;

                           case '8':
                        Console.Clear();
                        Console.WriteLine("we are working on it");
                        toMainMenu();
                        break;
                    case '9':
                        Console.Clear();
                        Console.WriteLine(@"I USED 2 TYPE CONNECTION TO DATABASE
first one from connection class secondly is directly from operation class 
i didnt do something for errors yet but they are not big deals. 
Please insert true vairables :) thank you");
                        toMainMenu();
                        break;
                          
                }
            }
        }

        private static void statistic(string date)
        {
            rentthings.statisticfromdate(date);
        }

        private static void Displaymovieandcopy()
            {
            moviethings.Displaymovieandcopy();
        }
 
        static void toMainMenu()
        {
            Console.WriteLine("\nPress Enter to Main Menu");

            Console.ReadLine();
            Console.Clear();
        }

    }
   
   
  
}
