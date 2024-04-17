using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Talakado.Application.Visitors.GetDailyReports;
using Talakado.Application.Visitors.OnlineVisitors;

namespace Talakado.AdminPanel.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetDailyReportService _getDailyReportService;
        private readonly IOnlineVisitorService _onlineVisitorService;
        public ResultDailyReportDto ResultDailyReport;
        public IndexModel(IGetDailyReportService getDailyReportService, IOnlineVisitorService onlineVisitorService)
        {
            _getDailyReportService = getDailyReportService;
            _onlineVisitorService = onlineVisitorService;
        }
        public void OnGet()
        {
            ResultDailyReport = _getDailyReportService.Execute();
            ViewData["OnlineVisitor"] = _onlineVisitorService.GetCount();
        }
    }
}
