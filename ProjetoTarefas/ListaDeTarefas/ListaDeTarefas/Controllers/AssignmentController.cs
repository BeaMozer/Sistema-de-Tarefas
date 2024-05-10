using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;


namespace ListaDeTarefas.Controllers
{
    public class AssignmentController : Controller
    {
        private static List<Assignment> _assignments = new List<Assignment>()
        {
            new Assignment {AssignmentId = 1, AssignmentName = "Tirar o Lixo", Description = "", StartDate = new DateTime(2024,05,10, 8, 0, 0), EndDate = new DateTime(2024,05,12, 17, 0, 0), Status = "Concluído"},
            new Assignment {AssignmentId = 1, AssignmentName = "Projeto da 4ª Semana",Description = "", StartDate = new DateTime(2024,05,10, 9, 30, 0), EndDate = new DateTime(2024,05,25, 17, 0, 0), Status = "Concluído"},
        };
        public IActionResult Index()
        {
            return View(_assignments);
        }

        [HttpGet] 
        public IActionResult Create()
        { 
            return View();
        }


        [HttpPost]
        public IActionResult Create (Assignment assignment)
        {
            if(ModelState.IsValid)
            {
                assignment.AssignmentId = _assignments.Count > 0 ? _assignments.Max(t => t.AssignmentId) + 1 : 1;
                _assignments.Add(assignment);
            }
            return RedirectToAction("Index");
        }


    }
}
