using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

using HomeAccounting.UI.Annotations;
using HomeAccounting.UI.Commands;
using HomeAccounting.UI.Concrete;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.ViewModels
{
    public class TransactionViewModel : INotifyPropertyChanged
    {

        private DelegateCommand _saveCommand;
        public event EventHandler<TransactionEventArgs> SaveTrans;
        private int _selectedCategoryId;
        private int _transId;
        private DateTime _date;
        private decimal _amount;
        private bool? _paidOnCard;
        public IEnumerable<Category> Categories { get { return Repository.Categories; } }
        private HaRepository Repository { get; set; }

        public TransactionViewModel()
        {
            Repository = new HaRepository();
            _date = DateTime.Now;
            SelectedCategoryId = 1;
        }

        public TransactionViewModel(Transaction transaction)
        {
            Repository = new HaRepository();
            _transId = transaction.Id;
            SelectedCategoryId = transaction.CategoryID;
            _date = transaction.Date;
            _paidOnCard = transaction.PaidOnCard;
        }

        public int SelectedCategoryId { get { return _selectedCategoryId; } set { _selectedCategoryId = value; OnPropertyChanged(); } }

        public int TransactionId { get { return _transId; } set { _transId = value; OnPropertyChanged(); } }

        public decimal Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }

        public DateTime Date { get { return _date; } set { _date = value; OnPropertyChanged(); } }

        public bool? PaidOnCard { get { return _paidOnCard; } set { _paidOnCard = value; OnPropertyChanged(); } }

        public DelegateCommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new DelegateCommand(param => Save())); } }

        private void Save()
        {
            var trans = Repository.SaveTransaction(ValidateTransaction());
            OnSave(new TransactionEventArgs(trans));
        }

        private Transaction ValidateTransaction()
        {
            var trans = new Transaction();
            if (_transId == 0)
            {
                if (_amount > 0)
                    trans = new Transaction { Date = _date, CategoryID = SelectedCategoryId, Amount = _amount };
            }
            else
            {
                if (_amount > 0)
                {
                    trans = new Transaction
                        {
                            Id = _transId,
                            Date = _date,
                            CategoryID = SelectedCategoryId,
                            Amount = _amount
                        };
                }
                else
                {
                    trans = new Transaction { Id = _transId };
                }
            }
            return trans;
        }

        private void OnSave(TransactionEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref SaveTrans, null, null);
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void Clear()
        {
            _transId = 0;
            SelectedCategoryId = 1;
            _date = DateTime.Now;
            _amount = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
