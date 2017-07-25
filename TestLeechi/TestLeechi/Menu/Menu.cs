using System;
using System.Collections.Generic;
using TestLeechi.Data;
using TestLeechi.Models;
using TestLeechi.Parser;
using TestLeechi.Shipping;

namespace TestLeechi.ConsoleMenu
{
    public class Menu
    {
        public int DisplayMenu()
        {
            Console.WriteLine("1. Afficher la liste des mobiliers");
            Console.WriteLine("2. Ajouter un mobilier");
            Console.WriteLine("3. Afficher la liste avec l'estimation de la livraison");
            Console.WriteLine("4. Afficher la liste avec l'estimation de la livraison colissimo");
            Console.WriteLine("5. Exit");

            var result = Console.ReadLine();

            Console.WriteLine();

            return Convert.ToInt32(result);
        }

        public void ExecuteChoice(int choice)
        {
            IEnumerable<Mobilier> mobiliers;
            IShipment method;

            switch (choice)
            {
                case 1:
                    mobiliers = Repository.Get();
                    foreach (var m in mobiliers)
                        Console.WriteLine(m.Display());
                    break;

                case 2:
                    var cmd = Console.ReadLine();
                    try
                    {
                        var parser = new MobilierParser();
                        var item = parser.Parse(cmd);
                        Repository.AddItem(item);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case 3:
                    mobiliers = Repository.Get();
                    method = new Shipment();
                    foreach(var m in mobiliers)
                    {
                        m.CalculLivraison(method);
                        Console.WriteLine(m.DisplayLivraison());
                    }
                    break;

                case 4:
                    mobiliers = Repository.Get();
                    method = new ColissimoShipment();
                    foreach (var m in mobiliers)
                    {
                        m.CalculLivraison(method);
                        Console.WriteLine(m.DisplayLivraison());
                    }
                    break;
            }

            Console.WriteLine();
        }
    }
}
