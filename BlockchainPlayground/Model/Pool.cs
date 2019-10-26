using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Model
{
    public class Pool
    {
        public event Action<PoolTransaction> TransactionAdded;
        public event Action<PoolTransaction> TransactionRemoved;
        public event Action<PoolTransaction> TransactionInvalidated;

        public Pool()
        {
            Transactions.CollectionChanged += OnTransactionsChanged;
        }

        private void OnTransactionsChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //e.
            //Rewrite data 
        }

        public ObservableCollection<PoolTransaction> Transactions { get; set; }
        public long MaxSize { get; set; }
        public class PoolTransaction {

            public PoolTransaction(Transaction transaction)
            {
                Transaction = transaction;
                EnterDate = DateTime.Now;
            }

            public Transaction Transaction { get; }
            public DateTime EnterDate { get; set; }
        }

    }
}
