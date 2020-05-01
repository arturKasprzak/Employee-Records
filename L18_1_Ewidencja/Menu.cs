using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L18_1_Ewidencja
{
    static class Menu
    {
        static string pathDataSaler = @"..\..\DATA\Salers.txt";
        static string pathDataDriver = @"..\..\DATA\Drivers.txt";
        static string pathResultsSaler = @"..\..\DATA\ResultsSalers.txt";
        static string pathResultsDriver = @"..\..\DATA\ResultDrivers.txt";

        public static void StartMenu()
        {
            Console.Title = "Records of employees of company Kasprzak";
            Console.SetWindowSize(80, 15);
            Console.SetBufferSize(80, 1000);

            while (true)
            {
                int row = 5, column = 20;
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(20, 1);
                Console.Write(">>> Records of employees of company Kasprzak <<<");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(column, row++);
                Console.Write("1 - Load and calculate driver data");
                Console.SetCursorPosition(column, row++);
                Console.Write("2 - Load and calculate saler data");
                Console.SetCursorPosition(column, row++);
                Console.Write("3 - Exit");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        LoadDriver();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        LoadSaler();
                        break;
                    case ConsoleKey.Escape:
                    case ConsoleKey.D3:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }
        static void LoadDriver()
        {
            EmployeeList drivers = new EmployeeList(Department.drivers);
            drivers.Load(pathDataDriver);
            if (drivers.ShowList())
            {
                drivers.Save(pathResultsDriver);
            }
        }

        static void LoadSaler()
        {
            EmployeeList sellers = new EmployeeList(Department.sellers);
            sellers.Load(pathDataSaler);
            if (sellers.ShowList())
            {
                sellers.Save(pathResultsSaler);
            }
        }
    }
}
