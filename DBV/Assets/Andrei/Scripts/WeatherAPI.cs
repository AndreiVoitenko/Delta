using System.Net;
using System.Xml;

class WeatherAPI
{
    private XmlDocument xmlDocument;

    public WeatherAPI()
    {
        xmlDocument = GetXML("http://api.openweathermap.org/data/2.5/weather?q=Tartu&mode=xml&units=metric&APPID=7cc077cc0e9b344bd8477f966ced0a4b");
    }

    public float GetTemp()
    {
        XmlNode weather = xmlDocument.SelectSingleNode("//temperature");
        XmlAttribute value = weather.Attributes["value"];
        string description = value.Value;
        return float.Parse(description);
    }

    public string GetWeatherDescrip()
    {
        XmlNode weather = xmlDocument.SelectSingleNode("//weather");
        XmlAttribute value = weather.Attributes["value"];
        string description = value.Value;
        return description;
    }

    public float GetWeatherDescripCode()
    {
        XmlNode weather = xmlDocument.SelectSingleNode("//weather");
        XmlAttribute value = weather.Attributes["number"];
        string description = value.Value;
        return float.Parse(description);
    }

    public float GetClouds()
    {
        XmlNode weather = xmlDocument.SelectSingleNode("//clouds");
        XmlAttribute value = weather.Attributes["value"];
        string val = value.Value;
        return float.Parse(val);
    }

    public string GetPrecipitation()
    {
        XmlNode weather = xmlDocument.SelectSingleNode("//precipitation");
        XmlAttribute value = weather.Attributes["mode"];
        string description = value.Value;
        return description;
    }

    private XmlDocument GetXML(string CurrentURL)
    {
        using (WebClient client = new WebClient())
        {
            string xmlContent = client.DownloadString(CurrentURL);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlContent);
            return xmlDocument;
        }
    }
}