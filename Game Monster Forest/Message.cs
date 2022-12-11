using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Monster_Forest
{
    public static class Message
    {
        public static void Danger(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        public static void Warning(string message)
        {
            Print(message, ConsoleColor.Yellow);
        }

        public static void Success(string message)
        {
            Print(message, ConsoleColor.Green);
        }

        private static void Print(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
