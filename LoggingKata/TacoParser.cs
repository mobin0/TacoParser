namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        int ran = 0;
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo($"Begin parsing number {ran++}");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogDebug("Length is less than 3");
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2
            string latitude = cells[0];
            string longitude = cells[1];
            string name = cells[2];
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            double lat = double.Parse(latitude);
            double longit = double.Parse(longitude);

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            ITrackable tb = new TacoBell
            {
                Name = name,
                Location = new Point
                {
                    Latitude = lat,
                    Longitude = longit,
                }
            };
            
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tb;
        }
    }
}