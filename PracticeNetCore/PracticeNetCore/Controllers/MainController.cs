using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PracticeNetCore.Models;

namespace PracticeNetCore.Controllers
{
   
    public class MainController : Controller
    {

        /// <summary>
        /// HQHAI 21.03.2021
        /// </summary>
        AppDbContext Apc = null;
        public MainController(AppDbContext _appContext)
        {
            Apc = _appContext;
        }


        /// <summary>
        /// HQHAI 21.03.2021
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterNewUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterNewUser(SystemUsers U)
        {


            try
            {

                U.Role = "NhanVien";
                U.Status = "Active";
                Apc.SystemUsers.Add(U);
                Apc.SaveChanges();
                ViewBag.Message = "Tài khoản " + " " + U.UserName + " " + " đã được đăng ký thành công";
            }
            catch (Exception e)
            {
                ViewBag.Message = "Không thể tạo mới tài khoản, Vui lòng thử lại";
                Console.WriteLine(e.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (Request.Cookies["LastLoggedInTime"] != null)
            
                ViewBag.LTLD = Request.Cookies["LastLoggedInTime"].ToString(); //Lấy thời gian đăng nhập lần cuối
                return View();
            
        }

        [HttpPost]
        public IActionResult Login(SystemUsers U)
        {
            SystemUsers LoggedInUser = Apc.SystemUsers.Where(x => x.UserName == U.UserName && x.Password==U.Password).FirstOrDefault();
           
            if(LoggedInUser == null)
            {
                ViewBag.Message = "Đăng nhập thất bại, Vui lòng kiểm tra tài khoản hoặc mật khẩu";
                return View();

            }


            //lưu thông tin người dùng vào session

            HttpContext.Session.SetString("Username", LoggedInUser.UserName);
            HttpContext.Session.SetString("Role", LoggedInUser.Role);

            Response.Cookies.Append("LastLoggedInTime", DateTime.Now.ToString());

            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Login");
            }
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}
