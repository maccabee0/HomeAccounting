using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using HomeAccounting.UI.Commands;
using HomeAccounting.UI.Entities;
using HomeAccounting.UI.Annotations;
using HomeAccounting.UI.Concrete;

namespace HomeAccounting.UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //TODO:create monthly budget
        private DelegateCommand _newTransactionCommand;
        private DelegateCommand _newExchangeCommand;
        public event EventHandler<TransactionEventArgs> Transaction;
        public event EventHandler<ExchangeEventArgs> Exchange;
        public Dictionary<string, decimal> TotalsByCategory;
        private decimal _monthlyTotal;
        private decimal _firstWeekTotal;
        private decimal _secondWeekTotal;
        private decimal _thirdWeekTotal;
        private decimal _fourthWeekTotal;
        private DateTime _month;
        private IEnumerable<Transaction> _foodTransactions;
        private IEnumerable<Transaction> _thingsTransactions;
        private IEnumerable<Transaction> _funTransactions;
        private IEnumerable<Transaction> _transTransactions;
        private IEnumerable<Transaction> _eatOutTransactions;
        private IEnumerable<Exchange> _exchanges;
        private IEnumerable<Transaction> _flatTransactions;
        private decimal _dollarsLeft;
        private decimal _grivnyasLeft;
        private decimal _foodTotal;
        private decimal _transTotal;
        private decimal _funTotal;
        private decimal _exchangeTotal;
        private decimal _eatOutTotal;
        private decimal _thingsTotal;
        private decimal _flatPayment;
        private HaRepository _repository;

        public MainViewModel()
        {
            Month = DateTime.Now;
            _repository = new HaRepository(Month);
            UpdateViewModel();
            UpdateFlat();
        }

        public decimal MonthlyTotal
        {
            get { return _monthlyTotal; }
            set { _monthlyTotal = value; OnPropertyChanged(); }
        }

        public decimal FirstWeekTotal
        {
            get { return _firstWeekTotal; }
            set { _firstWeekTotal = value; OnPropertyChanged(); }
        }

        public decimal SecondWeekTotal
        {
            get { return _secondWeekTotal; }
            set { _secondWeekTotal = value; OnPropertyChanged(); }
        }

        public decimal ThirdWeekTotal
        {
            get { return _thirdWeekTotal; }
            set { _thirdWeekTotal = value; OnPropertyChanged(); }
        }

        public decimal FourthWeekTotal
        {
            get { return _fourthWeekTotal; }
            set { _fourthWeekTotal = value; OnPropertyChanged(); }
        }

        public DateTime Month
        {
            get { return _month; }
            set
            {
                _month = value;
                OnPropertyChanged();
                UpdateViewModel();
            }
        }

        public IEnumerable<Transaction> FoodTransactions
        {
            get { return _foodTransactions; }
            set { _foodTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Transaction> ThingsTransactions
        {
            get { return _thingsTransactions; }
            set { _thingsTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Transaction> FunTransactions
        {
            get { return _funTransactions; }
            set { _funTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Transaction> TransTransactions
        {
            get { return _transTransactions; }
            set { _transTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Transaction> EatOutTransactions
        {
            get { return _eatOutTransactions; }
            set { _eatOutTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Transaction> FlatTransations
        {
            get { return _flatTransactions; }
            set { _flatTransactions = value; OnPropertyChanged(); }
        }

        public IEnumerable<Exchange> Exchanges
        {
            get { return _exchanges; }
            set { _exchanges = value; OnPropertyChanged(); }
        }

        public decimal FlatPayment
        {
            get { return _flatPayment; }
            set { _flatPayment = value; OnPropertyChanged(); }
        }

        public decimal Dollars
        {
            get { return _dollarsLeft; }
            set { _dollarsLeft = value; OnPropertyChanged(); }
        }

        public decimal Grivnyas
        {
            get { return _grivnyasLeft; }
            set { _grivnyasLeft = value; OnPropertyChanged(); }
        }

        public decimal FoodTotal
        {
            get { return _foodTotal; }
            set { _foodTotal = value; OnPropertyChanged(); }
        }

        public decimal ThingsTotal
        {
            get { return _thingsTotal; }
            set { _thingsTotal = value; OnPropertyChanged(); }
        }

        public decimal TransTotal
        {
            get { return _transTotal; }
            set { _transTotal = value; OnPropertyChanged(); }
        }

        public decimal FunTotal
        {
            get { return _funTotal; }
            set { _funTotal = value; OnPropertyChanged(); }
        }

        public decimal ExchangeTotal
        {
            get { return _exchangeTotal; }
            set { _exchangeTotal = value; OnPropertyChanged(); }
        }

        public decimal EatOutTotal
        {
            get { return _eatOutTotal; }
            set { _eatOutTotal = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand NewTransactionCommand { get { return _newTransactionCommand ?? (_newTransactionCommand = new DelegateCommand(param => NewTransaction(new TransactionEventArgs()))); } }

        public DelegateCommand NewExchangeCommand { get { return _newExchangeCommand ?? (_newExchangeCommand = new DelegateCommand(param => NewExchange(new ExchangeEventArgs()))); } }

        protected virtual void NewTransaction(TransactionEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref Transaction, null, null);
            if(temp != null)
            {
                temp(this, e);
            }
        }

        public void OnSave(object sender, EventArgs e)
        {
            UpdateViewModel();
        }

        protected virtual void NewExchange(ExchangeEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref Exchange, null, null);
            if(temp != null)
            {
                temp(this, e);
            }
        }

        public void UpdateViewModel()
        {
            _repository.Month = Month;
            SetTotalsByCategory();
            UpdateTotals();
            UpdateFood();
            UpdateTrans();
            UpdateFun();
            UpdateThings();
            UpdateEatOut();
            Exchanges = _repository.Exchanges;
        }

        private void UpdateFlat()
        {
            FlatTransations = _repository.GetFlatTransation();
            FlatPayment = FlatTransations.Where(t => t.Date.Month == Month.Month).Sum(f => f.Amount);
        }

        private void UpdateEatOut()
        {
            EatOutTransactions = _repository.GetEatOutTransactions();
            EatOutTotal = EatOutTransactions.Sum(t => t.Amount);
        }

        private void UpdateThings()
        {
            ThingsTransactions = _repository.GetThingsTransactions();
            ThingsTotal = ThingsTransactions.Sum(t => t.Amount);
        }

        private void UpdateFun()
        {
            FunTransactions = _repository.GetFunTransactions();
            FunTotal = FunTransactions.Sum(t => t.Amount);
        }

        private void UpdateTrans()
        {
            TransTransactions = _repository.GetTransTransactions();
            TransTotal = TransTransactions.Sum(t => t.Amount);
        }

        private void UpdateFood()
        {
            FoodTransactions = _repository.GetFoodTransactions();
            FoodTotal = FoodTransactions.Sum(t => t.Amount);
        }

        private void UpdateTotals()
        {
            MonthlyTotal = _repository.MonthlyTransactions.Sum(t => t.Amount);
            FirstWeekTotal = _repository.FirstWeekTotal;
            SecondWeekTotal = _repository.SecondWeekTotal;
            ThirdWeekTotal = _repository.ThirdWeekTotal;
            FourthWeekTotal = _repository.FourthWeekTotal;
        }

        private void SetTotalsByCategory()
        {
            TotalsByCategory = new Dictionary<string, decimal>();
            var categories = _repository.Categories.ToDictionary(c => c.CategoryID, c => c.CategoryString);
            foreach(var category in categories)
            {
                var id = category.Key;
                TotalsByCategory.Add(category.Value,
                                     _repository.MonthlyTransactions
                                     .Where(t => t.CategoryID == id)
                                                .Sum(t => t.Amount));
            }
        }
    }
}
