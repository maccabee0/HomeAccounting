using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows.Data;
using System.Reflection;

using HomeAccounting.UI.Entities;
using HomeAccounting.UI.Annotations;

namespace HomeAccounting.UI.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private string _category;
        private ObservableCollection<Transaction> _transactions;
        //private decimal _total;
        private DateTime _date;

        public CategoryViewModel()
        {
        }

        public CategoryViewModel(Category cat, DateTime date)
        {
            CategoryId = cat.CategoryID;
            Category = cat.CategoryString;
            Transactions =
                new ObservableCollection<Transaction>(
                    cat.Transactions.OrderByDescending(t => t.Date)
                       .ToList());
            //Total = Transactions.Sum(t => t.Amount);
            Date = date;

            //FiltereredTransactions =
            //    CollectionViewSource.GetDefaultView(
            //        Transactions.Where(t => t.Date.Month == Date.Month && t.Date.Year == Date.Year));
        }

        public int CategoryId { get; private set; }

        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Transaction> Transactions
        {
            get
            {
                return _transactions;
                //new ObservableCollection<Transaction>(_transactions.Where(t => t.Date.Month == Date.Month && t.Date.Year == Date.Year));
            }
            set
            {
                _transactions = value;
                OnPropertyChanged();
            }
        }

        public ICollectionView FilteredTransactions
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(Transactions);
                source.Filter = t => Filter((Transaction)t);
                return source;
            }
        }

        public decimal Total
        {
            get { return Transactions.Where(t => t.Date.Month == Date.Month && t.Date.Year == Date.Year).Sum(t => t.Amount); } /* set { _total = value; OnPropertyChanged(); }*/
        }

        private DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                FilteredTransactions.Refresh();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddToTransactions(Transaction transaction)
        {
            var trans = Transactions.FirstOrDefault(t => t.Date < transaction.Date);
            var index = Transactions.IndexOf(trans);
            Transactions.Insert(index, transaction);
            FilteredTransactions.Refresh();
        }

        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

        private bool Filter(Transaction transaction)
        {
            var tDate = transaction.Date;
            return tDate.Year == Date.Year && tDate.Month == Date.Month;
        }
    }
}
