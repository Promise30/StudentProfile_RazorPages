using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentProfile_RazorPages.Data;
using StudentProfile_RazorPages.Model;

namespace StudentProfile_RazorPages.Pages.Students
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Student Student { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(Student.Age < 1)
            {
                ModelState.AddModelError("Student.Age", "Age cannot be less than 1.");
            }
            if (ModelState.IsValid)  
            {
                await _db.StudentsTable.AddAsync(Student);
                await _db.SaveChangesAsync();
                TempData["success"] = "Student Profile created successfully";
                return RedirectToPage("index");
            }
            return Page();
        }
    }
}
