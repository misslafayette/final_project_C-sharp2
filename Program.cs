using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            List<Oil> oilDatabase = new List<Oil> { jasmine, vanilla, magnolia };

            var oilsAlphabetically = oilDatabase.OrderBy(r => r.OilName);
            foreach (Oil oil in oilsAlphabetically)
            {
                Console.WriteLine(oil.OilName);
            }

            var oilsByComposition = oilDatabase.GroupBy(r => r.CompositionPart);


            var oilsByScentType = oilDatabase.GroupBy(r => r.ScentType);
            foreach (var groupOfOils in oilsByScentType)
            {
                Console.WriteLine(oilsByScentType.Key);
                foreach (Oil oil in groupOfOils)
                {
                    Console.WriteLine(oil.OilName);
                }
            }

            Perfume seraphine = new Perfume();
            seraphine.PerfumeName = "Séraphine";

            Console.WriteLine("To create a new perfume, type 'N' and press enter. To load a saved perfume, type 'L' and press enter.");
            Console.ReadLine();
            if (Console.ReadLine() == "Y")
            {
                Console.WriteLine("How many oils will your perfume use?");
                int num1 = 1;
                bool isInteger1 = int.TryParse(Console.ReadLine(), out num1);


                Console.WriteLine("Essential oil type:");
                string oil = Console.ReadLine();
                Console.WriteLine($"Essential oil {oil} drops number:");
                int num2 = 0;
                bool isInteger2 = int.TryParse(Console.ReadLine(), out num2);
                if (isInteger2)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Ending program.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }
}
