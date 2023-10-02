using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTradeBackend.Infrastructure.Operations
{
    public static class RandomAlphaNumeric
    {
        public static string RandomAlphaNumericToString()
        {
            Random rn = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(chars.Select(x => chars[rn.Next(chars.Length)]).Take(16).ToArray());
        }
    }
}
