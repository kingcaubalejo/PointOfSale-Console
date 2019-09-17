using System;
using System.Collections.Generic;

namespace POSConsole
{
    public class Products
    {

        private String _productname;
        private int _productprice;
        private List<Products> _listOfProducts;
        private string _count;

        public Products() {
            this._productname = "--No products yet--";
            this._productprice = 0;
        }

        public Products(string pname, int pprice, string pcount = "") {
            this._productname = pname;
            this._productprice = pprice;
            this._count = pcount;
        }

        public List<Products> getListOfProducts()
        {
            this._listOfProducts = new List<Products>();
            this._listOfProducts.Add(new Products("Nads", 15));
            this._listOfProducts.Add(new Products("Daro - lan", 16));
            this._listOfProducts.Add(new Products("WackOff", 17));
            this._listOfProducts.Add(new Products("ButtBuddy", 18));
            this._listOfProducts.Add(new Products("MyDadzNutz", 19));
            this._listOfProducts.Add(new Products("SARS", 20));
            this._listOfProducts.Add(new Products("Urinal", 21));
            this._listOfProducts.Add(new Products("JussiPussi", 22));
            this._listOfProducts.Add(new Products("MrBrains", 23));
            this._listOfProducts.Add(new Products("Shitto", 24));
            this._listOfProducts.Add(new Products("Ayds", 25));
            this._listOfProducts.Add(new Products("SwallowBalls", 26));
            this._listOfProducts.Add(new Products("OnlyPukee", 27));
            this._listOfProducts.Add(new Products("TolGate", 28));
            this._listOfProducts.Add(new Products("TeaGang", 29));


            return _listOfProducts;
        }

        public String productname { 
            get {
                return _productname;
            } 
            set { 
                this._productname = value; 
            }
        }

        public int productprice {
            get {
                return _productprice;
            }

            set {
                this._productprice = value;
            }
        }

        public string productcount
        {
            get
            {
                return _count;
            }

            set
            {
                this._count = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}.....................Php {1} {2}", 
                this._productname, 
                this._productprice,
                this._count);
        }

        public string ToDisplayCart()
        {
            string headerWithCount = "{0}.....................Php {1} {2}";
            if (this._count.Length > 0)
            {
                headerWithCount = "{0}.....................Php {1} @{2}";
            }
            return String.Format(headerWithCount,
                this._productname,
                this._productprice,
                this._count);
        }

    }
}
