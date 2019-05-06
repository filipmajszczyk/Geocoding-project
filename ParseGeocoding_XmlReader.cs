using System.Xml;

namespace projekt
{
    class ParseGeocoding_XmlReader
    {
        public static CityDataEntry Parse(System.IO.Stream stream)
        {
            XmlTextReader reader = new XmlTextReader(stream);
            CityDataEntry result = new CityDataEntry()
            {
                CityName = string.Empty,
                CountryName = string.Empty,
                Latitude = string.Empty,
                Longitude = string.Empty
            };

            while (reader.Read())
            {
                if (result.CityName != string.Empty && result.CountryName != string.Empty && result.Latitude != string.Empty && result.Longitude != string.Empty)
                {
                    break;
                }
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "city":
                                result.CityName = reader.ReadString();
                                break;
                            case "country":
                                result.CountryName = reader.ReadString();
                                break;
                            case "lat":
                                result.Latitude = reader.ReadString();
                                break;
                            case "lng":
                                result.Longitude = reader.ReadString();
                                break;
                        }
                        break;
                }
            }
            return result;
        }

        public static CityDataEntry ParseLocal(string fileName)
        {
            XmlTextReader reader = new XmlTextReader(fileName);
            CityDataEntry result = new CityDataEntry()
            {
                CityName = string.Empty,
                CountryName = string.Empty,
                Latitude = string.Empty,
                Longitude = string.Empty
            };

            while (reader.Read())
            {
                if (result.CityName != string.Empty && result.CountryName != string.Empty && result.Latitude != string.Empty && result.Longitude != string.Empty)
                {
                    break;
                }
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "city":
                                result.CityName = reader.ReadString();
                                break;
                            case "country":
                                result.CountryName = reader.ReadString();
                                break;
                            case "lat":
                                result.Latitude = reader.ReadString();
                                break;
                            case "lng":
                                result.Longitude = reader.ReadString();
                                break;
                        }
                        break;
                }
            }
            return result;
        }
    }
}
