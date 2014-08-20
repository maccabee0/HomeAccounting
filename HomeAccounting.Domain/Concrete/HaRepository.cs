using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using HomeAccounting.Domain.Abstract;
using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Domain.Concrete
{
  public class HaRepository : IHaRepository
    {
        private readonly HaContext _context;

        public HaRepository()
        {
            _context = new HaContext();
        }

        public IEnumerable<Transaction> Transactions { get { return _context.Transactions.ToList(); } }
        public IEnumerable<Exchange> Exchanges { get { return _context.Exchanges.ToList(); } }
        public IEnumerable<Category> Categories { get { return _context.Categories.ToList(); } }

        public IEnumerable<Transaction> MonthlyTransactions(DateTime date) { return Transactions.Where(t => t.Date.Month == date.Month && t.Date.Year == date.Year); }
        public decimal FirstWeekTotal(DateTime date) { return MonthlyTransactions(date).Where(t => t.Date.Day < 8 && t.Date.Day >= 1).Sum(t => t.Amount); }
        public decimal SecondWeekTotal(DateTime date) { return MonthlyTransactions(date).Where(t => t.Date.Day < 15 && t.Date.Day >= 8).Sum(t => t.Amount); }
        public decimal ThirdWeekTotal(DateTime date) { return MonthlyTransactions(date).Where(t => t.Date.Day < 22 && t.Date.Day >= 15).Sum(t => t.Amount); }
        public decimal FourthWeekTotal(DateTime date) { return MonthlyTransactions(date).Where(t => t.Date.Day > 22).Sum(t => t.Amount); }
      
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