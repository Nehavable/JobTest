namespace JobOpeningTest.Modules
{
    public class UpdateVacancyRequest
    {
        public Guid id {  get; set; }
       public string title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}
