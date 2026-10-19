using System.Runtime.InteropServices;
using Fournil.App.Models;

List<Produit> produits = new List<Produit>();
produits.Add(new Produit(1, "Baguette", 1.20m, 30, "Pain"));
produits.Add(new Produit(2, "Pain campagne", 3.20m, 20, "Pain"));
produits.Add(new Produit(3, "Croissant", 1.80m, 60, "Viennoiserie"));
produits.Add(new Produit(4, "Tarte aux fraises", 19.99m, 5, "Pâtisserie"));

foreach (var produit in produits)
{
    System.Console.WriteLine(produit.Afficher());
}