using System.Net;
using System.Numerics;
using static System.Formats.Asn1.AsnWriter;

namespace Lists__n_Loops
{
    internal class Program
    {
        public static List<Item> weapons = new List<Item>
        {
            new Item("Fists",0,0),
            new Item("Sword",4,500),
            new Item("Dagger",3,400),
            new Item("Flail",5,700),
            new Item("Bayonet",6,900)
        };
        public static Random rand = new Random();
        public static Player player = new Player("Dan", 20, 5, 75, 100, 0, 1);
        public static List<Creature> monsters = new List<Creature>
        {
            new Creature("Skeleton", 20, 5,65) ,
            new Creature("Zombie", 25, 7,60) ,
            new Creature("Goblin", 14, 6,80)
        };
        static int currentMonster;

        static void Main(string[] args)
        {
            Fight();
        }

        private static void Fight()
        {
            Console.Clear();
            Console.WriteLine($"{player.name}: {player.health}");
            Console.WriteLine($"{monsters[currentMonster].name}: {monsters[currentMonster].health}");
            Console.WriteLine($"[1] Attack");
            string x = Console.ReadKey(true).KeyChar.ToString();
            if (x == "1")
            {
                player.Attack(monsters[currentMonster]);
                monsters[currentMonster].Attack(player);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Fight();
            }
            else Fight();
        }
    }
}