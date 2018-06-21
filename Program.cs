using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ElevatorProgram
{
    class Program
    {
        private const string Quit = "q";
        static void Main(string[] args)
        {
            IElevator elevator = new Elevator();
          
            var input = string.Empty;

            while (input != Quit)
            {
                Console.WriteLine("Please press which floor you would like to go to");
                input = Console.ReadLine();
                int floor;
                if (int.TryParse(input, out floor))
                    elevator.FloorPress(floor);
                else if (input == Quit)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");
            }
        }
    }
}
