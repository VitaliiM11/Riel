using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using riel.Models;

namespace riel.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "iamadmin")
            {
                return RedirectToAction("Index", "Admin");
            }
           
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult SignUp(string name, string lastname, string phone, string email, string password)
        {
            string MyConnection2 = "server=localhost;user=root;password=password;database=riel;";
            string Query = $"insert into riel.client(FirstName, LastName, Phone, Email, password)" +
                $"values('{name}', '{lastname}', '{phone}', '{email}', '{password}')";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();
            return RedirectToAction("Index", "Home");
        }
    }
}
