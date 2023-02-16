using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentProfile_RazorPages.Data;
using StudentProfile_RazorPages.Model;

namespace StudentProfile_RazorPages.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Student> Students { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Students = _db.StudentsTable;
        }
    }
}
