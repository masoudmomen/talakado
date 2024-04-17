namespace Talakado.Application.Visitors.GetDailyReports
{
    public class GeneralStateDto
    {
        public long TotalPageViews { get; set; }
        public long TotalVisitor { get; set; }
        public float PageViewsPerVisit { get; set;}
        public VisitCountDto VisitPerDay { get; set; }
    }
}
