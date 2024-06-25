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
            Oil sandalwood = new Oil("sandalwood", "BASE", "WOODY");
            Oil cedarwood = new Oil("cedarwood", "BASE", "WOODY");
            Oil lily = new Oil("lily", "TOP", "FLORAL");
            Oil angelWings = new Oil("angel wings", "TOP", "SWEET");
            Oil cinnamon = new Oil("cinnamon", "MIDDLE", "EARTHY");
            Oil lemon = new Oil("lemon", "TOP", "CITRUSY");
            Oil orange = new Oil("orange", "MIDDLE", "CITRUSY");
            Oil rosemary = new Oil("rosemary", "MIDDLE", "HERBAL");
            Oil ginger = new Oil("ginger", "BASE", "SPICY");
            Oil patchouli = new Oil("patchouli", "BASE", "EARTHY");
            Oil ylangYlang = new Oil("ylang ylang", "BASE", "FLORAL");
            Oil bergamot = new Oil("bergamot", "MIDDLE", "CITRUSY");
            Oil vetiver = new Oil("vetiver", "MIDDLE", "WOODY");
            Oil petitgrain = new Oil("petitgrain", "BASE", "SWEET");
            Oil frankincense = new Oil("frankincense", "BASE", "WOODY");
            Oil anise = new Oil("anise", "MIDDLE", "SPICY");
            Oil basil = new Oil("basil", "MIDDLE", "HERBAL");
            Oil neroli = new Oil("neroli", "TOP", "CITRUSY");
            Oil geranium = new Oil("geranium", "TOP", "FLORAL");
            Oil spearmint = new Oil("spearmint", "MIDDLE", "SPICY");
            Oil birch = new Oil("birch", "MIDDLE", "WOODY");
            Oil lemongrass = new Oil("lemongrass", "TOP", "CITRUSY");
            Oil fir = new Oil("fir", "BASE", "WOODY");
            Oil rose = new Oil("rose", "MIDDLE", "FLORAL");
            Oil teaTree = new Oil("tea tree", "MIDDLE", "SPICY");
            Oil blackPepper = new Oil("black pepper", "MIDDLE", "SPICY");
            Oil cardamom = new Oil("cardamom", "MIDDLE", "SWEET");
            Oil oregano = new Oil("oregano", "MIDDLE", "HERBAL");
            Oil chamomile = new Oil("chamomile", "TOP", "FLORAL");
            Oil spruce = new Oil("spruce", "BASE", "WOODY");
            Oil grapefruit = new Oil("grapefruit", "BASE", "CITRUSY");
            Oil rosehip = new Oil("rosehip", "MIDDLE", "HERBAL");
            Oil citronella = new Oil("citronella", "TOP", "CITRUSY");
            Oil thyme = new Oil("thyme", "MIDDLE", "HERBAL");
            Oil yarrow = new Oil("yarrow", "MIDDLE", "SWEET");
            Oil myrrh = new Oil("myrrh", "BASE", "SPICY");
            Oil clarySage = new Oil("clary sage", "MIDDLE", "HERBAL");
            Oil lavender = new Oil("lavender", "MIDDLE", "HERBAL");
            Oil clove = new Oil("clove", "MIDDLE", "SPICY");
            Oil wintergreen = new Oil("wintergreen", "TOP", "SPICY");
            Oil mandarin = new Oil("mandarin", "MIDDLE", "CITRUSY");
            Oil coriander = new Oil("coriander", "MIDDLE", "HERBAL");
            Oil cypress = new Oil("cypress", "BASE", "WOODY");
            Oil nutmeg = new Oil("nutmeg", "BASE", "SPICY");
            Oil peppermint = new Oil("peppermint", "MIDDLE", "SPICY");
            Oil eucalyptus = new Oil("eucalyptus", "MIDDLE", "SPICY");

            List<Oil> oils = new List<Oil>{jasmine, vanilla, magnolia, sandalwood, cedarwood,
                lily, angelWings, cinnamon, lemon, orange, rosemary, ginger, patchouli, ylangYlang,
                bergamot, vetiver, petitgrain, frankincense, anise, basil, neroli, geranium, spearmint,
                birch, lemongrass, fir, rose, teaTree, blackPepper, cardamom, oregano, chamomile, spruce,
                grapefruit, rosehip, citronella, thyme, yarrow, myrrh, clarySage, lavender, clove,
                wintergreen, mandarin, coriander, cypress, nutmeg, peppermint, eucalyptus};

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
