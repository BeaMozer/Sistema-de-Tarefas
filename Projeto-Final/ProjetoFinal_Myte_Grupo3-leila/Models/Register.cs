using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal_Myte_Grupo3.Models
{
    public class Register
    {
        [Display(Name = "Registro - ID")]
        public int RegisterId { get; set; }

        [Display(Name = "Funcionário")]
        public Employee? Employee { get; set; }

        public int EmployeeId { get; set; }

        [Display(Name = "Código")]
        public WBS? WBS { get; set; }

        public int WBSId { get; set; }

        [Display(Name = "Horas Trabalhadas")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(8, 12, ErrorMessage = "O valor deve estar entre 8 e 12 horas.")]
        public double WorkHours { get; set; }

        [Display(Name = "Dia da Semana")]
        public DateTime DayOfWeek { get; set; }

    }
}
