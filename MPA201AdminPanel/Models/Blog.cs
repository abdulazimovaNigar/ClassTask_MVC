namespace MPA201AdminPanel.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime PostedDate { get; set; }
        public string ImageName { get; set; }
        public string ImageURL { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
