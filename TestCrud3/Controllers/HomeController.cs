using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using TestCrud3.Models;

namespace TestCrud3.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-5SIOVKD;Initial Catalog=TestCrud;Integrated Security=True;");

        public ActionResult Index()
        {
            return View();
        }

<<<<<<< HEAD
        public ActionResult AgregarGenero() {
            conn.Open();
            List<Genero> g = 
                new List<Genero>();
            SqlCommand command = new SqlCommand("Select * from [tGenero]", conn);

            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        Genero ii = new Genero();
                        ii.id = reader["cod_genero"].ToString();
                        ii.genero = reader["txt_desc"].ToString();

                        g.Add(ii);
                    }
                    g.Add(new Genero());
                }
            }

            conn.Close();
            return View(g); }
=======
>>>>>>> 50a9f857d0f8c2ee4cc57c8fc097e39b211037b3

        [HttpPost]

        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                string u = Request.Form["user"];
                string p = Request.Form["pass"];

                
                conn.Open();

                SqlCommand command = new SqlCommand("Select * from [tUsers] where txt_user='" + u + "' and txt_password='" + p + "'", conn);
                
                // int result = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if(reader["cod_rol"].ToString() == "1")
                        {
                            return RedirectToAction("UpdateUsers");
                        }
                        if (reader["cod_rol"].ToString() == "2")
                        {
                            return RedirectToAction("Hola");
                        }
                    }
                }

                conn.Close();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ee)
            {
                return View();
            }
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Hola()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateUsers(IFormCollection collection)
        {
            conn.Open();
            string idUser = Request.Form["item.id"].ToString();
            if (idUser.Length == 0) idUser = "0";
            if (Request.Form["actionA"].ToString() == "Save")
            {
                SqlCommand command = new SqlCommand("spUserABM " + idUser + ", '" + Request.Form["item.first"].ToString() + "','" + Request.Form["item.last"].ToString()                     + "','" + Request.Form["item.doc"].ToString() + "','" + Request.Form["item.user"].ToString()+ "','" + Request.Form["actionA"].ToString() + "'", conn);
                command.ExecuteNonQuery();
            }
            if (Request.Form["actionA"].ToString() == "Edit")
            {
                return RedirectToAction("Peliculas");
            }
<<<<<<< HEAD
            if (Request.Form["actionA"].ToString() == "EditGenero")
            {
                return RedirectToAction("AgregarGenero");
            }
=======
>>>>>>> 50a9f857d0f8c2ee4cc57c8fc097e39b211037b3
            if (Request.Form["actionA"].ToString() == "Delete")
            {
                SqlCommand command = new SqlCommand("spUserABM " + Request.Form["item.id"].ToString(), conn);
                command.ExecuteNonQuery();
            }


            return RedirectToAction("UpdateUsers");

        }

        public ActionResult Peliculas()
        {
            List<Pelis> PelisL = new List<Pelis>();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from [tPelicula] INNER JOIN tgeneropelicula ON tPelicula.cod_pelicula = tgeneropelicula.cod_pelicula INNER JOIN tgenero ON tgeneropelicula.cod_genero = tgenero.cod_genero  ", conn);

            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {

                    while (reader.Read())
                    {
                        Pelis i = new Pelis();
                        i.id = reader["cod_pelicula"].ToString();
                        i.peli = reader["txt_desc"].ToString();
                        i.genero = reader["txt_desc"].ToString();
                        i.precioVenta = reader["precio_venta"].ToString();
                        i.precioAlq = reader["precio_alquiler"].ToString();
                        i.stockVenta = reader["cant_disponibles_venta"].ToString();
                        i.stockAlq = reader["cant_disponibles_alquiler"].ToString();
                        PelisL.Add(i);
                    }
                    PelisL.Add(new Pelis());
                }
            }

            conn.Close();
            return View(PelisL);
        }

        [HttpPost]
        public ActionResult Peliculas(IFormCollection collection)
        {
            conn.Open();
            string idUser = Request.Form["item.id"].ToString();
            if (idUser.Length == 0) idUser = "0";
            if (Request.Form["actionA"].ToString() == "Save")
            {
                /*SqlCommand command = new SqlCommand("spPeliABM " + idUser + ", '" + Request.Form["item.peli"].ToString() + "','" + Request.Form["item.last"].ToString() + "','" + Request.Form["item.doc"].ToString() + "','" + Request.Form["item.user"].ToString() + "','" + Request.Form["actionA"].ToString() + "'", conn);
                command.ExecuteNonQuery();*/
            }
            if (Request.Form["actionA"].ToString() == "Edit")
            {
                return RedirectToAction("Peliculas");
            }
            if (Request.Form["actionA"].ToString() == "Delete")
            {
                /*SqlCommand command = new SqlCommand("spUserABM " + Request.Form["item.id"].ToString(), conn);
                command.ExecuteNonQuery();*/
            }


            return RedirectToAction("UpdateUsers");

        }

        public ActionResult UpdateUsers()
        {
            List<UserAll> users = new List<UserAll>();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from [tUsers]", conn);

            // int result = command.ExecuteNonQuery();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    
                    while(reader.Read())
                    {
                        UserAll i = new UserAll();
                        i.first = reader["txt_nombre"].ToString();
                        i.last = reader["txt_apellido"].ToString();
                        i.doc = reader["nro_doc"].ToString();
                        i.rol = reader["cod_rol"].ToString();
                        i.user = reader["txt_user"].ToString();
                        i.id = reader["cod_usuario"].ToString();
                        users.Add(i);
                    }
                    users.Add(new UserAll());
                }
            }

            conn.Close();
            return View(users);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

       

    }
    
}