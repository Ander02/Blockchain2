using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Model
{
    public class Blockchain
    {
        public IEnumerable<Block> Blocks { get; set; }
    }
}
