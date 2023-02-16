using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentProfile_RazorPages.Data;
using StudentProfile_RazorPages.Model;

namespace StudentProfile_RazorPages.Pages.Students
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
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
            if(Student.Age < 1)
            {
                ModelState.AddModelError("Student.Age", "Age cannot be less than 1.");
            }
            if (ModelState.IsValid)  
            {
                _db.StudentsTable.Update(Student);
                await _db.SaveChangesAsync();
                TempData["success"] = "Student Profile updated successfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
