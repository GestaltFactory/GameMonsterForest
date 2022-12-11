using System;

namespace Game_Monster_Forest
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Master of Chaos", 100);
            int round = 0;
            while (round < 50)
            {
                Console.WriteLine("Game Stats: " + player.ToString());
                System.Threading.Thread.Sleep(1000); // wiat fir 1 second

   //             player.Heal();
                player.Explore();

                if (player.IsDead())
                {
                    Message.Danger("Game Over!");
                    break;
                }

                round++;
            }

            if (!player.IsDead())
            {
                Message.Danger("You Won the Game!");
            }

            Console.WriteLine("Final Stats: " + player.ToString());

            Console.Read();
        }
    }
}
