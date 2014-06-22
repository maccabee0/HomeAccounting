using System;

namespace HomeAccounting.UI.Entities
{
    public class TransactionEventArgs : EventArgs
    {
        public Transaction transaction;
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
