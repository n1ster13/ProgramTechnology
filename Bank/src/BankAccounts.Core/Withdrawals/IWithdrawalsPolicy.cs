using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccounts.Core.Withdrawals
{
    internal interface IWithdrawalsPolicy
    {
        IWithdrawalsPolicy Evaluate(decimal,currentBalance,)
    }
}
