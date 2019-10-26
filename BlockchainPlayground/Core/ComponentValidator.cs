using BlockchainPlayground.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainPlayground.Core
{
    public static class ComponentValidator
    {
        public static bool IsValid(this Block block)
        {
            return block.Hash.StartsWith("0000");
        }
    }
}
