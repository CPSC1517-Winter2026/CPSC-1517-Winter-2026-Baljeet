using System.Buffers;

namespace TrainWebApp.Model
{
    public class CarWeight
    {
        public string Owner { get; set; }
        public string CarId { get; set; }
           
        public string SerialNumber 
        { 
            get { return Owner + " " + CarId; }
        }
        public RailCarType RailCarType { get; set; }
        public int ScaleWeight { get; set; }

        public CarWeight()
        {

        }
        public CarWeight(string owner, string carid, RailCarType railCarType, int scaleWeight)
        {
           
            Owner=owner;
            CarId=carid;
            RailCarType=railCarType;
            ScaleWeight=scaleWeight;
        }

        public override string ToString()
        {
            return $"{SerialNumber},{RailCarType},{ScaleWeight}";
        }

        public static CarWeight Parse ( string value)
        {
           
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("No data supplied");
            }
            string[] data = value.Split(',');
            if (data.Length != 3) 
            {
                throw new FormatException($"Car Weight input {value} incorrect format");
            }
            string[] serialnumber = data[0].Split(' ');
            if (serialnumber.Length != 2)
            {
                throw new FormatException($"Serial Number Input {data[0]} incorrect format");
            }
            return new CarWeight(serialnumber[0], serialnumber[1], (RailCarType)Enum.Parse(typeof(RailCarType), data[1]), int.Parse(data[2]));
        }

        public static bool TryParse(string value, out CarWeight car)
        {
            bool valid = true;
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("No data supplied");
            }
            car = CarWeight.Parse(value);
            return valid;
        }
    }
}
