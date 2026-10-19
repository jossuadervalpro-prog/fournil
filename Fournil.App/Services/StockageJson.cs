using System.Text.Json;
using Fournil.App.Models;

namespace Fournil.App.Services;

public static class StockageJson
{
    public static void Sauvegarder(List<Produit> produits, string chemin)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(produits, options);
        File.WriteAllText(chemin, json);
    }

    public static List<Produit> Charger(string chemin)
    {
        if (!File.Exists(chemin))
        {
            return new List<Produit>();
        }

        try
        {
            string json = File.ReadAllText(chemin);
            List<Produit>? produits = JsonSerializer.Deserialize<List<Produit>>(json);
            return produits ?? new List<Produit>();
        }
        catch (JsonException)
        {
            Console.WriteLine("Attention : le fichier produits.json est illisible. Le catalogue démarre vide.");
            return new List<Produit>();
        }
    }
}