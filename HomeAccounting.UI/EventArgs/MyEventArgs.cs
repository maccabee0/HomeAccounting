using System;

using HomeAccounting.Domain.Entities;

namespace HomeAccounting.UI.EventArguments
{
    public class TransactionEventArgs : EventArgs
    {
        public readonly Transaction transaction;
        public TransactionEventArgs() { }
        public TransactionEventArgs(Transaction trans)
        {
            this.transaction = trans;
        }
    }

    public class ExchangeEventArgs : EventArgs
    {

    }
}
