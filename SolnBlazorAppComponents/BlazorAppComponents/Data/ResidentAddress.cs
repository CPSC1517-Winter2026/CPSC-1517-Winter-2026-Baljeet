using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record ResidentAddress(int Number, string Street, string City, string Province, string PostalCode)
    {
        public override string ToString()
        {
            //this string is known as a "comma separate value" string (csv)
            return $"{Number},{Street},{Province},{PostalCode}";
        }
    }
}
