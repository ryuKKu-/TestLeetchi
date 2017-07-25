using System;
using TestLeechi.Models;

namespace TestLeechi.Parser
{
    public class MobilierParser
    {
        /// <summary>
        /// Parse une chaine de caractères pour créer un objet mobilier
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public Mobilier Parse(string str)
        {
            var tokens = str.Split(' ');

            if (tokens.Length != 5)
                throw new ArgumentException("Nombre de paramètres insuffisants");

            if (double.TryParse(tokens[2], out double hauteur) && 
                double.TryParse(tokens[3], out double poids) && 
                double.TryParse(tokens[4], out double prix)) {

                switch (tokens[0])
                {
                    case nameof(Chaise):
                        return new Chaise(tokens[1], hauteur, poids, prix);
                    case nameof(Table):
                        return new Table(tokens[1], hauteur, poids, prix);
                    case nameof(Fauteuil):
                        return new Fauteuil(tokens[1], hauteur, poids, prix);
                    default:
                        throw new ArgumentException("Type de mobilier inconnu");
                }
            }

            throw new ArgumentException("Les valeurs ne sont pas parsables");
        }
    }
}
