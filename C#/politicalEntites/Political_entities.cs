
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    public class PoliticalEntity
    {
        public string Name { get; set; }
        public string Economy { get; set; }
        public float Authority { get; set; }     // -10 (anarchy) to +10 (totalitarian)
        public float Culture { get; set; }       // -10 (individualist) to +10 (collectivist)
        public float AiEthnicity { get; set; }   // -10 (anti-AI) to +10 (fully synthetic)
        public float AlienEthnicity { get; set; } // -10 (xenophobic) to +10 (fully integrated)

        public PoliticalEntity(string name, string economy, float authority,
                              float culture, float aiEthnicity, float alienEthnicity)
        {
            Name = name;
            Economy = economy;
            Authority = authority;
            Culture = culture;
            AiEthnicity = aiEthnicity;
            AlienEthnicity = alienEthnicity;
        }

        public override string ToString()
        {
            return $"Entity: {Name}\n" +
                   $"  Economy: {Economy}\n" +
                   $"  Authority: {Authority,5:F1} | Culture: {Culture,5:F1}\n" +
                   $"  AI Ethnicity: {AiEthnicity,5:F1} | Alien Ethnicity: {AlienEthnicity,5:F1}";
        }

        // Calculate Euclidean distance to another point (user's scores)
        public double DistanceTo(float auth, float cult, float ai, float alien)
        {
            return Math.Sqrt(
                Math.Pow(Authority - auth, 2) +
                Math.Pow(Culture - cult, 2) +
                Math.Pow(AiEthnicity - ai, 2) +
                Math.Pow(AlienEthnicity - alien, 2)
            );
        }
    }

    public static class Data
    {
        public static readonly string[] Economies = { "Agrarian", "Industrial", "Technological", "Post-Scarcity" };
        public static readonly string[] Authorities = { "Anarchy", "Libertarian", "Egalitarian", "Authoritarian" };
        public static readonly string[] Cultures = { "Individualist", "Collectivist", "Militarist", "Pacifist" };
        public static readonly string[] AiLevels = { "Low", "Medium", "High", "Synthetic" };
        public static readonly string[] AlienLevels = { "Low", "Medium", "High", "Integrated" };
    }

    class Program
    {
        static void Main(string[] args)
        {
            var entities = new List<PoliticalEntity>
            {
                new PoliticalEntity("United Federation",        "Technological",   0.8f,  0.5f,  8.5f,  7.0f),
                new PoliticalEntity("MAGA Empire",              "Industrial",      7.5f,  6.0f, -8.0f, -9.0f),
                new PoliticalEntity("Communist Union",          "Post-Scarcity",  -4.0f,  8.5f,  3.0f,  2.0f),
                new PoliticalEntity("Neutral Alliance",         "Technological",   0.0f,  0.0f,  0.0f,  0.0f),
                new PoliticalEntity("Galactic Confederation",   "Post-Scarcity",   2.5f, -1.0f,  9.0f,  8.5f),
                new PoliticalEntity("Imperial Dominion",        "Industrial",      8.0f,  5.5f, -7.0f, -8.5f),
                new PoliticalEntity("Libertarian Republic",     "Technological",  -7.0f, -6.5f,  5.0f,  4.0f),
                new PoliticalEntity("Technocratic Syndicate",    "Post-Scarcity",   4.0f,  2.0f,  9.9f,  6.0f),
                new PoliticalEntity("Eco-Friendly Coalition",   "Agrarian",       -2.0f,  7.0f,  2.0f,  8.0f),
                new PoliticalEntity("Militaristic Regime",      "Industrial",      8.5f,  4.0f, -6.0f, -7.5f),
                new PoliticalEntity("Cultural Alliance",        "Technological",   1.5f,  6.5f,  4.0f,  3.0f),
                new PoliticalEntity("AI Dominion",              "Post-Scarcity",   9.0f,  8.0f, 10.0f, -5.0f),
                new PoliticalEntity("Alien Federation",         "Technological",  -1.5f,  3.0f,  1.0f, 10.0f),
                new PoliticalEntity("Galactic Empire",          "Industrial",      9.5f,  7.0f, -8.5f, -9.5f),
                new PoliticalEntity("Harmonious Collective",    "Post-Scarcity",   3.0f,  8.5f,  7.5f,  9.0f),
                new PoliticalEntity("Progressive Union",        "Technological",   1.0f,  4.0f,  6.5f,  5.5f),
                new PoliticalEntity("Traditionalist Alliance",  "Agrarian",       -6.0f, -5.0f, -4.0f, -6.0f),
                new PoliticalEntity("Scientific Federation",    "Post-Scarcity",   2.0f, -2.0f,  9.5f,  7.5f),
                new PoliticalEntity("Militant Coalition",       "Industrial",      7.0f,  5.5f, -5.5f, -6.0f),
                new PoliticalEntity("Utopian Society",          "Post-Scarcity",   0.5f,  3.0f,  8.0f,  9.5f),
                new PoliticalEntity("Authoritarian Regime",     "Industrial",      9.8f,  6.5f, -7.0f, -8.0f),
                new PoliticalEntity("Democratic Federation",    "Technological",  -3.0f, -2.5f,  4.5f,  6.0f),
                new PoliticalEntity("Interstellar Alliance",    "Technological",   2.0f,  1.5f,  7.0f,  8.0f),
                new PoliticalEntity("Cosmic Empire",            "Industrial",      9.0f,  7.5f, -9.0f, -9.0f),
                new PoliticalEntity("Freedom Coalition",        "Technological",  -6.5f, -7.0f,  3.5f,  4.5f),
                new PoliticalEntity("Technological Republic",   "Post-Scarcity",   1.5f, -1.5f,  8.5f,  5.0f),
                new PoliticalEntity("Galactic Syndicate",       "Industrial",      6.0f,  4.0f, -4.0f, -5.0f),
                new PoliticalEntity("Harmonious Federation",    "Post-Scarcity",    2.5f,  4.5f,  8.0f,  9.0f),
                new PoliticalEntity("Militaristic Alliance",    "Industrial",      8.0f,  6.0f, -6.5f, -7.0f),
                new PoliticalEntity("Cultural Republic",        "Technological",  -1.0f,  5.0f,  5.5f,  6.5f)
            };

            // Optional: Display all entities (comment out if not needed)
            // Console.WriteLine($"Total Political Entities: {entities.Count}\n");
            // Console.WriteLine(new string('=', 60));
            // foreach (var entity in entities)
            // {
            //     Console.WriteLine(entity);
            //     Console.WriteLine(new string('-', 60));
            // }

            // === POLITICAL QUIZ ===
            Console.WriteLine("\n=== POLITICAL ENTITY QUIZ ===\n");
            Console.WriteLine("Answer the following questions to find out which galactic political entity you align with most closely.");
            Console.WriteLine("For each question, choose a number from 1 to 5, where:");
            Console.WriteLine("1 = Strongly Disagree");
            Console.WriteLine("2 = Disagree");
            Console.WriteLine("3 = Neutral");
            Console.WriteLine("4 = Agree");
            Console.WriteLine("5 = Strongly Agree\n");

            // Questions mapped to axes (2-3 per axis for better accuracy)
            // Authority: Low = Libertarian/Anarchy (-), High = Authoritarian (+)
            float userAuthority = 0;
            userAuthority += GetAnswer("Government should have strong central control to maintain order.") * 2 - 5; // 1-> -4, 5-> +5
            userAuthority += GetAnswer("Individual freedoms should always take priority over state authority.") * -2 + 5; // Reverse scoring
            userAuthority += GetAnswer("A strong government is necessary to prevent chaos and maintain societal order.") * 2 - 5;
            userAuthority += GetAnswer("Excessive government control stifles personal freedoms and innovation.") * -2 + 5;
            userAuthority /= 4; // Average

            // Culture: Low = Individualist (-), High = Collectivist (+)
            float userCulture = 0;
            userCulture += GetAnswer("Society functions best when people prioritize the group's needs over their own.") * 2 - 5;
            userCulture += GetAnswer("Personal achievement and independence are more important than community harmony.") * -2 + 5;
            userCulture += GetAnswer("Collaboration and teamwork lead to better outcomes than individual efforts.") * 2 - 5;
            userCulture += GetAnswer("People should be free to pursue their own goals without societal pressure to conform.") * -2 + 5;
            userCulture /= 4;

            // AI Ethnicity: Low = Anti-AI (-), High = Pro-AI/Synthetic (+)
            float userAi = 0;
            userAi += GetAnswer("AI should be fully integrated into society as equal citizens.") * 2 - 5;
            userAi += GetAnswer("Humans should limit AI development to avoid risks to our way of life.") * -2 + 5;
            userAi += GetAnswer("Advanced AI can greatly benefit humanity if properly managed.") * 2 - 5;
            userAi += GetAnswer("AI poses a significant threat and should be strictly controlled.") * -2 + 5;
            userAi /= 4;

            // Alien Ethnicity: Low = Xenophobic (-), High = Integrated (+)
            float userAlien = 0;
            userAlien += GetAnswer("We should welcome and integrate alien species into our culture.") * 2 - 5;
            userAlien += GetAnswer("Protecting our own species' interests should come before alliances with aliens.") * -2 + 5;
            userAlien += GetAnswer("Cultural exchange with alien species enriches our society.") * 2 - 5;
            userAlien += GetAnswer("Alien species pose a threat to our way of life and should be kept at a distance.") * -2 + 5;
            userAlien /= 4;

            // Find closest entity using Euclidean distance
            var closest = entities.OrderBy(e => e.DistanceTo(userAuthority, userCulture, userAi, userAlien)).First();

            Console.WriteLine("\n=== YOUR ALIGNMENT ===\n");
            Console.WriteLine($"Based on your answers, you are closest to: {closest.Name}");
            Console.WriteLine($"Your scores: Authority={userAuthority:F1}, Culture={userCulture:F1}, AI={userAi:F1}, Alien={userAlien:F1}");
            Console.WriteLine(closest);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static float GetAnswer(string question)
        {
            int answer;
            do
            {
                Console.WriteLine(question);
                Console.Write("Your answer (1-5): ");
            } while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 5);

            return answer;
        }
    
    }
}