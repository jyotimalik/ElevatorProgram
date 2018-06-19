using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorProgram
{
    public class Elevator: IElevator
    {
        //Defaults and Declarations
        //building has n floors

        private readonly Dictionary<int,bool> _floorReady= new Dictionary<int, bool>();
        private int _currentLevel = 1;
        private readonly int _upperLevel;
        private readonly int _lowerLevel;
        private ElevatorStatus _status = ElevatorStatus.STOPPED;

        public Elevator(int lowerLevel=0,int upperLevel = 5)
        {
            CalculateFloor(lowerLevel, upperLevel);
            _upperLevel = upperLevel;
            _lowerLevel = lowerLevel;
        }

        private void CalculateFloor(int lowerLevel , int upperLevel )
        {
           
            for (int i = lowerLevel; i <= upperLevel; i++)
            {
                _floorReady.Add(i, false);
            }
           
        }

        private void Stop(int floor)
        {
            _status = ElevatorStatus.STOPPED;
            _currentLevel = floor;
            _floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        private void Descend(int floor)
        {
            for (int i = _currentLevel; i >= 1; i--)
            {
                if (_floorReady[i])
                    Stop(floor);              
            }

            _status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        private void Ascend(int floor)
        {
            for (int i = _currentLevel; i <= _upperLevel; i++)
            {
                if (_floorReady[i])
                    Stop(floor);             
            }

            _status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        void StayPut()
        {
            Console.WriteLine("That's our current floor");
        }

        public void FloorPress(int floor)
        {
            if (floor > _upperLevel)
            {
                Console.WriteLine("We only have {0} floors", _upperLevel);
                return;
            }

            if (floor <_lowerLevel)
            {
                Console.WriteLine("We only have {0} level", _lowerLevel);
                return;
            }
            _floorReady[floor] = true;

            switch (_status)
            {

                case ElevatorStatus.DOWN:
                    Descend(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (_currentLevel < floor)
                        Ascend(floor);
                    else if (_currentLevel == floor)
                        StayPut();
                    else
                        Descend(floor);
                    break;

                case ElevatorStatus.UP:
                    Ascend(floor);
                    break;
            }


        }

        public enum ElevatorStatus
        {
            UP,
            STOPPED,
            DOWN
        }
    }
}
