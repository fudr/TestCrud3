using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestCrud3.Models
{
    public class User
    {
        public string? user { get; set; }
        public string? pass { get; set; }
    }
    public class UserAll
    {
        public string? first { get; set; }
        public string? last { get; set; }
        public string? doc { get; set; }
        public string? rol { get; set; }
        public string? user { get; set; }
        public string? id { get; set; }

    }
    public class Pelis
    {
        public string id { get; set; }
        public string peli { get; set; }
        public string genero { get; set; }
        public string stockAlq { get; set; }
        public string stockVenta { get; set; }
        public string precioAlq { get; set; }
        public string precioVenta { get; set; }

    }

    public class Genero
    {
        public string id { get; set; }
        public string genero { get; set; }
    }

}
