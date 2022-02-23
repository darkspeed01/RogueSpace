using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class ShipContainer : MonoBehaviour {

    [XmlArray("Ships"), XmlArrayItem("Ship")]
    public Ship[] ships;

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(ShipContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static ShipContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(ShipContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as ShipContainer;
        }
    }

    //Loads the xml directly from the given string. Useful in combination with www.text.com
    public static ShipContainer LoadFromText(string text)
    {
        var serializer = new XmlSerializer(typeof(ShipContainer));
        return serializer.Deserialize(new StringReader(text)) as ShipContainer;
    }
}
