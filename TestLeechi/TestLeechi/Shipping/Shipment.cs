namespace TestLeechi.Shipping
{
    public interface IShipment
    {
        double Compute(double poids, double hauteur);
    }

    public class Shipment : IShipment
    {
        public double Compute(double poids, double hauteur)
        {
            return poids * hauteur * 0.001;
        }
    }

    public class ColissimoShipment : IShipment
    {
        public double Compute(double poids, double hauteur)
        {
            return poids * 0.55 + hauteur * 0.001;
        }
    }
}
