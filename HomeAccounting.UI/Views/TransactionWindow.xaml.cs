using System;
using System.ComponentModel;
using System.Windows;

using HomeAccounting.UI.Entities;
using HomeAccounting.UI.ViewModels;

namespace HomeAccounting.UI.Views
{
    /// <summary>
    /// Interaction logic for TransactionWindow.xaml
    /// </summary>
    public partial class TransactionWindow : Window
    {
        private TransactionViewModel t;
        public TransactionWindow()
        {
            InitializeComponent();
            t = (TransactionViewModel)Grd1.DataContext;
            t.SaveTrans += OnSave;
        }

        public TransactionWindow(Transaction transaction):this()
        {
            t.SelectedCategoryId = transaction.CategoryID;
            t.Date = transaction.Date;
            t.Amount = transaction.Amount;
            t.TransactionId = transaction.Id;
            t.PaidOnCard = transaction.PaidOnCard;
        }

        private void OnSave(object sender, TransactionEventArgs e)
        {
            t.SaveTrans -= OnSave;
            Cancel(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            //t.Clear();
            Close();
        }

        private void TransactionWindow_OnClosed(object sender, EventArgs e)
        {
            t.Clear();
        }
    }
}
