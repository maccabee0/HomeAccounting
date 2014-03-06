using System;
using System.Collections.Generic;
using System.Threading;
using HomeAccounting.UI.Commands;
using HomeAccounting.UI.Concrete;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.ViewModels
{
    public class TransactionViewModel
    {
        private DelegateCommand _saveCommand;
        public event EventHandler<TransactionEventArgs> SaveTrans;
        public int TransID { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        private bool? PaidOnCard;
        public IEnumerable<Category> Categories { get { return Repository.Categories; } }
        private HaRepository Repository { get; set; }

        public TransactionViewModel()
        {
            Repository = new HaRepository();
            Date = DateTime.Now;
            SelectedCategoryId = 1;
        }

        public TransactionViewModel(Transaction transaction)
        {
            TransID = transaction.Id;
            SelectedCategoryId = transaction.CategoryID;
            Date = transaction.Date;
            PaidOnCard = transaction.PaidOnCard;
        }

        public int SelectedCategoryId { get; set; }

        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(param => Save())); } }

        private void Save()
        {
            Repository.SaveTransaction(ValidateTransaction());
            OnSave(new TransactionEventArgs());
        }

        private Transaction ValidateTransaction()
        {
            var trans=new Transaction();
            if (TransID == 0)
            {
                if (Amount > 0)
                    trans = new Transaction {Date = Date, CategoryID = SelectedCategoryId, Amount = Amount};
            }
            else
            {
                if (Amount > 0)
                {
                    trans = new Transaction
                        {
                            Id = TransID,
                            Date = Date,
                            CategoryID = SelectedCategoryId,
                            Amount = Amount
                        };
                }
                else
                {
                    trans = new Transaction {Id = TransID};
                }
            }
            return trans;
        }

        private void OnSave(TransactionEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref SaveTrans, null, null);
            if(temp != null)
            {
                temp(this, e);
            }
        }

        public void Clear()
        {
            TransID = 0;
            SelectedCategoryId = 1;
            Date=new DateTime();
            Amount = 0;
        }
    }
}
