using System.Collections.Generic;

namespace BlockchainPlayground.Model
{
    public class Block
    {
        public class BContent
        {
            public int Number { get; set; }
            public double Nounce { get; set; }
            public string Miner { get; set; }
            public IEnumerable<Transaction> Transactions { get; set; }
            public string Previous { get; set; }
        }
        public BContent Content { get; set; }
        public double Size
        {
            get;
            //{
            //var @string = JsonConvert.SerializeObject(Content) + Hash;

            //@string.
            //}

        }
        public string Hash { get; set; }

    }
}
