using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GrandCircusLab9
{
    class Program
    {
        static void Main()
        {
            List<string> names = new List<string>
            {"Michael Hern", "Taylor Everts","Joshua Zimmerman","Lin-Z Chang", "Madelyn Hilty", "Nana Banahene", "Rochelle Toles", "Shah Shahid",
             "Tim Broughton", "Abby Wessels", "Blake Shaw", "Bob Valentic","Jordan Owiesny", "Jay Stiles", "Jon Shaw"};

            List<string> hometown = new List<string>
            { "Canton, MI", "Caro, MI", "Taylor, MI", "Toledo, OH", "Oxford, MI", "Guana" , "Mars", "Newark, NJ", "Detroit, MI",
              "Traverse City, MI", "Los Angeles, CA", "St. Clair Shores, MI", "Warren, MI", "Macomb, MI", "Huntington Woods, MI"};

            List<string> favFood = new List<string>
            { "Chicken Wings", "Cordon Bleu", "Turkey", "Ice Cream", "Croissents", "Empanadas", "Space Cheese", "Chicken Wings",
              "Chicken Parm", "Soup",  "Cannolis", "Pizza", "Burgers" , "Pickles", "Ribs"};

            List<string> favColor = new List<string>
            { "Blue", "Green", "Blue", "Pink", "Purple", "Yellow", "Green", "Red", "Orange", "Gold", "Red", "Blue", "Orange", "Yellow", "Blue"};

          
            string goAgain = "yes";
            Console.WriteLine("Welcome to our C# class!");
            while (goAgain == "yes" || goAgain == "y")
            {
                AlphabetizeLists(ref names, ref hometown, ref favFood, ref favColor);
                string actionChoice = GetActionChoice("\nWould you like to add a student, get information about a student, or see the list of students? (Type \"add\", \"get\", or \"list\"): ", "add", "get", "list");
                if (actionChoice == "get")
                {
                    int studentNumber = GetStudentNumber("Which student would you like to learn about? (Enter a number 1-"+names.Count+" or type \"list\" to see list of students): ", ref names);
                    GetTownFoodColorChoice(studentNumber, ref names, ref hometown, ref favFood, ref favColor);
                    goAgain = GoAgain("Would you like to continue? (enter \"yes\" or \"no\"): ");
                }
                else if (actionChoice == "list")
                    ShowStudentList(names);
                else
                {
                    AddStudentInfo(ref names, ref hometown, ref favFood, ref favColor);
                    Console.WriteLine("\nStudent information has been added!");
                }
                  
            } 

            Console.WriteLine("\nGood Bye!");
            Console.ReadKey();
        }

        static void AddStudentInfo(ref List<string> names, ref List<string> hometowns, ref List<string> foods, ref List<string> colors)
        {
            string name = CheckForBlank("Please provide the student's name: ");
            names.Add(name);

            string hometown = CheckForBlank("Please provide the student's hometown: ");
            hometowns.Add(hometown);

            string food = CheckForBlank("Please provide the student's favorite food: ");
            foods.Add(food);

            string color = CheckForBlank("Please provide the student's favorite color: ");
            colors.Add(color);

        }

        static string GetActionChoice(string message, string choice1, string choice2, string choice3)
        {
            Console.Write(message);
            string action = Console.ReadLine().ToLower().Trim();
            while(action != choice1 && action != choice2 && action != choice3)
            {
                Console.Write("Invalid choice. Try again.");
                Console.Write(message);
                action = Console.ReadLine().ToLower().Trim();
            }
            return action;
        }

        static void ShowStudentList(List<string> names)
        {
            for(int i = 0; i < names.Count; i++)
                Console.WriteLine((i+1)+": "+names[i]);
        }

        static int GetStudentNumber(string message, ref List<string> names)
        {
            while (true)
            {
                try
                {
                    Console.Write(message);
                    var choice = Console.ReadLine();
                    int studentNumber;
                    if (int.TryParse(choice, out studentNumber))
                    {
                        studentNumber -= 1;
                        Console.Write("Student " + (studentNumber + 1) + " is " + names[studentNumber] + ". What would you like to know about " + names[studentNumber].Split()[0] + "? (enter \"hometown\", \"favorite food\" or \"favorite color\"): ");
                        return studentNumber;
                    }
                    else if (choice.ToLower().Trim() == "list")
                        ShowStudentList(names);
                    else if (choice.ToLower().Trim() == "")
                        Console.Write("You did not provide any information. ");
                    else
                        throw new FormatException();
                }
                catch (FormatException)  
                {
                    
                    Console.Write("Only integer choices please. Try again. Enter a number 1-"+names.Count+": ");
                }
                catch (ArgumentOutOfRangeException)  
                {
                    Console.Write("That student does not exist. Please try again. Enter a number 1-"+names.Count+": ");
                }
            }
        }




   
        static void GetTownFoodColorChoice(int studentNumber, ref List<string> names, ref List<string> hometowns, ref List<string> foods, ref List<string> colors)  //Method that determines if the user wants to know the student's hometown or fav food and writes the appropriate response to the console.
        {
            string choice = ValidateChoice(Console.ReadLine().ToLower().Trim());
            string knowMore = "yes";
            
            while (knowMore == "yes" || knowMore == "y")
            {
                if (choice == "hometown" || choice == "town")
                {
                    
                    Console.Write(names[studentNumber].Split()[0] + " is from " + hometowns[studentNumber] + ". ");
                    knowMore = GoAgain("Would you like to know more? (enter \"yes\" or \"no\"): ");
                }
                else if (choice == "favorite food" || choice == "food")
                {
                    Console.Write(names[studentNumber].Split()[0] + "'s favorite food is " + foods[studentNumber] + ". ");
                    knowMore = GoAgain("Would you like to know more? (enter \"yes\" or \"no\"): ");
            
                }
                else
                {
                    Console.Write(names[studentNumber].Split()[0] + "'s favorite color is " + colors[studentNumber] + ". ");
                    knowMore = GoAgain("Would you like to know more? (enter \"yes\" or \"no\"): ");
                }
                if (knowMore == "yes" || knowMore == "y")
                {
                    Console.Write("What else would you like to learn about " + names[studentNumber].Split()[0] + "? (enter \"hometown\", \"favorite food\" or \"favorite color\"): ");
                    choice = ValidateChoice(Console.ReadLine().ToLower().Trim());
                }
            }
        }



        static string GoAgain(string message)  //Method that determines if the user wants to make another selection
        {
            Console.Write(message);
            string goAgain = Console.ReadLine().ToLower().Trim();
            while (goAgain != "yes" && goAgain != "y" && goAgain != "no" && goAgain != "n")
            {
                Console.Write("Invalid choice. "+message+" (enter \"yes\" or \"no\"): ");
                goAgain = Console.ReadLine().ToLower().Trim();
            }
            return goAgain;
        }


        static string ValidateChoice(string choice)
        {
            while (choice != "hometown" && choice != "town" && choice != "favorite food" && choice != "food" && choice != "favorite color" && choice != "color")
            {
                Console.Write("That data does not exist.  Please try again. Enter \"hometown\", \"favorite food\", or \"favorite color\"): ");
                choice = Console.ReadLine().ToLower().Trim();
            }
            return choice;
        }

        static string CheckForBlank(string message)
        {
            Console.Write(message);
            string answer = Console.ReadLine();
            while (answer.Trim() == "")
            {
                Console.Write("You did not provide any information.  Please provide the student's name: ");
                answer = Console.ReadLine();
            }
            return answer;
        }

        static void AlphabetizeLists(ref List<string> names, ref List<string> hometowns, ref List<string> foods, ref List<string> colors)
        {
            List<string> namesCopy = new List<string>(names);
            List<string> hometownsCopy = new List<string>();
            List<string> foodsCopy = new List<string>();
            List<string> colorsCopy = new List<string>();
            namesCopy.Sort();

            for(int i = 0; i < namesCopy.Count; i++)
            {
                hometownsCopy.Add(hometowns[names.IndexOf(namesCopy[i])]);
                foodsCopy.Add(foods[names.IndexOf(namesCopy[i])]);
                colorsCopy.Add(colors[names.IndexOf(namesCopy[i])]);
            }

            names = namesCopy;
            hometowns = hometownsCopy;
            foods = foodsCopy;
            colors = colorsCopy;

        }

    }


}






    


