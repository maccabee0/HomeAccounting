using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;

using HomeAccounting.UI.Entities;
using HomeAccounting.UI.Annotations;

namespace HomeAccounting.UI.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private string _category;
        private ObservableCollection<Transaction> _transactions;
        private decimal _total;

        public CategoryViewModel(){}

        public CategoryViewModel(Category cat, DateTime date)
        {
            CategoryId = cat.CategoryID;
            Category = cat.CategoryString;
            Transactions =
                new ObservableCollection<Transaction>(
                    cat.Transactions.Where(t => t.Date.Month == date.Month && t.Date.Year == date.Year)
                       .OrderByDescending(t => t.Date)
                       .ToList());
            Total = Transactions.Sum(t => t.Amount);
        }

        public int CategoryId { get; private set; }

        public string Category { get { return _category; } set { _category = value; OnPropertyChanged(); } }

        public ObservableCollection<Transaction> Transactions { get { return _transactions; } set { _transactions = value; OnPropertyChanged(); } }

        public decimal Total { get { return _total; } set { _total = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddToTransactions(Transaction transaction) 
        {
            Transactions.Add(transaction);
        }
    }
}
