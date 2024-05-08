using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFC_UM_Demo
{
    public class Location
    {
        public bool noLocate { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double bearing { get; set; }
        public int distance { get; set; }
        public string zoneID { get; set; }
        public string zoneUUID { get; set; }
    }

    public class States
    {
        public string general { get; set; }
        public string buttons { get; set; }
        public string exciterID { get; set; }
        public bool motion { get; set; }
        public bool batteryLow { get; set; }
        public bool blinking { get; set; }
        public bool registered { get; set; }
    }

    public class SingleAntennaHit
    {
        public double theta { get; set; }
        public double phi { get; set; }
        public double range { get; set; }
    }

    public class Direction
    {
        public string fromZone { get; set; }
        public string toZone { get; set; }
        public double speed { get; set; }
        public double vx { get; set; }
        public double vy { get; set; }
        public double vz { get; set; }
    }

    public class Any
    {
        public SingleAntennaHit singleAntennaHit { get; set; }
        public string requestID { get; set; }
        public Direction direction { get; set; }
        public string coordinateSystem { get; set; }
        public double rssi { get; set; }
        public string regionId { get; set; }
        public string locationMethod { get; set; }
        public string polarity { get; set; }
        public double confidenceInterval { get; set; }
        public bool inMotion { get; set; }
    }

    public class VendorSection
    {
        public List<Any> any { get; set; }
    }

    public class TagBlink

    {
        public string tagID { get; set; }
        public string coordRef { get; set; }
        public Location location { get; set; }
        public long locateTime { get; set; }
        public string tagModel { get; set; }
        public string resourceType { get; set; }
        public string readerID { get; set; }
        public States states { get; set; }
        public VendorSection vendorSection { get; set; }
        public long rtlsblinkTime { get; set; }
    }


}
