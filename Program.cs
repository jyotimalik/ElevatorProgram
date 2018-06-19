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
        private const string QUIT = "q";
        static void Main(string[] args)
        {                      
            
            int floor;  IElevator elevator;          
          
           elevator = new Elevator();
          
            string input = string.Empty;

            while (input != QUIT)
            {
                Console.WriteLine("Please press which floor you would like to go to");

                input = Console.ReadLine();
                if (Int32.TryParse(input, out floor))
                    elevator.FloorPress(floor);
                else if (input == QUIT)
                    Console.WriteLine("GoodBye!");
                else
                    Console.WriteLine("You have pressed an incorrect floor, Please try again");
            }
        }
    }
}
