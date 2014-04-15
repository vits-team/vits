using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vITs
{
    public class Receipt
    {
        public string date { get; set; }
        public string type { get; set; }
        public string number { get; set; }
        public int sum { get; set; }
        public string currency { get; set; }
        public int recieptExist; 


        public Receipt(string date, string type, string number, int sum, string currency, int recieptExist)
        {
            this.date = date; 
            this.type = type; 
            this.number = number; 
            this.sum = sum; 
            this.currency = currency;
            this.recieptExist = recieptExist; 
        }

    }

   
}
