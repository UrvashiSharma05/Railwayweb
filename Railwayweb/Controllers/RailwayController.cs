using Microsoft.AspNetCore.Mvc;
using Railwayweb.Models.Railway;
using Railwayweb.Models.RailwayDbContext;

namespace Railwayweb.Controllers
{
    ////TrainSearch controller
    public class RailwayController : Controller
    {
        private readonly RailwayDbContext context;

        public RailwayController(RailwayDbContext context)
        {
            this.context = context;
        }


        public JsonResult From()
        {
            var cnt = context.froms.ToList();
            return new JsonResult(cnt);

        }
        //For get To - Action method[Get To behalf on From id]
        public JsonResult To(int? id)
        {
            var st = context.tos.Where(e => e.From.Id == id).ToList();
            return new JsonResult(st);
        }
        public IActionResult TrainName(int? id)
        {
            var ct1 = context.trainnames.Where(e => e.To.Id == id).ToList();
            return new JsonResult(ct1);
        }
        //For get - Seat
        public JsonResult Seat()
        {
            var cnt1 = context.seats.ToList();
            return new JsonResult(cnt1);

        }
        public JsonResult Price(int? id)
        {
            var st1 = context.prices.Where(e => e.Seat.Id == id).ToList();
            return new JsonResult(st1);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginPage()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Add(Loginform customer)
        //{
        //    var employee = new Loginform()
        //    {


        //        Email = customer.Email,
        //        Password = customer.Password,
        //        Cpassword = customer.Cpassword
        //    };

        //    context.loginforms.Add(employee);
        //    context.SaveChanges();
        //    return View();
        //}
        [HttpGet]
        public IActionResult RegistraionPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage1(Loginform login)
        {
            var user = context.regisforms.FirstOrDefault(x => x.Email == login.Email);
            var pass = context.regisforms.FirstOrDefault(x => x.Password == login.Password);
            var pass1 = context.regisforms.FirstOrDefault(x => x.Cpassword == login.Cpassword);


            if (user != null && pass != null && pass1 != null)
            {

                return RedirectToAction("BookingPage", "Railway");
            }
            else
            {
                ModelState.AddModelError("LoginPageError", "Invalid username or password");
            }
            return RedirectToAction("LoginPage", "Railway");
        }


        //[HttpGet]
        //public IActionResult RegisterPage()
        //{
        //    return View();
        //}


        [HttpPost]
        public ActionResult Add(Regisform customer)
        {
            var employee = new Regisform()
            {

                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNo = customer.PhoneNo,
                DoB = customer.DoB,
                Email = customer.Email,
                Password = customer.Password,
                Cpassword = customer.Cpassword
            };

            context.regisforms.Add(employee);
            context.SaveChanges();
            return RedirectToAction("LoginPage", "Railway");
        }
        public IActionResult SearchTrain()
        {
            return View();
        }
        public IActionResult BookingPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBooking(Bookingform employee)
        {
            var emp = new Bookingform()
            {
                
                Email = employee.Email,
                Phoneno = employee.Phoneno,
                BName = employee.BName,
                Age = employee.Age,
                Gender = employee.Gender,
                Berth = employee.Berth,
                Amount = employee.Amount,
                CardNumber = employee.CardNumber,
                CardName = employee.CardName,
                CMonth = employee.CMonth,
                CYear = employee.CYear,
                Cvno = employee.Cvno,


            };
            context.bookingforms.Add(emp);
            context.SaveChanges();

            return RedirectToAction("TicketPage", "Railway");

        }
        public IActionResult TicketPage() 
        {
            return View();
        }
    }
}
