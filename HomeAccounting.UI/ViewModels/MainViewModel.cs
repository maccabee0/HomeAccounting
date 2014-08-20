using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Collections.ObjectModel;

using HomeAccounting.Domain.Abstract;
using HomeAccounting.UI.Commands;
using HomeAccounting.Domain.Entities;
using HomeAccounting.UI.Annotations;
using HomeAccounting.Domain.Concrete;
using HomeAccounting.UI.EventArguments;

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
        private decimal _dollarsLeft;
        private decimal _grivnyasLeft;
        private IHaRepository _repository;

        public MainViewModel()
        //public MainViewModel(IHaRepository repository)
        {
            _repository = new HaRepository();
            //_repository = repository;
            CategoryViewModels = new ObservableCollection<CategoryViewModel>();
            Month = DateTime.Now;
            SetUpCategories();
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

        public ObservableCollection<CategoryViewModel> CategoryViewModels { get; set; }

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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand NewTransactionCommand { get { return _newTransactionCommand ?? (_newTransactionCommand = new DelegateCommand(param => NewTransaction(new TransactionEventArgs()))); } }

        public DelegateCommand NewExchangeCommand { get { return _newExchangeCommand ?? (_newExchangeCommand = new DelegateCommand(param => NewExchange(new ExchangeEventArgs()))); } }

        protected virtual void NewTransaction(TransactionEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref Transaction, null, null);
            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void OnSaveTransaction(object sender, TransactionEventArgs e)
        {
            UpdateViewModel();
            AddToCategory(e.transaction);
        }

        public void OnSaveExchange(object sender, ExchangeEventArgs e) { }

        protected virtual void NewExchange(ExchangeEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref Exchange, null, null);
            if (temp != null)
            {
                temp(this, e);
            }
        }

        private void AddToCategory(Transaction trans)
        {
            CategoryViewModels.FirstOrDefault(c => c.CategoryId == trans.CategoryID).AddToTransactions(trans);
        }

        private void UpdateViewModel()
        {
            //_repository.Month = Month;
            SetTotalsByCategory();
            UpdateTotals();
            UpdateCategoryDates(Month);
        }

        private void UpdateCategoryDates(DateTime date)
        {
            foreach (var cat in CategoryViewModels)
            {
                cat.UpdateDate(date);
            }
        }

        private void UpdateTotals()
        {
            MonthlyTotal = _repository.MonthlyTransactions(Month).Sum(t => t.Amount);
            FirstWeekTotal = _repository.FirstWeekTotal(Month);
            SecondWeekTotal = _repository.SecondWeekTotal(Month);
            ThirdWeekTotal = _repository.ThirdWeekTotal(Month);
            FourthWeekTotal = _repository.FourthWeekTotal(Month);
        }

        private void SetTotalsByCategory()
        {
            TotalsByCategory = new Dictionary<string, decimal>();
            var categories = _repository.Categories.ToDictionary(c => c.CategoryID, c => c.CategoryString);
            foreach (var category in categories)
            {
                var id = category.Key;
                TotalsByCategory.Add(category.Value,
                                     _repository.MonthlyTransactions(Month)
                                     .Where(t => t.CategoryID == id)
                                                .Sum(t => t.Amount));
            }
        }

        private void SetUpCategories()
        {
            foreach (var cat in _repository.Categories)
            {
                CategoryViewModels.Add(new CategoryViewModel(cat, Month));
            }
        }
    }
}
