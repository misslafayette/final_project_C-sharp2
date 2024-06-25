using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace final_project_C_sharp2
{

    public class AvailableOils
    {
        public static List<Oil> ListOils()
        {
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

            List<Oil> oils = new List<Oil>{jasmine, vanilla, magnolia, sandalwood, cedarwood,
                lily, angelWings, cinnamon, lemon, orange, rosemary};

            return oils;
        }

        public AvailableOils(List<Oil> oils)
        {
            oils = new List<Oil> { };
        }

        public static void OrderAlphabetically()
        {
            List<Oil> oilsList = ListOils();
            var oilsAlphabetically = oilsList.OrderBy(r => r.OilName);
            foreach (Oil oil in oilsAlphabetically)
            {
                Console.WriteLine(oil.OilName);
            }
        }
        public static void OrderByComposition()
        {
            List<Oil> oilsList = ListOils();
            var oilsByComposition = oilsList.GroupBy(r => r.CompositionPart);
            foreach (var groupOfOils in oilsByComposition)
            {
                Console.WriteLine(groupOfOils.Key);
                foreach (Oil oil in groupOfOils)
                {
                    Console.WriteLine(oil.OilName);
                }
            }
        }
        public static void OrderByScentType()
        {
            List<Oil> oilsList = ListOils();
            var oilsByScentType = oilsList.GroupBy(r => r.ScentType);
            foreach (var groupOfOils in oilsByScentType)
            {
                Console.WriteLine(groupOfOils.Key);
                foreach (Oil oil in groupOfOils)
                {
                    Console.WriteLine(oil.OilName);
                }
            }
        }
    }
}
