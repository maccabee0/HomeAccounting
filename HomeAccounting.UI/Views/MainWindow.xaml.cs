using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HomeAccounting.UI.Entities;
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
            mainViewModel = (MainViewModel)this.Grd1.DataContext;
            mainViewModel.Transaction += NewTransaction;
            mainViewModel.Exchange += NewExchange;
        }

        private void NewTransaction(object sender, TransactionEventArgs e)
        {
            var twindow = e.transaction != null ? new TransactionWindow(e.transaction) : new TransactionWindow();
            var t = (TransactionViewModel)twindow.Grd1.DataContext;
            t.SaveTrans += mainViewModel.OnSaveTransaction;
            twindow.ShowDialog();
            t.SaveTrans -= mainViewModel.OnSaveTransaction;
        }

        private void NewExchange(object sender, ExchangeEventArgs e)
        {
            var ewindow = new ExchangeWindow();
            var x = (ExchangeViewModel)ewindow.Grd1.DataContext;
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

        private void Transactions_OnFilter(object sender, FilterEventArgs e)
        {
            var t = e.Item as Transaction;
            if (t == null) return;
            var mDate = mainViewModel.Month;
            var tDate = t.Date;
            if (mDate.Month == tDate.Month && mDate.Year == tDate.Year)
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
}
