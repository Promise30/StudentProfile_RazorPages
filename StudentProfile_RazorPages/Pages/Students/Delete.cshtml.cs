using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentProfile_RazorPages.Data;
using StudentProfile_RazorPages.Model;

namespace StudentProfile_RazorPages.Pages.Students
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Student Student { get; set; }
        public void OnGet(int id)
        {
            Student = _db.StudentsTable.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            
                var studentFromDb = _db.StudentsTable.Find(Student.Id);
                if(studentFromDb != null)
                {
                    _db.StudentsTable.Remove(studentFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Student Profile deleted successfully";
                return RedirectToPage("index");
                }  
          
            return Page();
        }
    }
}
