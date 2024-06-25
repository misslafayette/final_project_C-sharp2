using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace final_project_C_sharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! Choose one of the following options to continue:");
            Console.WriteLine("List essential oils alphabetically: 'A'");
            Console.WriteLine("Group oils by composition part: 'C'");
            Console.WriteLine("> Group oils by scent type: 'S'");
            Console.WriteLine("> Create a new perfume: 'N'");
            Console.WriteLine("> Load a created perfume: 'L'");
            Console.WriteLine("> Show this message again: 'H'");

            while (true)
            {
                string choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "a":
                        AvailableOils.OrderAlphabetically();
                        break;

                    case "c":
                        AvailableOils.OrderByComposition();
                        break;

                    case "s":
                        AvailableOils.OrderByScentType();
                        break;

                    case "n":
                        Console.WriteLine("How many oils will your perfume use?");
                        List<int> dropCounts = new List<int>();
                        List<Oil> chosenOils = new List<Oil>();
                        int num1;
                        int strength = 0;

                        while (true)
                        {
                            bool isInteger1 = int.TryParse(Console.ReadLine(), out num1);
                            if (isInteger1 && num1 > 0)
                            {
                                break;
                            }
                            Console.WriteLine("Invalid input. Please enter a positive whole number.");
                        }

                        int i;
                        for (i = 1; i <= num1; i++)
                        {
                            Oil foundOil = null;
                            string oilIngredient = null;
                            while (foundOil == null)
                            {
                                Console.WriteLine("Essential oil name:");
                                oilIngredient = Console.ReadLine();
                                foundOil = AvailableOils.ListOils().FirstOrDefault(o => o.OilName.Equals(oilIngredient, StringComparison.OrdinalIgnoreCase));
                                if (foundOil != null)
                                {
                                    chosenOils.Add(foundOil);
                                }
                                else
                                {
                                    Console.WriteLine("Oil not found. Please enter a valid essential oil:");
                                }
                            }

                            int num2 = 0;
                            while (true)
                            {

                                Console.WriteLine($"Drop count of {oilIngredient} essential oil:");

                                bool isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                                if (isInteger2 && num2 > 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Please enter a positive whole number:");
                            }
                            dropCounts.Add(num2);
                            strength = strength + num2;
                        }

                        int strengthCalculated = 0;
                        strengthCalculated = PerfumeStrength.CalculateStrength(strength);

                        Console.WriteLine("What will you name your new perfume?");
                        string perfumeName = Console.ReadLine();
                        Console.WriteLine($"Congratulations! Here is your complete perfume recipe for {perfumeName}.");
                        for (i = 1; i <= num1; i++)
                        {
                            Console.WriteLine($"{dropCounts[i - 1]} {chosenOils[i - 1].OilName}");
                        }
                        Console.WriteLine($"Top with 10mL of carrier oil.");
                        Console.WriteLine($"The perfume strength is {strengthCalculated}%.");

                        Perfume perfume = new Perfume($"{perfumeName}", chosenOils);
                        Console.WriteLine();
                        Console.WriteLine("Do you wish to calculate concentration for a different volume? 'Y/N'");
                        if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            bool continuePrompting = true;
                            while (continuePrompting)
                            {
                                Console.WriteLine("Choose the volume: 5mL, 10mL, 20mL, 30mL. 'X' to return.");
                                string choice2 = Console.ReadLine();
                                switch (choice2.ToLower())

                                {
                                    case "5":
                                        int strength5 = PerfumeStrength.CalculateFor5mL(strength);
                                        Console.WriteLine($"Concentration for 5mL is {strength5}%.");
                                        break;
                                    case "10":
                                        int strength10 = PerfumeStrength.CalculateStrength(strength);
                                        Console.WriteLine($"Concentration for 10mL is {strength10}%.");
                                        break;
                                    case "20":
                                        int strength20 = PerfumeStrength.CalculateFor20mL(strength);
                                        Console.WriteLine($"Concentration for 5mL is {strength20}%.");
                                        break;
                                    case "30":
                                        int strength30 = PerfumeStrength.CalculateFor30mL(strength);
                                        Console.WriteLine($"Concentration for 5mL is {strength30}%.");
                                        break;
                                    case "x":
                                        continuePrompting = false;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid input. Try again:");
                                        continue;
                                }
                            }
                        }

                        Console.WriteLine("Do you wish to save your perfume? Y/N");
                        if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            string folder = @"C:\Users\aaand\source\repos\final_project_C-sharp2";
                            string filePath = Path.Combine(folder, $"{perfumeName}.txt");

                            if (File.Exists(filePath))
                            {
                                Console.WriteLine($"File '{perfumeName}' already exists.");
                                Console.WriteLine("Choose a different name for your perfume:");
                                perfumeName = Console.ReadLine();
                                filePath = Path.Combine(folder, $"{perfumeName}.txt");
                            }

                            using (StreamWriter writer = new StreamWriter(filePath, append: false))
                            {
                                writer.WriteLine($"{perfumeName}".ToUpper());
                                for (i = 1; i <= num1; i++)
                                {
                                    writer.WriteLine($"{dropCounts[i - 1]} {chosenOils[i - 1].OilName}");
                                }
                                writer.WriteLine($"Top with 10mL of carrier oil.");
                                writer.WriteLine($"The perfume strength is {strength}%.");
                            }
                            Console.WriteLine("Your perfume recipe has been saved.");
                        }
                        break;

                    case "l":

                        Console.WriteLine("Enter the name of the perfume you want to load:");
                        perfumeName = Console.ReadLine();
                        string folderLoad = @"C:\Users\aaand\source\repos\final_project_C-sharp2";
                        string filePathLoad = Path.Combine(folderLoad, $"{perfumeName}.txt");

                        if (File.Exists(filePathLoad))
                        {
                            using (StreamReader reader = new StreamReader(filePathLoad))
                            {
                                Console.WriteLine("Here is your recipe:");
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    Console.WriteLine(line);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"File '{perfumeName}.txt' does not exist.");
                            Console.WriteLine("Choose a different file:");
                        }
                        break;

                    case "h":
                        Console.WriteLine("Command list:");
                        Console.WriteLine("List essential oils alphabetically: 'A'");
                        Console.WriteLine("Group oils by composition part: 'C'");
                        Console.WriteLine("> Group oils by scent type: 'S'");
                        Console.WriteLine("> Create a new perfume: 'N'");
                        Console.WriteLine("> Load a created perfume: 'L'");
                        Console.WriteLine("> Show this message again: 'H'");
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        Console.WriteLine("To see list of commands, press 'H'.");
                        return;
                }
            }
        }
    }
}
