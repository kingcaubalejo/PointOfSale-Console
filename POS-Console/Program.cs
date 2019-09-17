using System;
using System.Collections.Generic;

namespace POSConsole
{
    class MainClass
    {
        private static bool isBuying;
        private static List<Products> cart;

        private static void DisplayBanner()
        {
            Console.WriteLine(@" 
               ___    ___  ___   __   _____ 
              / __\  /___\/ _ \ / /   \_   \
             /__\// //  // /_\// /     / /\/
            / \/  \/ \_// /_\\/ /___/\/ /_  
            \_____/\___/\____/\____/\____/  
            BOGLI: Bentahan of GLOBE LOAD inside
                                ");
            Console.WriteLine();
        }

        private static void CheckOut(double totalAmount, double amountTendered)
        {
            double change   = 0.0;
            change          = amountTendered - totalAmount;

            Invoice _Invoice = new Invoice(cart, totalAmount, change, amountTendered);
            Console.WriteLine(_Invoice.Display());
            cart = new List<Products>();

            Console.Write("Do you want to continue shopping? [y/N]:");
            char chooseAnother = char.Parse(Console.ReadLine());
            if (chooseAnother.Equals('N') || chooseAnother.Equals('n'))
            {
                isBuying = false;
            }

        }

        private static void DisplayShoppingCart()
        {
            int itemCount           = 0;
            double totalAmount      = 0.0;

            Console.WriteLine("==============My Shopping Cart=================");
            foreach (Products p in cart)
            {
                Console.WriteLine("[{0}]{1}", ++itemCount, p.ToDisplayCart());
                int productcount = p.productcount.Length > 0 ? Int32.Parse(p.productcount) : 0;
                if(productcount > 0)
                {
                    totalAmount += ((double)p.productprice * productcount);
                }
                else
                {
                    totalAmount += (double)p.productprice;
                }
            }

            Console.WriteLine("Total Amount:{0}\nTotal No. of items: {1}",
                            totalAmount,
                            itemCount);
            Console.WriteLine("==============My Shopping Cart=================");

            Console.WriteLine();
            Console.WriteLine("[1]Proceed to checkout");
            Console.WriteLine("[2]Remove an item");
            Console.WriteLine("[3]Choose another product");
            Console.WriteLine("[4]Exit");
            Console.Write("Enter the number you choose:");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Proceed to checkout....");
                bool amountIsNotEnough = false;
                double amount = 0.0;
                do
                {
                    Console.Write("Enter Amount: ");
                    amount = Double.Parse(Console.ReadLine());

                    if (totalAmount >= amount)
                    {
                        Console.WriteLine("Amount is not enough to pay the items.");
                        amountIsNotEnough = true;
                    }
                    else
                    {
                        amountIsNotEnough = false;
                    }

                } while (amountIsNotEnough);

                CheckOut(totalAmount, amount);

            }
            else if (choice == 2)
            {
                Console.WriteLine("Remove an item to the cart");
                Console.Write("Enter Number to delete: ");
                int itemIndex = Int32.Parse(Console.ReadLine());

                RemoveItemInTheCart(itemIndex);
            }
            else if (choice == 3)
            {
                isBuying = true;
            }
            else if (choice == 4)
            {
                Console.Write("Are you sure you want to exit? [y/N]:");
                char chooseAnother = char.Parse(Console.ReadLine());
                if (chooseAnother.Equals('y') || chooseAnother.Equals('Y'))
                {
                    isBuying = false;
                }
            }
            else
            {
                Console.WriteLine("xx---Input Error---xx");
                isBuying = true;
            }
        }

        private static void AddToCart(List<Products> _p, int productId)
        {
            int f = 1;
            int index = 0;
            if(cart.Count > 0)
            {   
                foreach (Products p in cart)
                {
                    index = cart.FindIndex(delegate (Products products)
                    {
                        return products.productname.Equals(_p[productId - 1].productname);
                    });
                    if (p.productname.Equals(_p[productId - 1].productname))
                    {
                        f++;
                        if(p.productcount.Length > 0)
                        {
                            f = Int32.Parse(p.productcount) + 1;
                        }
                    }
                }

                if (f == 1)
                {
                    cart.Add(new Products(_p[productId - 1].productname,
                            _p[productId - 1].productprice));
                }
                else
                {
                    cart[index] = new Products(_p[productId - 1].productname,
                            _p[productId - 1].productprice, f.ToString());
                }
            }
            else
            {
                cart.Add(new Products(_p[productId - 1].productname,
                            _p[productId - 1].productprice));
            }

        }


        private static void RemoveItemInTheCart(int itemIndex)
        {
            if(itemIndex != -1)
                cart.RemoveAt(itemIndex-1);

            DisplayShoppingCart();
        }

        public static void Main(string[] args)
        {
            isBuying    = true;
            cart        = new List<Products>();

            while (isBuying)
            {

                DisplayBanner();

                Console.WriteLine("\n[No.][Product]\t\t[Price]");
                List<Products> listOfProducts = new Products().getListOfProducts();
                int index = 1;
                foreach (Products p in listOfProducts)
                {
                    Console.WriteLine("[{0}]{1}", index, p.ToString());
                    index++;
                }

                Console.Write("\nEnter the Product No. you choose:");
                int productId = Int32.Parse(Console.ReadLine());
                AddToCart(listOfProducts, productId);
                DisplayShoppingCart();
            }

        }
    }
}
