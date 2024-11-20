using BulkyBook.Entities.Repositories;
using BulkyBook.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.AdminRole)]
    public class DashboardController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //ViewBag.ShoppingCart = _unitOfWork.ShoppingCart.GetAll().Count();
            ViewBag.Category = _unitOfWork.Category.GetAll().Count();
            ViewBag.Users = _unitOfWork.ApplicationUser.GetAll().Count();
            ViewBag.Products = _unitOfWork.Product.GetAll().Count();
            return View();
        }
    }
}
