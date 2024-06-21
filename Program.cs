using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace final_project_C_sharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // user can't add their own essential oils
            // these are all set by me and any of them may be used in the perfume
            Oil jasmine = new Oil("jasmine", "top", "floral");
            Oil vanilla = new Oil("vanilla", "base", "sweet");
            Oil magnolia = new Oil("magnolia", "middle", "floral");
            Oil sandalwood = new Oil("sandalwood", "base", "woodsy");
            Oil cedarwood = new Oil("cedarwood", "base", "woodsy");
            Oil lily = new Oil("lily", "top", "floral");
            Oil angelWings = new Oil("angel wings", "top", "sweet");
            Oil cinnamon = new Oil("cinnamon", "middle", "earthy");
            Oil lemon = new Oil("lemon", "top", "citrusy");
            Oil orange = new Oil("orange", "middle", "citrusy");

            // creating a list that includes all the essential oils
            List<Oil> oilDatabase = new List<Oil> { jasmine, vanilla, magnolia, sandalwood,
                cedarwood, lily, angelWings, cinnamon, lemon, orange };

            // sorting the oils alphabetically
            var oilsAlphabetically = oilDatabase.OrderBy(r => r.OilName);
            foreach (Oil oil in oilsAlphabetically)
            {
                Console.WriteLine(oil.OilName);
            }
            
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

            // creating or loading a perfume
            Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
            while (true)
            {
                if (Console.ReadLine() == "N")
                {
                    Console.WriteLine("How many oils will your perfume use?");
                    List<int> dropCounts = new List<int>();        // creating a list to store drop counts from the for loop below
                    List<string> oilNames = new List<string>();    // creating a list to store list of essential oils the user chooses
                    int num1 = 3;   // set to 3 because the possible number of essential oils is 3 right now
                    bool isInteger1 = int.TryParse(Console.ReadLine(), out num1);
                    int i = 0;
                    for (i = 1; i <= num1; i++)
                    {
                        Console.WriteLine("Essential oil name:");
                        string oilIngredient = Console.ReadLine();
                        oilNames.Add(oilIngredient);  // add the ingredient to the list
                        Console.WriteLine($"Drop count of {oilIngredient} essential oil:");
                        int num2 = 0;
                        bool isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                        while (!isInteger2)
                        {
                            Console.WriteLine("Please enter a whole number:");
                            isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                        }
                        dropCounts.Add(num2);  // add the ingredient count to the list
                    }

                    // i included this part to test out that the variables from the for loop above were saved correctly
                    foreach (string oilName in oilNames)
                    {
                        Console.WriteLine(oilName);
                    }
                    foreach (var drops in dropCounts)
                    {
                        Console.WriteLine(drops);
                    }

                    // naming the perfume and writing out the full recipe
                    Console.WriteLine("What will you name your new perfume?");
                    string perfumeName = Console.ReadLine();
                    Console.WriteLine($"Congratulations! Here is your complete perfume recipe for {perfumeName}.");
                    Console.WriteLine($"{dropCounts[0]} {oilNames[0]}"); // pulling the information our by index to match the right oil with the right number of drops needed.
                    Console.WriteLine($"{dropCounts[1]} {oilNames[1]}");
                    Console.WriteLine($"{dropCounts[2]} {oilNames[2]}");
                    Console.WriteLine($"Top with 10mL of carrier oil.");

                    Perfume perfume = new Perfume($"{perfumeName}", dropCounts[0], dropCounts[1], dropCounts[2],
                        oilNames[0], oilNames[1], oilNames[2]);

                    // saving a file
                    string filePath = $@"C:\Users\aaand\source\repos\Czechitas_CSharp2_2024\{perfumeName}.json";
                    string jsonString = JsonSerializer.Serialize(perfume);
                    File.WriteAllText(filePath, jsonString);
                    Console.WriteLine("Your perfume recipe has been saved.");
                    Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");

                    // stream
                    /*
                    string filePath2 = Path.Combine(folder, "file2.txt");
                    using (StreamWriter writer = new StreamWriter(filePath2, append: true))
                    {
                        writer.WriteLine("stuff to save");
                    }
                    */

                }

                // loading a file
                else if (Console.ReadLine() == "L")
                {
                    string fileName = $"{Console.ReadLine()}.json";
                    string jsonString = File.ReadAllText(fileName);
                    Perfume serapihne = JsonSerializer.Deserialize<Perfume>(jsonString);
                    Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
                }
            }
        }
    }
}
