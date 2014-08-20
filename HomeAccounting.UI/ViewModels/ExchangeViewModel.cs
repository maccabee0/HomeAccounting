using System;
using System.Threading;

using HomeAccounting.Domain.Abstract;
using HomeAccounting.Domain.Concrete;
using HomeAccounting.UI.Commands;
using HomeAccounting.Domain.Entities;
using HomeAccounting.UI.EventArguments;

namespace HomeAccounting.UI.ViewModels
{
    public class ExchangeViewModel
    {
        private DelegateCommand _saveCommand;
        public event EventHandler<ExchangeEventArgs> SaveExchange;
        public DateTime Date { get; set; }
        public decimal Dollars { get; set; }
        public decimal Rate { get; set; }
        private IHaRepository Repository { get; set; }

        public ExchangeViewModel()
        //public ExchangeViewModel(IHaRepository repository)
        {
            Repository = new HaRepository();
            //Repository = repository;
            Date = DateTime.Now;
        }
        public decimal Grivnya { get { return Dollars * Rate; } }

        public DelegateCommand SaveCommand
        {
            get { return _saveCommand ?? (_saveCommand = new DelegateCommand(x => Save(), x => CanSave())); }
        }

        public void Save()
        {
            Repository.SaveExchange(ValidateExchange());
            OnSave(new ExchangeEventArgs());
        }

        public Exchange ValidateExchange()
        {
            return new Exchange { Date = Date, Course = Rate, DollarAmount = Dollars };
        }

        protected virtual void OnSave(ExchangeEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref SaveExchange, null, null);
            if (temp != null)
            {
                temp(this, e);
            }
        }

        private bool CanSave()
        {
            return Dollars != 0 && Rate != 0;
        }

        public void Clear()
        {
            Date = DateTime.Now;
            Dollars = 0;
            Rate = 0;
        }
    }
}
