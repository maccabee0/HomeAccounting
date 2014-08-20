using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using HomeAccounting.Domain.Entities;
using HomeAccounting.UI.EventArguments;
using HomeAccounting.UI.ViewModels;

namespace HomeAccounting.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = (MainViewModel)this.DataContext;
            mainViewModel.Transaction += NewTransaction;
            mainViewModel.Exchange += NewExchange;
        }

        private void NewTransaction(object sender, TransactionEventArgs e)
        {
            var twindow = e.transaction != null ? new TransactionWindow(e.transaction) : new TransactionWindow();
            var t = (TransactionViewModel)twindow.DataContext;
            t.SaveTrans += mainViewModel.OnSaveTransaction;
            twindow.ShowDialog();
            t.SaveTrans -= mainViewModel.OnSaveTransaction;
        }

        private void NewExchange(object sender, ExchangeEventArgs e)
        {
            var ewindow = new ExchangeWindow();
            var x = (ExchangeViewModel)ewindow.DataContext;
            x.SaveExchange += mainViewModel.OnSaveExchange;
            ewindow.ShowDialog();
            x.SaveExchange -= mainViewModel.OnSaveExchange;
        }

        private void DisplayChart(object sender, EventArgs e)
        {
            var cwindow = new ChartWindow(mainViewModel.TotalsByCategory);
            cwindow.ShowDialog();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            var trans = row.Item as Transaction;
            NewTransaction(sender,new TransactionEventArgs(trans));
        }
    }
}
