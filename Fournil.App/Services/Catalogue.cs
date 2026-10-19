using Fournil.App.Models;

namespace Fournil.App.Services;

public static class Catalogue
{
    public static int ProchainId(List<Produit> produits)
    {
        int nouvelId = 0;
        foreach (var produit in produits)
        {
            if (produit.Id > nouvelId)
            {
                nouvelId = produit.Id;
            }
        }
        return nouvelId + 1;
    }
    public static Produit? TrouverParId(List<Produit> produits, int id)
    {
        foreach (var produit in produits)
        {
            if (produit.Id == id)
            {
                return produit;
            }
        }
        return null;
    }
}