using System;
using Core.Models;
using Core.Helpers.Enums;
using Core.Helpers.Exceptions;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp15
{
    internal class Program
    {
        private static Store store = new Store();  
        private static bool deyisen;

       

        static void Main(string[] args)
        {
            bool condition = false;  
            Console.WriteLine("                                                       XOS GELMISSINIZ");

            while (!condition)
            {
                Console.WriteLine("1) Show product     2) Add product          3) Remove product      4) Search product (by name)       5) Search products (by type)      0) EXIT");
                Console.Write("Seciminizi edin: ");

                deyisen = int.TryParse(Console.ReadLine(), out int secim);

                try
                {
                    switch (secim)
                    {
                        case1:                             

                            Product[] allProducts = store.GetAll();
                        case 2:
                            Console.Write("Mehsulun adin daxil edin: ");
                            string name = Console.ReadLine();

                            double price;
                            do
                            {
                                Console.Write("Mehsulun qiymetini daxil edin: ");
                                deyisen = double.TryParse(Console.ReadLine(), out price);
                            } while (!deyisen);

                            Console.WriteLine("Mehsulun tipini secin: 1)Meat 2)Drink 3)Baker 4)Diary");
                            TypeEnum type = Console.ReadLine() switch
                            {
                                "1" => TypeEnum.Meat,
                                "2" => TypeEnum.Drink,
                                "3" => TypeEnum.Baker,
                                "4" => TypeEnum.Diary,
                                 
                            };

                            Product product = new Product(name, price, type);
                            store.AddProduct(product);
                            Console.WriteLine("megsul ugurla elave olundu.");
                            break;

                        case 3:
                             
                            Console.Write("Silmek istediyiniz mehsul nomresini daxil edin: ");
                            if (int.TryParse(Console.ReadLine(), out int silNo))
                                store.RemoveProductByNo(silNo);
                            else
                                Console.WriteLine("bele nomre yoxdu : ");
                            break;

                        case 4:
                            
                            Console.Write("Axtarmaq istediyiniz mehsulun adini daxil edin: ");
                            string searchName = Console.ReadLine();
                            Product[] productsByName = store.FilterProductByName(searchName);
                            if (productsByName.Length > 0)
                            {
                                foreach (var prod in productsByName)
                                    prod.ShowInfo();
                            }
                            else
                                Console.WriteLine("Axtardiginiz mehsul tapilmadi:");
                            break;

                        case 5:
                           
                            Console.WriteLine(" istediyiniz product type secin:\n1)Meat\n2)Drink\n3)Baker\n4)Diary : ");
                            TypeEnum filterType = Console.ReadLine() switch
                            {
                                "1" => TypeEnum.Meat,
                                "2" => TypeEnum.Drink,
                                "3" => TypeEnum.Baker,
                                "4" => TypeEnum.Diary,
                                
                            };
                            Product[] filteredProducts = store.FilterProductsByType(filterType);
                            if (filteredProducts.Length > 0)
                            {
                                foreach (var prod in filteredProducts)
                                    prod.ShowInfo();
                            }
                      
                            break;

                        case 0:
                            condition = true;
                            Console.WriteLine("EXIT");
                            break;

                        default:
                            Console.WriteLine("Duzgun secim edin.");
                            break;
                    }
                }
                catch (PriceMustBeGratherThanZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Xeta: " + ex.Message);
                }
                
            }
        }
    }
}


