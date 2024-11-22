using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pivot.Model
{
    public class PivotConfig
    {
        public int PivotID { get; set; }
        public string PivotName { get; set; }               // Operator specified name
        public string Location { get; set; }                // Operator specified location name
        public GeoLocation PivotCenter { get; set; }        // GeoLocation also used for Weather Conditions
        public GeoLocation PivotHomePosition { get; set; }  // Point represents total radius length and 0 degree rotation point, idle position
        public decimal TopLeftCornerDegrees { get; set; }   // Mark each corner by degree rotation
        public bool TopLeftCornerIrrigate { get; set; }     // true = has corner irrigation AND irrigate this corner
        public decimal TopRightCornerDegrees { get; set; }
        public bool TopRightCornerIrrigate { get; set; }
        public decimal BottomRightCornerDegrees { get; set; }
        public bool BottomRightCornerIrrigate { get; set; }
        public decimal BottomLeftCornerDegrees { get; set; }
        public bool BottomLeftCornerIrrigate { get; set; }
        public int SpanCount { get; set; }                  // metrics help compute water flow rate needs
        public int SpanLength  { get; set; }                // (meters) Length of each span, also determines each wheel line radius
        public int SprayerTypeID { get; set; }              // SprayerType indicates water flow rate and how fast the pivot should rotate
        public bool HasEndGun { get; set; }                 // Pivot with EndGun may be optional
        public int EndGunTypeID { get; set; }               // GunTypeID indicates ratchet type, spray radius, distance
        public bool HasChemicalInjection { get; set; }      // Pivot has chemical/fertilizer injection capability
        public int ChemicalInjectionTypeID { get; set; }    // Flow rate and types of unit control
        public int SoilTypeID { get; set; }                 // Type of soil to accurately hydrate soil, minimize runoff
        public bool HasSoilMoistureSensor { get; set; }     // Pivot has Soil Moisture Sensor installed
        public int SoilMoistureID { get; set; }             // Indicates how soil moisture is measured
        public int CropTypeID { get; set; }                 // Crop type indicates irrigation needs that fluctuate through the growing season

        public bool Load()
        {
            // Data elements are loaded from file or SQL query
            return true;
        }
    }

}
