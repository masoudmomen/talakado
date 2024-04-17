using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.Visitors.GetDailyReports
{
    public interface IGetDailyReportService
    {
        ResultDailyReportDto Execute();
    }
}
