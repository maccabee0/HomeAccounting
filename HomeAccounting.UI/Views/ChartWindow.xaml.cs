using System;
using System.Collections.Generic;

namespace HomeAccounting.UI.Views
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class ChartWindow
    {
        public ChartWindow(Dictionary<string, decimal> categoryTotals)
        {
            InitializeComponent();
            TotalByCategory = categoryTotals;
            Chart.DataContext = TotalByCategory;
        }

        private Dictionary<string, decimal> TotalByCategory { get; set; }

        private void Close(object sender, EventArgs e)
        {
            Close();
        }
    }
}
