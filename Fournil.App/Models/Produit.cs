namespace Fournil.App.Models;

public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public decimal Prix { get; set; }
    public int Stock { get; set; }
    public string Categorie { get; set; }

    public Produit(int id, string nom, decimal prix, int stock, string categorie)
    {
        Id = id;
        Nom = nom;
        Prix = prix;
        Stock = stock;
        Categorie = categorie;
    }

    public string Afficher()
    {
        return $"{Id} - {Nom} ({Categorie}) - {Prix:0.00} € - stock : {Stock}";
    }
}