using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesFin.Core.Models.Reports
{
        public record IncomesByCategory(string UserId, string Category, int Year, decimal Incomes);
        
}