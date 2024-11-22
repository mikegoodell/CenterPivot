using Pivot.Model;
using System;

namespace Pivot
{
    class Program
    {
        static void Main(string[] args)
        {
            IIrrigationHardware hardware = new SimulatedHardware(); // Change to RealHardware() for actual hardware
            CenterPivotIrrigation irrigationSystem = new CenterPivotIrrigation(hardware);

            Console.WriteLine("Center Pivot Irrigation Control System");
            Console.WriteLine("1. Home Position");
            Console.WriteLine("2. Turn On");
            Console.WriteLine("3. Turn Off");
            Console.WriteLine("4. Set Speed");
            Console.WriteLine("5. Exit");

            while (true)
            {
                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        irrigationSystem.MoveHomePosition();
                        break;
                    case 2:
                        irrigationSystem.TurnOn();
                        break;
                    case 3:
                        irrigationSystem.TurnOff();
                        break;
                    case 4:
                        Console.Write("Enter speed (0-100): ");
                        int speed = int.Parse(Console.ReadLine());
                        irrigationSystem.SetSpeed(speed);
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    public interface IIrrigationHardware
    {
        void UpdatePivotStatus();    // Update pivot status metrics
        Decimal GetPivotPosition();  // Returns current pivot position, 0-359 degrees, -1=fault
        void MoveHomePosition();     // Move pivot to home position (0 degrees)
        void TurnOn();
        void TurnOff();
        void SetSpeed(int speed);
    }

    public class RealHardware : IIrrigationHardware
    {
        public PivotConfig pivotConfig = null;
        public PivotStatus pivotStatus = null;

        public RealHardware()
        {
            pivotConfig = new PivotConfig();

            pivotConfig.Load();

            pivotStatus = new PivotStatus();
        }

        public void UpdatePivotStatus()
        {
            Console.WriteLine("Real hardware: Update pivotStatus.");
            // Code to interface with actual hardware
        }

        public Decimal GetPivotPosition()
        {
            UpdatePivotStatus();
            return pivotStatus.RotationSensorDegrees;
        }

        public void MoveHomePosition()
        {
            Console.WriteLine("Real hardware: Aligning pivot to home position.");
            // Code to interface with actual hardware

        }
        public void TurnOn()
        {
            Console.WriteLine("Real hardware: Turning on irrigation system.");
            // Code to interface with actual hardware
        }

        public void TurnOff()
        {
            Console.WriteLine("Real hardware: Turning off irrigation system.");
            // Code to interface with actual hardware
        }

        public void SetSpeed(int speed)
        {
            Console.WriteLine($"Real hardware: Setting irrigation speed to {speed}%.");
            // Code to interface with actual hardware
        }
    }

    public class SimulatedHardware : IIrrigationHardware
    {
        public PivotConfig pivotConfig = null;
        public PivotStatus pivotStatus = null;

        public SimulatedHardware()
        {
            pivotConfig = new PivotConfig();

            pivotConfig.Load();

            pivotStatus = new PivotStatus();
        }

        public void UpdatePivotStatus()
        {
            Console.WriteLine("Simulated hardware: Update pivotStatus.");
            // Read simulated data from a log file...
        }

        public Decimal GetPivotPosition()
        {
            UpdatePivotStatus();
            return pivotStatus.RotationSensorDegrees;
        }

        public void MoveHomePosition()
        {
            Console.WriteLine("Simulated hardware: Aligning pivot to home position.");
        }

        public void TurnOn()
        {
            Console.WriteLine("Simulated hardware: Turning on irrigation system.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Simulated hardware: Turning off irrigation system.");
        }

        public void SetSpeed(int speed)
        {
            Console.WriteLine($"Simulated hardware: Setting irrigation speed to {speed}%.");
        }
    }

    public class CenterPivotIrrigation
    {
        private readonly IIrrigationHardware _hardware;

        public CenterPivotIrrigation(IIrrigationHardware hardware)
        {
            _hardware = hardware;
        }


        public void UpdatePivotStatus()
        {
            _hardware.UpdatePivotStatus();
        }

        public Decimal GetPivotPosition()
        {
            return (_hardware.GetPivotPosition());
        }


        public void MoveHomePosition()
        {
            _hardware.MoveHomePosition();
        }

        public void TurnOn()
        {
            _hardware.TurnOn();
        }

        public void TurnOff()
        {
            _hardware.TurnOff();
        }

        public void SetSpeed(int speed)
        {
            if (speed < 0 || speed > 100)
            {
                Console.WriteLine("Invalid speed. Please enter a value between 0 and 100.");
                return;
            }
            _hardware.SetSpeed(speed);
        }
    }
}
