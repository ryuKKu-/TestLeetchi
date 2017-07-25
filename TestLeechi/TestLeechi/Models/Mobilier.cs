using Newtonsoft.Json;
using TestLeechi.Shipping;

namespace TestLeechi.Models
{
    public abstract class Mobilier
    {
        public Mobilier(string designer, double hauteur, double poids, double prix)
        {
            Designer = designer;
            Hauteur = hauteur;
            Poids = poids;
            Prix = prix;
        }

        [JsonProperty]
        private string Designer { get; set; }

        [JsonProperty]
        private double Hauteur { get; set; }

        [JsonProperty]
        private double Poids { get; set; }

        [JsonProperty]
        private double Prix { get; set; }

        private double PrixLivraison { get; set; }
        
        public void CalculLivraison(IShipment method)
        {
            PrixLivraison = method.Compute(Poids, Hauteur);
        }

        public string Display()
        {
            return $"{GetType().Name} {Designer} {Hauteur}cm {Poids}kg {Prix}€";
        }

        public string DisplayLivraison()
        {
            return $"{Display()} | Coût de livraison : {PrixLivraison}€";
        }
    }
}
