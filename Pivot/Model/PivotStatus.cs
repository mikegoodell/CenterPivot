using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pivot.Model
{
    public class PivotStatus
    {
        public int PivotID { get; set; }                // Derived by PivotConfig
        public bool HibernationMode { get; set; }       // true=Pivot is not running based on schedule, OR maintenance mode OR offline mode
        public decimal RotationSensorDegrees { get; set; }  // Feedback from rotation sensor, 0-359 degrees, 0 is home (start) position
        public bool MainPumpON { get; set; }            // Turn on/off main water pump
        public int MainPumpValvePercent { get; set; }   // 0%=closed (water OFF) 1%-100% adjust water flow rate (water ON)
        public decimal MeasuredMainPumpFlowRate { get; set; }   // Feedback loop to verify flow status
        public decimal MeasuredEndGunFlowRate { get; set; }     // 0 or low can indicate system malfunction
        public  bool DriveMotorOn { get; set; }         // Turn on/off drive motor
        public int DriveDirection { get; set; }         // Set Pivot movement direction
        public int DriveThrottleSpeed { get; set; }     // Drive speed setting
        public decimal Speedometer { get; set; }        // Measured drive speed (feedback loop to ensure the pivot is moving)
                                                        // May not be necessary if RotationSensorDegrees shows movement
        public decimal PumpEngineFuelLevel { get; set; } // Indicates fuel level of engine that drives the main pump and electricity for the pivot
        public DateTime RunStartTime { get; set; }      // Starting timestamp for this run
        public int RunDuration { get; set; }            // Total run duration in seconds for current run, note pivot can be paused so not necessarily timeNow - RunStartTime
        public bool IsRunning { get; set; }             // Indicates Pivot is running
        public bool eStopButtonPressed { get; set; }    // Emergency stop button pressed/restored
    }
}
