namespace ExampleApplication.DataAccess.EF
{
    public partial class Work
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public decimal Duration { get; set; }
        public string Description { get; set; }
        public System.DateTime DateOfWork { get; set; }
        public virtual Task Task { get; set; }
    }
}
