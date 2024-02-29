// See https://aka.ms/new-console-template for more information
using Owoce;
using System.Linq;

UsdCourse.Current = await UsdCourse.GetUsdCourseAsync();
Console.WriteLine("Hello, World!");
List<Fruit> fruits = new List<Fruit>();


for (int i = 0; i < 15; i++)
{
    Fruit fruit = Fruit.Create();
    fruits.Add(fruit);
}

List<Fruit> sortedFruits = fruits.Where(o => o.IsSweet==true).OrderByDescending(o => o.Price).ToList();
Console.WriteLine("\n Nieposortowane owoce \n");
foreach (var fruit in fruits)
{
    Console.WriteLine(fruit.ToString());
}
Console.WriteLine("\n Nieposortowane owoce \n");
foreach (var fruit in sortedFruits)
{
    Console.WriteLine(fruit.ToString());
}