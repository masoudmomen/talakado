using MongoDB.Driver;
using Talakado.Application.Contexts;
using Talakado.Domain.Visitors;

namespace Talakado.Application.Visitors.GetDailyReports
{
    public class GetDailyReportService : IGetDailyReportService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> visitorMongoCollection;
        public GetDailyReportService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext=mongoDbContext;
            visitorMongoCollection = _mongoDbContext.GetCollection();
        }
        public ResultDailyReportDto Execute()
        {
            DateTime start = DateTime.Now.Date;
            DateTime end = DateTime.Now.AddDays(1);

            var TodayPageViewCount = visitorMongoCollection.AsQueryable().Where(p => p.Time >= start && p.Time < end).LongCount();
            var TodayVisitorCount = visitorMongoCollection.AsQueryable().Where(p => p.Time >= start && p.Time < end).GroupBy(p => p.VisitorId).LongCount();
            var AllPageViewCount = visitorMongoCollection.AsQueryable().LongCount();
            var AllVisitorCount = visitorMongoCollection.AsQueryable().GroupBy(p => p.VisitorId).LongCount();

            //محاسبه بازدید 24 ساعت اخیر
            VisitCountDto visitPerHour = GetVisitPerHour(start, end);

            //محاسبه بازدید 30 روز اخیر
            VisitCountDto visitPerDay = GetVisitorPerDay();


            var visitors = visitorMongoCollection.AsQueryable()
                .OrderByDescending(p => p.Time)
                .Take(10)
                .Select(p => new VisitorDto
                {
                    Id = p.Id,
                    Browser = p.Browser.Family,
                    CurrentLink = p.CurrentLink,
                    Time = p.Time,
                    Ip = p.Ip,
                    IsSpider = p.Device.IsSpider,
                    OperationSystem = p.OperationSystem.Family,
                    ReferrerLink = p.ReferrerLink,
                    VisitorId = p.VisitorId
                }).ToList();
            return new ResultDailyReportDto
            {
                GeneralState = new GeneralStateDto
                {
                    TotalPageViews = AllPageViewCount,
                    TotalVisitor = AllVisitorCount,
                    PageViewsPerVisit = GetAvrage(AllPageViewCount, AllVisitorCount),
                    VisitPerDay = visitPerDay
                },
                Today = new TodayDto
                {
                    PageViews = TodayPageViewCount,
                    Visitors = TodayVisitorCount,
                    ViewsPerVisitor = GetAvrage(TodayPageViewCount, TodayVisitorCount),
                    VisitPerHour = visitPerHour
                },
                Visitors = visitors
            };
        }

        private VisitCountDto GetVisitPerHour(DateTime start, DateTime end)
        {
            var TodayPageViewList = visitorMongoCollection.AsQueryable().Where(p => p.Time >= start && p.Time < end).Select(p => new { p.Time }).ToList();
            VisitCountDto visitPerHour = new VisitCountDto
            {
                Display = new string[24],
                Value = new int[24]
            };
            for (int i = 0; i <= 23; i++)
            {
                visitPerHour.Display[i] = $"h {i}";
                visitPerHour.Value[i] = TodayPageViewList.Where(p => p.Time.Hour == i).Count();
            }

            return visitPerHour;
        }

        private VisitCountDto GetVisitorPerDay()
        {
            DateTime MonthStart = DateTime.Now.Date.AddDays(-30);
            DateTime MonthEnd = DateTime.Now.Date.AddDays(1);
            var month_PageViewList = visitorMongoCollection.AsQueryable().Where(p => p.Time >= MonthStart && p.Time < MonthEnd).Select(p => new { p.Time }).ToList();

            VisitCountDto visitPerDay = new VisitCountDto { Display = new string[30], Value = new int[30] };
            for (var i = 0; i < 30; i++)
            {
                var currentDay = DateTime.Now.Date.AddDays(i * (-1));
                visitPerDay.Display[i] = i.ToString();
                visitPerDay.Value[i] = month_PageViewList.Where(p => p.Time.Date == currentDay.Date).Count();
            }

            return visitPerDay;
        }

        public float GetAvrage(long pageViewCount, long visitors)
        {
            if (visitors == 0) return 0;
            return pageViewCount/ visitors;

        }
    }
}
