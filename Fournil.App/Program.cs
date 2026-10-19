using Fournil.App.Models;

List<Produit> produits = new List<Produit>();
produits.Add(new Produit(1, "Baguette", 1.20m, 30, "Pain"));
produits.Add(new Produit(2, "Pain campagne", 3.20m, 20, "Pain"));
produits.Add(new Produit(3, "Croissant", 1.80m, 60, "Viennoiserie"));
produits.Add(new Produit(4, "Tarte aux fraises", 19.99m, 5, "Pâtisserie"));

List<string> categoriesAutorisees = new List<string> { "Pain", "Viennoiserie", "Pâtisserie" };

int choix;

do
{
    Console.WriteLine();
    Console.WriteLine("=== FOURNIL ===");
    Console.WriteLine("1. Afficher le catalogue");
    Console.WriteLine("2. Ajouter un produit");
    Console.WriteLine("0. Quitter");
    Console.WriteLine();
    Console.Write("Écrivez le numéro de la tâche à réaliser : ");

    bool saisieValide = int.TryParse(Console.ReadLine(), out choix);

    if (!saisieValide)
    {
        choix = -1;
    }

    switch (choix)
    {
        case 1:
            Console.WriteLine();
            foreach (var produit in produits)
            {
                Console.WriteLine(produit.Afficher());
            }
            break;

        case 2:
            string nom;
            do
            {
                Console.Write("Nom du produit : ");
                nom = Console.ReadLine()?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(nom))
                {
                    Console.WriteLine("Le nom ne peut pas être vide.");
                }
            } while (string.IsNullOrWhiteSpace(nom));

            decimal prix;
            bool prixValide;
            do
            {
                Console.Write("Prix du produit (exemple : 1,50) : ");
                prixValide = decimal.TryParse(Console.ReadLine(), out prix);
                if (!prixValide || prix <= 0)
                {
                    Console.WriteLine("Le prix doit être un nombre supérieur à 0.");
                }
            } while (!prixValide || prix <= 0);

            int stock;
            bool stockValide;
            do
            {
                Console.Write("Quantité en stock : ");
                stockValide = int.TryParse(Console.ReadLine(), out stock);
                if (!stockValide || stock < 0)
                {
                    Console.WriteLine("Le stock doit être un nombre entier supérieur ou égal à 0.");
                }
            } while (!stockValide || stock < 0);

            string categorie;
            do
            {
                Console.Write("Catégorie (Pain, Viennoiserie, Pâtisserie) : ");
                categorie = Console.ReadLine()?.Trim();
                if (!categoriesAutorisees.Contains(categorie))
                {
                    Console.WriteLine("Catégorie inconnue. Tapez exactement : Pain, Viennoiserie ou Pâtisserie.");
                }
            } while (!categoriesAutorisees.Contains(categorie));

            int nouvelId = 0;
            foreach (var produit in produits)
            {
                if (produit.Id > nouvelId)
                {
                    nouvelId = produit.Id;
                }
            }
            nouvelId += 1;

            produits.Add(new Produit(nouvelId, nom, prix, stock, categorie));

            Console.WriteLine($"Produit « {nom} » ajouté avec l'Id {nouvelId} !");
            break;

        case 0:
            Console.WriteLine("Au revoir !");
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
} while (choix != 0);