using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }


        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [Display(Name = "Nome da Tarefa")]
        public string? AssignmentName { get; set; }

        [Display(Name = "Descrição")]
        public string? Description { get; set; }


        [Display(Name = "Data de Início")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Data Final")]
        public DateTime? EndDate { get; set; }

        
        public string? Status { get; set; }

        public Assignment()
        {
            Status = "Por fazer";
        }

    }
}
