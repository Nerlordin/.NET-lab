using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owoce
{
    internal class Fruit
    {
        public String Name;
        public bool IsSweet;
        public double Price;
        public double UsdPrice => Price / UsdCourse.Current;

        public static Fruit Create()
        {
            Random r = new Random();
            string[] names = new string[] { "Apple", "Banana",
            "Cherry", "Durian", "Edelberry", "Grape", "Jackfruit" };
            return new Fruit
            {
                Name = names[r.Next(names.Length)],
                IsSweet = r.NextDouble() > 0.5,
                Price = r.NextDouble() * 10
            };
        }
        public override string ToString()
        {
            return $"Name: {Name}, IsSweet: {IsSweet}, Price: {Price:C2}, UsdPrice: {MyFormatter.FormatUsdPrice(UsdPrice)}";
        }

    }
    class UsdCourse
    {
        public static float Current = 0;
        public async static Task<float> GetUsdCourseAsync()
        {
            var wc = new HttpClient();
            var response = await
            wc.GetAsync("http://www.nbp.pl/kursy/xml/LastA.xml");
            if (!response.IsSuccessStatusCode)
                throw new InvalidOperationException();
            System.Xml.XmlDocument xd = new
            System.Xml.XmlDocument();
            xd.LoadXml(await
            response.Content.ReadAsStringAsync());
        foreach (System.Xml.XmlNode p in
        xd.GetElementsByTagName("pozycja"))
            {
                if (p.NodeType == System.Xml.XmlNodeType.Element)
                {
                    System.Xml.XmlElement pp =
                    (System.Xml.XmlElement)p;
                    System.Xml.XmlElement w =
                    (System.Xml.XmlElement)pp.GetElementsByTagName("kod_waluty")[0
                    ];
                    if (w.InnerText == "USD")
                    {
                        return
                        Convert.ToSingle(pp.GetElementsByTagName("kurs_sredni")[0].InnerText);
                    }
                }
            }
            throw new InvalidOperationException();
        }
    }
    public class MyFormatter
    {
        public static string FormatUsdPrice(double price)
        {
            var usc = new CultureInfo("en-us");
            return price.ToString("C2", usc);
        }

    }

}
