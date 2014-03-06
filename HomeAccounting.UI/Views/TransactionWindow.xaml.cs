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
using System.Windows.Shapes;
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

        private void OnSave(object sender, TransactionEventArgs e)
        {
            t.SaveTrans -= OnSave;
            Cancel(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            t.Clear();
            Close();
        }
    }
}
