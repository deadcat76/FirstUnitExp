using System;
using System.Collections.Generic;
using System.Text;

namespace BankSystem
{
    public class AccountAction
    {

        public ActionType Type { get; set; }

        public double Amount { get; set; }


        public override string ToString()
        {
            return Type.ToString() + "\n" + Amount + "\n\n";
        }

        public static implicit operator List<object>(AccountAction v)
        {
            throw new NotImplementedException();
        }
    }
}
