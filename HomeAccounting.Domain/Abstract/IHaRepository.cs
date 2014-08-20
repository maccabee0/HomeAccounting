using System;
using System.Collections.Generic;

using HomeAccounting.Domain.Entities;

namespace HomeAccounting.Domain.Abstract
{
    public interface IHaRepository
    {
        IEnumerable<Transaction> Transactions { get; }
        IEnumerable<Exchange> Exchanges { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<Transaction> MonthlyTransactions(DateTime date);
        decimal FirstWeekTotal(DateTime date);
        decimal SecondWeekTotal(DateTime date);
        decimal ThirdWeekTotal(DateTime date);
        decimal FourthWeekTotal(DateTime date);
        Transaction SaveTransaction(Transaction trans);
        void SaveExchange(Exchange exchange);
        Category GetCategory(int id);
        Category GetCategory(string category);
    }
}
