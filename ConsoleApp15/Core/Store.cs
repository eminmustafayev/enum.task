using Core.Helper.@enum;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Store
    {
        Product[] Products;

        public Store()
        {
            Products = new Product[0];
        }

        public void ShowAllProducts()
        {
            Console.WriteLine();
        }
        public void AddProduct(Product product)
        {
            Array.Resize(ref Products, Products.Length + 1);
            Products[Products.Length - 1] = product;
        }
        public Product[] RemoveProductByNo(int no)
        {
            bool productFound = false;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].No == no)
                {
                    Products[i] = null;
                    Console.WriteLine("Secdiyiniz mehsul ugurla silindi");
                    productFound = true;
                    break;
                }
                else
                {
                    Console.WriteLine("secdiyiniz mehsul yoxdur ve ya artiq silinib");
                }
            }
            return Products;
        }
        public Product GetProduct(int no)
        {
            Product productFound = null;
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].No == no)
                {
                    productFound = Products[i];
                    return productFound;
                }
            }
            return productFound;
        }
       public Product[] FilterProductByName(string name)
        {
            Product[] foundProducts = Products;
            for(int i = 0;i < Products.Length;i++)
            {
                if (Products[i].Name.ToLower() == name.ToLower())
                {
                    Array.Resize( ref foundProducts ,foundProducts.Length+1);
                    foundProducts[foundProducts.Length - 1] = Products[i];
                }
            }
            return foundProducts;
        }
        public Product[] FilterProductByType(TypeEnum type)
        {
            Product[] foundProducts = Products;
            for(int i = 0; i<Products.Length; i++) 
            {
                if (Products[i].Type == type)
                {
                    Array.Resize(ref foundProducts ,foundProducts.Length+1);
                    foundProducts[foundProducts.Length - 1] =  Products[i];
                }
            }
            return foundProducts;
        }
        public Product[] GetAll()
        {
            return Products;
        }
    } 
}

