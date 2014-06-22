using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.Concrete
{
    public class HaRepository
    {
        //private readonly IEnumerable<Transaction> _monthsTransactions;
        //private readonly IEnumerable<Exchange> _monthsExchanges;
        private readonly HaContext _context;

        public HaRepository()
        {
            _context = new HaContext();
            Month = DateTime.Now;
        }

        public HaRepository(DateTime month)
        {
            _context = new HaContext();
            Month = month;
            //_monthsTransactions = GetTransactionForMonth(Month);
            //_monthsExchanges = GetExchangesForMonth(month);
        }
        public DateTime Month { private get; set; }
        private IEnumerable<Transaction> Transactions { get { return _context.Transactions.ToList(); } }
        public IEnumerable<Exchange> Exchanges { get { return _context.Exchanges.ToList(); } }
        public IEnumerable<Category> Categories { get { return _context.Categories.ToList(); } }

        public IEnumerable<Transaction> MonthlyTransactions
        {
            get { return Transactions.Where(t => t.Date.Month == Month.Month && t.Date.Year == Month.Year); }
        }
        public decimal FirstWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 8 && t.Date.Day >= 1).Sum(t => t.Amount); } }
        public decimal SecondWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 15 && t.Date.Day >= 8).Sum(t => t.Amount); } }
        public decimal ThirdWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 22 && t.Date.Day >= 15).Sum(t => t.Amount); } }
        public decimal FourthWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day > 22).Sum(t => t.Amount); } }

        public IEnumerable<Exchange> MonthsExchanges
        {
            get { return Exchanges.Where(e => e.Date.Month == Month.Month && e.Date.Year == Month.Year); }
        }

        //private IEnumerable<Transaction> GetTransactionForMonth(DateTime month)
        //{
        //    return Transactions.OrderByDescending(t => t.Date).Where(t => t.Date.Month == month.Month && t.Date.Year == month.Year).ToList();
        //}

        public IEnumerable<Transaction> GetFoodTransactions()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("Food"));
        }

        public IEnumerable<Transaction> GetThingsTransactions()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("Things"));
        }

        public IEnumerable<Transaction> GetFunTransactions()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("Fun"));
        }

        public IEnumerable<Transaction> GetTransTransactions()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("Transit"));
        }

        public IEnumerable<Transaction> GetFlatTransation()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("Flat"));
        }

        public IEnumerable<Transaction> GetEatOutTransactions()
        {
            return MonthlyTransactions.OrderByDescending(t => t.Date).Where(t => t.Category == GetCategory("EatOut"));
        }

        private IEnumerable<Exchange> GetExchangesForMonth(DateTime month)
        {
            return Exchanges.OrderByDescending(t => t.Date).Where(e => e.Date.Month == month.Month && e.Date.Year == month.Year);
        }

        public Transaction SaveTransaction(Transaction trans)
        {
            if (trans.Id == 0)
            {
                _context.Transactions.Add(trans);
            }
            else
            {
                _context.Entry(trans).State = EntityState.Modified;
            }
            _context.SaveChanges();
            return trans;
        }

        public void SaveExchange(Exchange exchange)
        {
            if (exchange.ExchangeID == 0)
            {
                _context.Exchanges.Add(exchange);
            }
            else
            {
                _context.Entry(exchange).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public Category GetCategory(string category)
        {
            return Categories.FirstOrDefault(c => c.CategoryString == category);
        }
    }
}