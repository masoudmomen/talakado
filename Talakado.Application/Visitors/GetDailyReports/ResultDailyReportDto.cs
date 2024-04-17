namespace Talakado.Application.Visitors.GetDailyReports
{
    public class ResultDailyReportDto
    {
        public GeneralStateDto GeneralState { get; set; }
        public TodayDto Today { get; set; }
        public List<VisitorDto> Visitors { get; set; }
    }
}
