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
using HomeAccounting.UI.ViewModels;

namespace HomeAccounting.UI.Views
{
    /// <summary>
    /// Interaction logic for SaveExchange.xaml
    /// </summary>
    public partial class ExchangeWindow : Window
    {
        private ExchangeViewModel _x;
        public ExchangeWindow()
        {
            InitializeComponent();
            _x = (ExchangeViewModel) Grd1.DataContext;
            _x.SaveExchange += OnSave;
        }

        private void OnSave(object sender, EventArgs e)
        {
            _x.SaveExchange -= OnSave;
            Cancel(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            Grd1.DataContext = new ExchangeViewModel();
            Close();
        }
    }
}
