using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem.DateService
{
    public class DateService : IDateService
    {
        private DateTimeOffset _fixedDateTime;

        public DateService()
        {
            
        }
        public DateTimeOffset GetCurrentDateTime()
        {
                return DateTimeOffset.UtcNow;
        }
    }
}
