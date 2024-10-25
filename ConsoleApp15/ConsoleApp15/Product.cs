namespace ConsoleApp15
{
    internal class Product
    {
        private int v;
        private object value;

        public Product(int v, object value)
        {
            this.v = v;
            this.value = value;
        }

        internal void ShowInfo()
        {
            throw new NotImplementedException();
        }
    }
}