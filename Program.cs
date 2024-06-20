using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace final_project_C_sharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Oil jasmine = new Oil("jasmine", "top", "floral");
            Oil vanilla = new Oil("vanilla", "base", "sweet");
            Oil magnolia = new Oil("magnolia", "middle", "floral");
            Oil sandalwood = new Oil("sandalwood", "base", "woodsy");
            Oil cedarwood = new Oil("cedarwood", "base", "woodsy");
            Oil lily = new Oil("lily", "top", "floral");
            Oil angelWings = new Oil("angel wings", "top", "sweet");
            Oil cinnamon = new Oil("cinnamon", "middle", "earthy");
            Oil lemon = new Oil("lemon", "top", "citrusy");

            List<Oil> oilDatabase = new List<Oil> { jasmine, vanilla, magnolia, sandalwood, cedarwood, lily, angelWings, cinnamon, lemon };

            var oilsAlphabetically = oilDatabase.OrderBy(r => r.OilName);
            foreach (Oil oil in oilsAlphabetically)
            {
                Console.WriteLine(oil.OilName);
            }

            
           var oilsByComposition = oilDatabase.GroupBy(r => r.CompositionPart);
            foreach (var groupOfOils in oilsByComposition)
            {
                Console.WriteLine(groupOfOils.Key);
                foreach (Oil oil in groupOfOils)
                {
                    Console.WriteLine(oil.OilName);
                }
            }

            var oilsByScentType = oilDatabase.GroupBy(r => r.ScentType);
            foreach (var groupOfOils in oilsByScentType)
            {
                Console.WriteLine(groupOfOils.Key);
                foreach (Oil oil in groupOfOils)
                {
                    Console.WriteLine(oil.OilName);
                }
            }
           

            Perfume seraphine = new Perfume();
            seraphine.PerfumeName = "Séraphine";

            Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
            if (Console.ReadLine() == "N")
            {
                Console.WriteLine("How many oils will your perfume use?");
                int num1 = 3;    // setting this variable to 3 on purpose, each perfume needs a base, middle, and top note, so this is the minimum
                bool isInteger1 = int.TryParse(Console.ReadLine(), out num1);
                int i = 0;
                for (i = 1; i <= num1; i++)
                {
                    Console.WriteLine("Perfume:");
                    string oilIngredient = Console.ReadLine();
                    Console.WriteLine($"Drop count of {oilIngredient} essential oil:");
                    int num2 = 0;
                    bool isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                    while (!isInteger2)
                    {
                        Console.WriteLine("Please enter a whole number:");
                        isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                    }

                }

                Console.WriteLine("What will you name your new perfume?");
                string perfumeName = Console.ReadLine();
                Console.WriteLine($"Congratulations! Here is your complete perfume recipe for {perfumeName}.");
                
                // saving a file, serialization
                string folder = @"C:\Users\aaand\source\repos\Czechitas_CSharp2_2024";
                string filePath = Path.Combine(folder, "file1.txt");
                File.WriteAllText(filePath, "");

                // stream
                string filePath2 = Path.Combine(folder, "file2.txt");
                using (StreamWriter writer = new StreamWriter(filePath2, append: true))
                {
                    writer.WriteLine("stuff to save");
                }
                Console.WriteLine("Your perfume recipe has been saved.");

                //serializace
                /*
                string filePath3 = Path.Combine(folder, "file3.txt");
                JsonSerializer serializer = new JsonSerializer(typeof(List<Oil>));
                using (StreamWriter writer2 = new StreamWriter(filePath3, append: true))
                {
                    serializer.Serialize(writer2, oilDatabase);
                }*/

            }

            // deserializace
            else if (Console.ReadLine() == 
                "L")
            {
                
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }
}
