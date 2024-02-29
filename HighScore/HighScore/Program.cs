using System.Text.Json;

internal class HighScore
{
    private static string name;
    private static int trials;

    public string Name { get; set; }
    public int Trials { get; set; }
    private static void Main(string[] args)
    {
        Console.WriteLine("Zadanie1 - FizzBuzz");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine("Zadanie2 - Highscore");
        var rand = new Random();
        var value = rand.Next(1, 101);
        int koniec = 0;
        Console.WriteLine("Podaj swoje imie");
        name = Convert.ToString(Console.ReadLine());
        Console.WriteLine("Odgadnij liczbe pomiedzy 0 a 100");
        while (koniec == 0)
        {
           
            int guess = Convert.ToInt32(Console.ReadLine());
            if (value < guess)
            {
                Console.WriteLine("twoja liczba jest za duza");
                trials++;
            }
            else if (value > guess)
            {
                Console.WriteLine("twoja liczba jest za mala");
                trials++;
            }
            else if (value == guess)
            {
                trials++;
                Console.WriteLine("Zgadłeś w " + trials + " probach");
                koniec++;
            }
        }
            var hs = new HighScore { Name = name, Trials = trials };

            List<HighScore> highScores;

            const string FileName = "highscores.json";

            if (File.Exists(FileName))
                highScores = JsonSerializer.Deserialize<List<HighScore>>(File.ReadAllText(FileName));
            else
                highScores = new List<HighScore>();
            highScores.Add(hs);
             List<HighScore> sortedScores = highScores.OrderBy(o => o.Trials).ToList();
            
            File.WriteAllText(FileName, JsonSerializer.Serialize(sortedScores));

        Console.WriteLine("Tabela wyników: ");
        foreach (var item in sortedScores)
            {
            
            Console.WriteLine($"{item.Name} -- {item.Trials} prób");
            }
        
    }
}