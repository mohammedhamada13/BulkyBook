using BulkyBook.DataAccess;
using BulkyBook.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Authorize(Roles =SD.AdminRole)]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // هنا انا عاوز اعرض جميع اليوزر الي موجودين عندي معاده اليوزر الي مسجل بيه دخول 
            // الثلاثه سطور دول معنهم اني بجيب الId الموجود واتحقق منه 
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string userid = claim.Value;

            // هنا بعرض لسته من اليوزر الموجوده كلها ولكن بقوله متعرضش اليوزر المسجل حاليا 
            return View(_context.ApplicationUsers.Where(x=>x.Id != userid).ToList());
        }

        public IActionResult LockUnlock(string? id)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.LockoutEnd == null || user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now.AddYears(1);
            }
            else
            {
                user.LockoutEnd = DateTime.Now;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Users", new {area = "Admin"});
        }
    }
}
