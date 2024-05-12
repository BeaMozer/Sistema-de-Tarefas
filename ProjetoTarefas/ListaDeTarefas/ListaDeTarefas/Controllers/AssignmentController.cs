using ListaDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;


namespace ListaDeTarefas.Controllers
{
    public class AssignmentController : Controller
    {
        private static List<Assignment> _assignments = new List<Assignment>()
        {
            new Assignment {AssignmentId = 1, AssignmentName = "Tirar o Lixo", Description = "", StartDate = new DateTime(2024,05,10, 8, 0, 0), EndDate = new DateTime(2024,05,12, 17, 0, 0), Status = "Feito"},
            new Assignment {AssignmentId = 2, AssignmentName = "Projeto da 4ª Semana",Description = "", StartDate = new DateTime(2024,05,10, 9, 30, 0), EndDate = new DateTime(2024,05,25, 17, 0, 0), Status = "Por fazer"},
            new Assignment {AssignmentId = 3, AssignmentName = "Ir ao Mercado", Description = "", StartDate = new DateTime(2024,05,10, 8, 0, 0), EndDate = new DateTime(2024,05,12, 17, 0, 0), Status = "Feito"},
            new Assignment {AssignmentId = 4, AssignmentName = "Estudar para Certificação", Description = "PL-900", StartDate = new DateTime(2024,05,10, 8, 0, 0), EndDate = new DateTime(2024,05,12, 17, 0, 0), Status = "Por fazer"},
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
        public IActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                // Define a StartDate como a data atual
                assignment.StartDate = DateTime.Now;

                assignment.AssignmentId = _assignments.Count > 0 ? _assignments.Max(t => t.AssignmentId) + 1 : 1;
                _assignments.Add(assignment);
                return RedirectToAction("Index");
            }

            if (string.IsNullOrWhiteSpace(assignment.AssignmentName))
            {
                ModelState.AddModelError("", "O nome da tarefa é obrigatório.");
            }

            return View(assignment);
        }



        public IActionResult Delete(int id)
        {
            var assignment = _assignments.FirstOrDefault(t => t.AssignmentId == id);
            if (assignment == null)
                return NotFound();

            _assignments.Remove(assignment);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var assignment = _assignments.FirstOrDefault(t => t.AssignmentId == id);
            if (assignment == null)
                return NotFound();

            return View(assignment);
        }

        [HttpPost]
        public IActionResult Edit(Assignment assignment)
        {
            if (ModelState.IsValid)
            {

                if (assignment.Status == "Feito")
                {
                    assignment.EndDate = DateTime.Now;
                }

                var existingAssignment = _assignments.FirstOrDefault(t => t.AssignmentId == assignment.AssignmentId);
                if (existingAssignment != null)
                {
                    existingAssignment.AssignmentName = assignment.AssignmentName;
                    existingAssignment.Description = assignment.Description;
                    existingAssignment.StartDate = assignment.StartDate;
                    existingAssignment.EndDate = assignment.EndDate;
                    existingAssignment.Status = assignment.Status;
                }
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        public IActionResult Details(int id)
        {
            var assignment = _assignments.FirstOrDefault(t => t.AssignmentId == id);
            if (assignment == null)
                return NotFound();

            return View(assignment);
        }

        public IActionResult ToDo()
        {
            var tasksToDo = _assignments.Where(t => t.Status == "Por fazer").ToList();
            return View(tasksToDo);
        }

        public IActionResult Done()
        {
            var tasksDone = _assignments.Where(t => t.Status == "Feito").ToList();
            return View(tasksDone);
        }
    }
}
