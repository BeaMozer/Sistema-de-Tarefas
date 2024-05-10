namespace ListaDeTarefas.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public string? AssignmentName { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? Status { get; set; }

    }
}
