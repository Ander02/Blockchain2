using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Model
{
    public class TransactionBody
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }
    }
}
