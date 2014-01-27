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
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public IEnumerable<Category> Categories { get { return Repository.Categories; } }
        public HaRepository Repository { get; set; }

        public TransactionViewModel()
        {
            Repository = new HaRepository();
            Date = DateTime.Now;
            SelectedCategoryId = 1;
        }

        public int SelectedCategoryId { get; set; }

        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(param => Save())); } }

        public void Save()
        {
            Repository.SaveTransaction(ValidateTransaction());
            OnSave(new TransactionEventArgs());
        }

        private Transaction ValidateTransaction()
        {
            return new Transaction { Date = Date, CategoryID = SelectedCategoryId, Amount = Amount };
        }

        protected virtual void OnSave(TransactionEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref SaveTrans, null, null);
            if(temp != null)
            {
                temp(this, e);
            }
        }
    }
}
