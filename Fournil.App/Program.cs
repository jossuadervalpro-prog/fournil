using Fournil.App.Models;
using Fournil.App.Services;
const string CheminFichier = "produits.json";

List<Produit> produits = StockageJson.Charger("produits.json");

List<string> categoriesAutorisees = new List<string> { "Pain", "Viennoiserie", "Pâtisserie" };

int choix;

do
{
    Console.WriteLine();
    Console.WriteLine("=== FOURNIL ===");
    Console.WriteLine("1. Afficher le catalogue");
    Console.WriteLine("2. Ajouter un produit");
    Console.WriteLine("3. Modifier le stock");
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
            string nom = Saisie.LireTexte("Nom du produit");
            decimal prix = Saisie.LireDecimalPositif("Prix du produit (exemple : 1,50)");
            int stock = Saisie.LireEntierPositifOuNul("Quantité en stock");
            string categorie = Saisie.LireChoixDansListe("Catégorie du produit", categoriesAutorisees);

            int id = Catalogue.ProchainId(produits);

            produits.Add(new Produit(id, nom, prix, stock, categorie));
            StockageJson.Sauvegarder(produits, CheminFichier);
            Console.WriteLine($"Produit « {nom} » ajouté avec l'Id {id} !");
            break;

        case 3:
            int idCherche = Saisie.LireEntierPositifOuNul("Id du produit à modifier");
            Produit? produitTrouve = Catalogue.TrouverParId(produits, idCherche);
            if (produitTrouve is null)
            {
                Console.WriteLine($"Aucun produit trouvé avec l'Id {idCherche}");
                break;
            }
            Console.WriteLine(produitTrouve.Afficher());
            produitTrouve.Stock = Saisie.LireEntierPositifOuNul("Nouveau stock");
            StockageJson.Sauvegarder(produits, CheminFichier);
            Console.WriteLine($"Le produit {produitTrouve.Nom} a un nouveau stock de {produitTrouve.Stock}.");
            break;

        case 0:
            Console.WriteLine("Au revoir !");
            break;

        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
} while (choix != 0);