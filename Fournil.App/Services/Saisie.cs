namespace Fournil.App.Services;

public static class Saisie
{
    public static string LireTexte(string question)
    {
        while (true)
        {
            Console.Write($"{question} : ");
            string saisie = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(saisie))
            {
                return saisie;
            }
            Console.WriteLine("Ce champ ne peut pas être vide.");
        }
    }

    public static decimal LireDecimalPositif(string question)
    {
        while (true)
        {
            Console.Write($"{question} : ");
            bool decimalValide = decimal.TryParse(Console.ReadLine(), out decimal saisie);
            if (decimalValide && saisie > 0)
            {
                return saisie;
            }
            Console.WriteLine("Le nombre doit être supérieur à 0.");
        }
    }

    public static int LireEntierPositifOuNul(string question)
    {
        while (true)
        {
            Console.Write($"{question} : ");
            bool entierValide = int.TryParse(Console.ReadLine(), out int saisie);
            if (entierValide && saisie >= 0)
            {
                return saisie;
            }
            Console.WriteLine("Le nombre doit être un entier supérieur ou égal à 0.");
        }
    }

    public static string LireChoixDansListe(string question, List<string> choixAutorises)
    {
        while (true)
        {
            Console.WriteLine($"Choix possibles : {string.Join(", ", choixAutorises)}.");
            Console.Write($"{question} : ");
            string saisie = Console.ReadLine()?.Trim() ?? "";
            if (choixAutorises.Contains(saisie))
            {
                return saisie;
            }
            Console.WriteLine("Choix invalide");
        }
    }
}