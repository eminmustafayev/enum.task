using Core.Helper.@enum;
using Core.Helper.exception;

namespace Core.Models
{
    public class Product
    {
        public string Name { get; set; }

        private int _no;
        public int No { get { return _no; } set { _no = value; } }
        public TypeEnum Type { get; set; }
        double _price;
        private TypeEnum type;

        public double Price
        {
            get

            {
                return Price;

            }
            set
            {
                if (value < 0)
                {
                    throw new PriceMustBeGratherThanZeroException();
                }
            }
        }
        public Product(string name , double price)
        {
            ++_no;
            No = _no;
            Name = name;
            Price = price;
            Type = type;
        }
        public void ShowInfo()
        {
            Console.WriteLine(" No: " + No + " Name: " + Name + " price: " + Price + " Type: " + Type);
        }
        
        }
        
    }