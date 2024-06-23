﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;

namespace final_project_C_sharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions { IncludeFields = true };

            // user can't add their own essential oils
            // these are all set by me and any of them may be used in the perfume
            Oil jasmine = new Oil("jasmine", "TOP", "FLORAL");
            Oil vanilla = new Oil("vanilla", "BASE", "SWEET");
            Oil magnolia = new Oil("magnolia", "MIDDLE", "FLORAL");
            Oil sandalwood = new Oil("sandalwood", "BASE", "WOODSY");
            Oil cedarwood = new Oil("cedarwood", "BASE", "WOODSY");
            Oil lily = new Oil("lily", "TOP", "FLORAL");
            Oil angelWings = new Oil("angel wings", "TOP", "SWEET");
            Oil cinnamon = new Oil("cinnamon", "MIDDLE", "EARTHY");
            Oil lemon = new Oil("lemon", "TOP", "CITRUSY");
            Oil orange = new Oil("orange", "MIDDLE", "CITRUSY");
            Oil rosemary = new Oil("rosemary", "MIDDLE", "HERBAL");

            // creating a list that includes all the essential oils
            List<Oil> oilDatabase = new List<Oil> { jasmine, vanilla, magnolia, sandalwood,
                cedarwood, lily, angelWings, cinnamon, lemon, orange };

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
                        // sorting the oils alphabetically
                        var oilsAlphabetically = oilDatabase.OrderBy(r => r.OilName);
                        foreach (Oil oil in oilsAlphabetically)
                        {
                            Console.WriteLine(oil.OilName);
                        }
                        break;

                    case "c":
                        // grouping the oils by composition of the perfume (i.e. if they form the base, middle, or top of the perfume)
                        var oilsByComposition = oilDatabase.GroupBy(r => r.CompositionPart);
                        foreach (var groupOfOils in oilsByComposition)
                        {
                            Console.WriteLine(groupOfOils.Key);
                            foreach (Oil oil in groupOfOils)
                            {
                                Console.WriteLine(oil.OilName);
                            }
                        }
                        break;

                    case "s":
                        // grouping the oils by type of smells (i.e. floral, woodsy, citrusy, etc.)
                        var oilsByScentType = oilDatabase.GroupBy(r => r.ScentType);
                        foreach (var groupOfOils in oilsByScentType)
                        {
                            Console.WriteLine(groupOfOils.Key);
                            foreach (Oil oil in groupOfOils)
                            {
                                Console.WriteLine(oil.OilName);
                            }
                        }
                        break;

                    case "n":
                        // creating a new perfume
                        Console.WriteLine("How many oils will your perfume use?");
                        List<int> dropCounts = new List<int>();        // declaring a list to store drop counts from the for loop below
                        List<Oil> chosenOils = new List<Oil>();    // declaring a list to store list of essential oils the user choo
                        int num1 = 1;
                        int strength = 0;
                        bool isInteger1 = int.TryParse(Console.ReadLine(), out num1);
                        int i = 0;
                        for (i = 1; i <= num1; i++)
                        {
                            Console.WriteLine("Essential oil name:");
                            string oilIngredient = Console.ReadLine();

                            Oil foundOil = oilDatabase.FirstOrDefault(o => o.OilName.Equals(oilIngredient, StringComparison.OrdinalIgnoreCase));
                            if (foundOil != null)
                            {
                                chosenOils.Add(foundOil); // add the ingredient to the list
                            }
                            else
                            {
                                Console.WriteLine("Oil not found. Please try again.");  // INCLUDE WHILE (TRUE) LOOP!!!!
                            }

                            Console.WriteLine($"Drop count of {oilIngredient} essential oil:");
                            int num2 = 0;
                            bool isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                            while (!isInteger2)
                            {
                                Console.WriteLine("Please enter a whole number:");
                                isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                            }
                            dropCounts.Add(num2);  // add the ingredient count to the list
                            strength = strength + num2;
                        }

                        // calculating the strength of the perfume
                        strength = PerfumeStrength.CalculateStrength(strength);

                        // naming the perfume and writing out the full recipe
                        Console.WriteLine("What will you name your new perfume?");
                        string perfumeName = Console.ReadLine();
                        Console.WriteLine($"Congratulations! Here is your complete perfume recipe for {perfumeName}.");
                        // pulling the information our by index to match the right oil with the right number of drops needed.
                        for (i = 1; i <= num1; i++)
                        {
                            Console.WriteLine($"{dropCounts[i-1]} {chosenOils[i-1].OilName}");
                        }
                        Console.WriteLine($"Top with 10mL of carrier oil.");
                        Console.WriteLine($"The perfume strength is {strength}%.");

                        Perfume perfume = new Perfume($"{perfumeName}", chosenOils);
                        Console.WriteLine();
                        Console.WriteLine("Do you wish to calculate concentration for a different volume? 'Y/N'");
                        if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            while(true)
                            {
                            Console.WriteLine("Choose the volume: 5mL, 10mL, 20mL, 30mL. 'X' to return.");
                            int volume = int.Parse(Console.ReadLine());
                            switch (volume)
                            {
                                case 5:
                                    int strength5 = PerfumeStrength.CalculateFor5mL(strength);
                                    Console.WriteLine($"Concentration for 5mL is {strength5}.");
                                    break;
                                case 10:
                                    int strength10 = PerfumeStrength.CalculateStrength(strength);
                                    Console.WriteLine($"Concentration for 10mL is {strength10}.");
                                    break;
                                case 20:
                                    int strength20 = PerfumeStrength.CalculateFor20mL(strength);
                                    Console.WriteLine($"Concentration for 5mL is {strength20}.");
                                    break;
                                case 30:
                                    int strength30 = PerfumeStrength.CalculateFor30mL(strength);
                                    Console.WriteLine($"Concentration for 5mL is {strength30}.");
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Try again:");
                                    break;
                                }
                            }
                        }

                        Console.WriteLine("Do you wish to save your perfume? Y/N");
                        if (Console.ReadLine().Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            // serialization
                            string filePathSerialize = $@"C:\Users\aaand\source\repos\final_project_C-sharp2\bin\Debug\{perfumeName}.json";
                            string jsonString2 = JsonSerializer.Serialize(perfume);
                            File.WriteAllText(filePathSerialize, jsonString2);

                            // stream
                            string filePathStream = filePathSerialize;
                            using (StreamWriter writer = new StreamWriter(filePathStream, append: true))
                            {
                                writer.WriteLine($"{dropCounts[0]} {chosenOils[0]}"); 
                                writer.WriteLine($"{dropCounts[1]} {chosenOils[1]}");
                                writer.WriteLine($"{dropCounts[2]} {chosenOils[2]}");
                                writer.WriteLine($"Top with 10mL of carrier oil.");
                                writer.WriteLine($"The perfume strength is {strength}%.");
                            }

                            Console.WriteLine("Your perfume recipe has been saved.");
                            Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
                        }
                        break;

                    case "l":
                        // deserializing a perfume from an existing file
                        Console.WriteLine("Which perfume recipe would you like to load?");
                        string fileName = $"{Console.ReadLine()}.json";
                        string fileContents;
                        using (StreamReader reader = new StreamReader(fileName))
                        {
                            fileContents = reader.ReadToEnd();
                        }
                        // deserialize the contents of the file
                        Perfume loadedPerfume = JsonSerializer.Deserialize<Perfume>(fileName);

                        // string jsonString = File.ReadAllText(fileName); 
                        Console.WriteLine($"Recipe for perfume {fileName}:");
                        // Console.WriteLine($"{loadedPerfume.Oil1Amount} {loadedPerfume.Oil1}"); 
                        // Console.WriteLine($"{loadedPerfume.Oil2Amount} {loadedPerfume.Oil2}");
                        // Console.WriteLine($"{loadedPerfume.Oil3Amount} {loadedPerfume.Oil3}");
                        Console.WriteLine($"Top with 10mL of carrier oil.");
                        //Console.WriteLine($"The perfume strength is {}%.");
                        break;
                    
                    case "h":
                        // help list
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
                        Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
                        return;
                }
            }
        }
    }
}
