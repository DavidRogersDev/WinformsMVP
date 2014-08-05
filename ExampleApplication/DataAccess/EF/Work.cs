namespace ExampleApplication.DataAccess.EF
{
    public partial class Work
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public decimal duration { get; set; }
        public string description { get; set; }
        public System.DateTime dateOfWork { get; set; }
        public virtual Task Task { get; set; }
    }
}
