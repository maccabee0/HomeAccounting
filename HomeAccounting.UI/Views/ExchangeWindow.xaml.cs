using System;
using System.Windows;

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
            _x = (ExchangeViewModel) DataContext;
            _x.SaveExchange += OnSave;
        }

        private void OnSave(object sender, EventArgs e)
        {
            _x.SaveExchange -= OnSave;
            Cancel(sender, e);
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }

        private void ExchangeWindow_OnClosed(object sender, EventArgs e)
        {
            _x.Clear();
        }
    }
}
