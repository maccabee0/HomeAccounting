﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HomeAccounting.UI.Entities;

namespace HomeAccounting.UI.Concrete
{
    public class HaRepository
    {
        private readonly IEnumerable<Transaction> _monthsTransactions;
        private readonly IEnumerable<Exchange> _monthsExchanges;
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
            _monthsTransactions = GetTransactionForMonth(Month);
            _monthsExchanges = GetExchangesForMonth(month);
        }
        public DateTime Month { get; set; }
        public IEnumerable<Transaction> Transactions { get { return _context.Transactions.ToList(); } }
        public IEnumerable<Exchange> Exchanges { get { return _context.Exchanges.ToList(); } }
        public IEnumerable<Category> Categories { get { return _context.Categories.ToList(); } }

        public IEnumerable<Transaction> MonthlyTransactions { get { return _monthsTransactions; } }
        public decimal FirstWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 8 && t.Date.Day >= 1).Sum(t => t.Amount); } }
        public decimal SecondWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 15 && t.Date.Day >= 8).Sum(t => t.Amount); } }
        public decimal ThirdWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day < 22 && t.Date.Day >= 15).Sum(t => t.Amount); } }
        public decimal FourthWeekTotal { get { return MonthlyTransactions.Where(t => t.Date.Day > 22).Sum(t => t.Amount); } }

        public IEnumerable<Exchange> MonthsExchanges { get { return _monthsExchanges; } }

        private IEnumerable<Transaction> GetTransactionForMonth(DateTime month)
        {
            return Transactions.Where(t => t.Date.Month == month.Month && t.Date.Year == month.Year);
        }

        public IEnumerable<Transaction> GetFoodTransactions()
        {
            return MonthlyTransactions.Where(t => t.Category == GetCategory("Food"));
        }

        public IEnumerable<Transaction> GetThingsTransactions()
        {
            return MonthlyTransactions.Where(t => t.Category == GetCategory("Things"));
        }

        public IEnumerable<Transaction> GetFunTransactions()
        {
            return MonthlyTransactions.Where(t => t.Category == GetCategory("Fun"));
        }

        public IEnumerable<Transaction> GetTransTransactions()
        {
            return MonthlyTransactions.Where(t => t.Category == GetCategory("Transport"));
        }

        public IEnumerable<Transaction> GetFlatTransation()
        {
            return Transactions.Where(t => t.Category == GetCategory("Flat"));
        }

        public IEnumerable<Transaction> GetEatOutTransactions()
        {
            return MonthlyTransactions.Where(t => t.Category == GetCategory("EatOut"));
        }

        private IEnumerable<Exchange> GetExchangesForMonth(DateTime month)
        {
            return Exchanges.Where(e => e.Date.Month == month.Month && e.Date.Year == month.Year);
        }

        public void SaveTransaction(Transaction trans)
        {
            if(trans.Id == 0)
            {
                _context.Transactions.Add(trans);
            }
            else
            {
                _context.Entry(trans).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void SaveExchange(Exchange exchange)
        {
            if(exchange.ExchangeID == 0)
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