using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SqlInjection.Models;
using System.Collections;
using System.Diagnostics;

namespace SqlInjection.Controllers
{


    public class Test
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
    }
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Test test)
        {


            //https://www.w3schools.com/sql/sql_injection.asp

            #region Tüm kayıtları getirme

            //SqlConnection con = new SqlConnection("data source=.;initial catalog=UserDb;integrated security=true;Encrypt=True;TrustServerCertificate=True");

            //SqlCommand command = new SqlCommand("select *from Users where Id=" + test.UserName + "", con);
            //con.Open();


            //SqlDataReader dr = command.ExecuteReader();

            //List<int> list = new List<int>();
            //while (dr.Read())
            //{
            //    list.Add(dr.GetInt32(0));


            //}

            #endregion
            #region Kullanıcı adı ve Şifre manipüle edilecek tüm kullanıcılara ulaşmak
            //SqlConnection con = new SqlConnection("data source=.;initial catalog=Authentication;integrated security=true;Encrypt=True;TrustServerCertificate=True");

            //SqlCommand command = new SqlCommand("select *from Auths where Email='" + test.UserName + "' and Password='" + test.Password + "'", con);
            //con.Open();


            //SqlDataReader dr = command.ExecuteReader();

            //List<Test> list = new List<Test>();
            //while (dr.Read())
            //{
            //    list.Add(new Test(){ 

            //     Password = dr.GetString(2),
            //      UserName =dr.GetString(1)


            //    });


            //}
            #endregion

            int id = 4;
            SqlConnection con = new SqlConnection("data source=.;initial catalog=Authentication;integrated security=true;Encrypt=True;TrustServerCertificate=True");



            SqlCommand command = new SqlCommand("select *from Auths where Id=" + test.Id + "", con);
            con.Open();


            SqlDataReader dr = command.ExecuteReader();

            List<Test> list = new List<Test>();
            while (dr.Read())
            {
                list.Add(new Test()
                {

                    Password = dr.GetString(2),
                    UserName = dr.GetString(1)


                });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}