using System;
using System.Threading;
using System.Windows.Input;
using HomeAccounting.UI.Concrete;
using HomeAccounting.UI.Commands;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.ViewModels
{
    public class ExchangeViewModel
    {
        public DelegateCommand _saveCommand;
        public event EventHandler<ExchangeEventArgs> SaveExchange;
        public DateTime Date { get; set; }
        public decimal Dollars { get; set; }
        public decimal Rate { get; set; }
        private HaRepository Repository { get; set; }

        public ExchangeViewModel()
        {
            Repository = new HaRepository();
            Date = DateTime.Now;
        }
        public decimal Grivnya { get { return Dollars * Rate; } }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new DelegateCommand(x => Save())); }
        }
        
        public void Save()
        {
            Repository.SaveExchange(ValidateExchange());
            OnSave(new ExchangeEventArgs());
        }

        public Exchange ValidateExchange()
        {
            return new Exchange{Date = Date,Course = Rate,DollarAmount = Dollars};
        }

        protected virtual void OnSave(ExchangeEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref SaveExchange, null, null);
            if (temp!=null)
            {
                temp(this, e);
            }
        }
    }
}
