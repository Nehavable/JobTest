namespace JobOpeningTest.Modules
{
    public class AddVacancyRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
