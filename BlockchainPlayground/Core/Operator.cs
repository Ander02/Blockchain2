using BlockchainPlayground.Model;
using BlockchainPlayground.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainPlayground.Core
{
    public class Operator
    {
        public Blockchain Chain { get; set; }
        public Pool Pool { get; set; }
        public Operator()
        {
            LoadChain();
            LoadPool();
        }

        private void LoadPool()
        {
        }

        private void LoadChain()
        {
        }

        public (string, string) RegisterUser()
        {
            return KeyManager.GenerateKeys();
        }

        public Transaction CreateTransaction(string body, string privateKey)
        {
            Transaction t = new Transaction()
            {
                StringBody = body,
                From = KeyManager.GeneratePublicKey(privateKey),
                Signature = KeyManager.SignMessage(body, privateKey)
            };


            return t;
        }

        public bool ValidateTransaction(Transaction transaction)
        {
            bool isValidSignature = KeyManager.ValidateMessage(transaction.From, transaction.StringBody, transaction.Signature);
            return isValidSignature && ValidateTransactionBody(transaction);
        }

        public bool ValidateTransactionBody(Transaction transaction)
        {
            string user = transaction.From;

            var input = Chain.Blocks.SelectMany(block => block.Content.Transactions).Where(_transaction => _transaction.Body.To == user).Sum(d => d.Body.Amount);
            var output = Chain.Blocks.SelectMany(block => block.Content.Transactions).Where(_transaction => _transaction.Body.From == user).Sum(d => d.Body.Amount + d.Body.Fee);

            var inputFees = Chain.Blocks.Where(d => d.Content.Miner == user).Sum(d => d.Content.Transactions.Sum(_transaction => _transaction.Body.Fee));
            output += transaction.Body.Amount + transaction.Body.Fee;
            input += inputFees;

            return input >= output;
        }

        public void ReceiveTransaction(Transaction transaction)
        {
            transaction.Status = TransactionStatus.Waiting;

            if (transaction.Size + Pool.Transactions.Sum(d => d.Transaction.Size) > Pool.MaxSize)
                throw new InvalidOperationException($"Impossible to include transaction ({transaction.Signature}) in the pool. The transaction exceds the available storage space.");

            Pool.Transactions.Add(new Pool.PoolTransaction(transaction));


        }


        public event Action<Block> BlockMinned;

        public void CreateBlock(string miner, string previous, IEnumerable<Transaction> transactions, long blockMaxSize)
        {
            Block block = new Block()
            {
                Content = new Block.BContent()
                {
                    Miner = miner,
                    Number = Chain.Blocks.Max(d => d.Content.Number) + 1,
                    Previous = previous,
                    Transactions = transactions,
                }
            };

           
            Thread blockMiningThread = new Thread(MineBlock(block, blockMaxSize))
            {

            };
            blockMiningThread.Start();
        }

        private ThreadStart MineBlock(Block block, long blockMaxSize)
        {
            block.Content.Nounce = double.MinValue;
            return () =>
            {
                do
                {
                    block.Content.Nounce++;
                    ComputeHash(block);

                }
                while (!block.IsValid());

                BlockMinned?.Invoke(block);
            };
        }

        private void ComputeHash(Block block)
        {
            string blockString = JsonConvert.SerializeObject(block.Content);
            block.Hash = blockString.GetSHA256String();
        }
    }
}
