using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Model
{
    public class Transaction
    {
        [JsonIgnore]
        public virtual string StringBody 
        {
            get
            {
                return JsonConvert.SerializeObject(Body);
            }
            set
            {
                Body = JsonConvert.DeserializeObject<TransactionBody>(value);
            }
        }
        public virtual string Signature { get; set; }
        public virtual string From { get; set; }
        public long Size { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual TransactionBody Body { get; set; }
        

    }

    public enum TransactionStatus
    {
        Cancelled,
        Waiting,
        Minned
    }
}
