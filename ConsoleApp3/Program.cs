using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static Random rand = new Random();
        static List<int> playerHPList = new List<int> { 20, 30, 40, 50, 60, 70, 70, 70, 70, 70, 70, 70, 70, 70, 70 };
        static List<int> playerDamList = new List<int> { 7, 12, 16, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19 };
        static List<int> playerHitList = new List<int> { 75, 80, 85, 86, 87, 87, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 99};
        static int playerHealth = 20;
        static int playerDamage = 10;
        static int playerHit = 75;
        static List<int> monsterHPList = new List<int> { 20, 25, 16, 100, 500 };
        static List<int> monsterDamList = new List<int> { 7, 5, 8, 12, 50 };
        static List<string> monsterNameList = new List<string> { "Skeleton", "Zombie", "Goblin", "Massive Ogre!", "Small unassuming white rabbit"};
        static List<int> monsterHitsList = new List<int> { 65, 80, 69, 85, 90 };
        static List<int> monsterXPList = new List<int> { 10, 15, 12, 50, 80};
        static List<int> levelchecklist = new List<int> { 10, 25, 50, 85, 110, 150, 210, 280, 340, 380, 430, 490, 560 };
        static int monsterHp = 0;
        static int monsterDam = 0;
        static int monsterHit = 0;
        static string monsterName = "";
        static int monsterXP = 0;
        static int currentMonster = 0;
        static int currentLevel = 0;
        static int currentXP = 0;
        static int levelcheck = 0;
        static int dodgecount = 0;
        static int healcounter = 2;
        static void Main(string[] args)
        {
            intro();
            FindMonster();
        }

        public static void ResetInfo()
        {
            playerHealth = playerHPList[currentLevel];
            playerDamage = playerDamList[currentLevel];
            playerHit = playerHitList[currentLevel];
            monsterHp = monsterHPList[currentMonster];
            monsterDam = monsterDamList[currentMonster];
            monsterHit = monsterHitsList[currentMonster];
            monsterName = monsterNameList[currentMonster];
            monsterXP = monsterXPList[currentMonster];
            levelcheck = levelchecklist[currentLevel];
        }
        public static void intro()
        {
            Console.WriteLine("Welcome Adventurer! You find yourself in the woods, and wander down the road");
           Console.ReadKey();
            Console.Clear();
        }
        public static void FindMonster()
        {
            Console.Clear();
            if (currentLevel >= 3) currentMonster = (3);
            if (currentLevel >= 8) currentMonster = (4);
            if (currentLevel < 3) currentMonster = rand.Next(0,3);
            ResetInfo();
            Console.WriteLine($"You explore and you find... a {monsterName}!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Fight();
        }
        private static void Fight()
        {
            Console.WriteLine($"Your Health: {playerHealth}");
            Console.WriteLine($"{monsterName} Health: {monsterHp}");
            Console.WriteLine("[1] Attack");
            if (dodgecount == 0) Console.WriteLine("[2] Dodge");
            else if (dodgecount > 0) Console.WriteLine("[2] Dodge **On Cooldown**");
            Console.WriteLine($"[3] Heal ({healcounter} left)");
            string choice = Console.ReadLine();
            if (choice == "1") Attack();
            else if (choice == "2") Dodge();
            else if (choice == "3") Heal();
            else Fight();
        }

        private static void Dodge()
        {
            Console.WriteLine("You Dodge, Monster atatck reduced");
            if (dodgecount== 0) (monsterHit) = monsterHit - 10;
            if (dodgecount== 0) dodgecount = 3;
            else if (dodgecount > 0) Console.WriteLine($"You cant do that for another {dodgecount} attacks");
            Console.Clear();
            Fight();

        }
        private static void Heal()
        {
            if (healcounter > 0) Console.WriteLine("You Heal");
            if (healcounter > 0) (playerHealth) = playerHPList[currentLevel];
            if (healcounter > 0) healcounter--;
            else if (healcounter == 0) Console.WriteLine("You cant do that!");
            Console.Clear();
            Fight();
        }


                    private static void Attack()
                {
                    if (rand.Next(1, 101) <= playerHit)
                    {
                        Console.WriteLine($"You hit the {monsterName} for {playerDamage} damage");
                        monsterHp -= playerDamage;
                    }
                    else Console.WriteLine($"You Miss the {monsterName}!");
                    if (rand.Next(1, 101) <= monsterHit)
                    {
                        Console.WriteLine($"The {monsterName} hits you for {monsterDam} damage");
                        playerHealth -= monsterDam;
                    }
                    else Console.WriteLine($"The {monsterName} misses you!");
                    Console.WriteLine($"Press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    if (dodgecount > 0) dodgecount--;
                   if (monsterHp <= 0) EndFight(true);
                   else if (playerHealth <= 0) EndFight(false);
                   else Fight();
                }
        public static void EndFight(bool x)
        {
            if (x == true)
            {
                Console.WriteLine($"You have defeated the {monsterName}");
                Console.WriteLine($"You gain {monsterXP} XP!");
                currentXP += monsterXP;
                if (currentXP >= levelcheck) Console.WriteLine($"You gained a level! Your new level is {currentLevel + 1}!");
                if (currentXP >= levelcheck) currentLevel++;
                ResetInfo();
                Console.WriteLine("You continue Exploring");
                Console.WriteLine("Press Any Key to continue");
                Console.ReadKey();
                FindMonster();
            }
            else
            {
                Console.WriteLine("You died");
                Console.WriteLine("Get Gud");
                Console.ReadKey();
            }
        }
    }
}