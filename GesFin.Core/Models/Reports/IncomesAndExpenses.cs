using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesFin.Core.Models.Reports
{
   public record IncomesAndExpenses(string UserId, int Month, int Year, decimal Incomes, decimal Expenses);
   
}