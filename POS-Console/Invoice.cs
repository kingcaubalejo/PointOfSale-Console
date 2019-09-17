using System;
using System.Collections.Generic;
using System.Text;

namespace POSConsole
{
    public class Invoice
    {
        private List<Products> listOfPurchasedItems;
        private double totalAmountPurchased;
        private double totalChange;
        private double amountEntered;

        public Invoice(List<Products> _purchased, 
            double _totalAmountPurchased, 
            double _totalChange,
            double _amountEntered)
        {
            this.listOfPurchasedItems       = _purchased;
            this.totalAmountPurchased       = _totalAmountPurchased;
            this.totalChange                = _totalChange;
            this.amountEntered              = _amountEntered;
        }

        public string Display()
        {
            string header = @" 
               ___    ___  ___   __   _____ 
              / __\  /___\/ _ \ / /   \_   \
             /__\// //  // /_\// /     / /\/
            / \/  \/ \_// /_\\/ /___/\/ /_  
            \_____/\___/\____/\____/\____/  
            BOGLI: Bentahan of GLOBE LOAD inside";

            StringBuilder content = new StringBuilder();
            StringBuilder items = new StringBuilder();
            content.Append(header);
            content.Append("\n");
            content.Append("Address: edi sa puso ni crush\n");
            content.Append("SERIAL#: 010100001111\n");
            content.Append("MIN#: 111111111111\n");
            content.Append("\n\n");

            content.Append("Product\t\t\t\t\t\tPrice\n");
            foreach (Products p in this.listOfPurchasedItems)
            {
                items.AppendFormat("{0}\n", p.ToString());
            }

            content.Append(items);
            content.Append("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n");
            content.AppendFormat("Total Amount: {0}\n", this.totalAmountPurchased);
            content.AppendFormat("Amount Entered: {0}\n", this.totalAmountPurchased);
            content.AppendFormat("Total Change: {0}\n\n\n", this.totalChange);

            content.Append("\"THIS SERVES AS YOUR SALES INVOICE\"\n\n");
            content.Append("BUYERS NAME: ______________________ \n");
            content.Append("ADDRESS: ______________________ \n");
            content.Append("TIN #: ______________________ \n");
            content.Append("BUS STYLE: ______________________ \n");

            content.Append("\n\n\n");

            return String.Format(content.ToString()
                +"###############################\n"
                +"#                             #\n"
                +"#    COMPLY & SAVE WITH US    #\n"
                +"#                             #\n"
                +"###############################"
                +"\n\n\n"
            );
        }
    }
}
