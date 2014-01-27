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
            var twindow=new TransactionWindow();
            var t = (TransactionViewModel) twindow.Grd1.DataContext;
            t.SaveTrans += mainViewModel.OnSave;
            twindow.ShowDialog();
            t.SaveTrans -= mainViewModel.OnSave;
        }

        private void NewExchange(object sender, ExchangeEventArgs e)
        {
            var ewindow = new ExchangeWindow();
            var x = (ExchangeViewModel)ewindow.Grd1.DataContext;
            x.SaveExchange += mainViewModel.OnSave;
            ewindow.ShowDialog();
            x.SaveExchange -= mainViewModel.OnSave;
        }

        private void DisplayChart(object sender, EventArgs e)
        {
            var cwindow = new ChartWindow(mainViewModel.TotalsByCategory);
            cwindow.ShowDialog();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
