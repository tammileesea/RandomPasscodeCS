using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private string PasswordGenerator (){
            var newPasscode = new char[14];
            // List<string> newPasscode = new List<string>();
            string alphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWYXZ0123456789";
            Random characters = new Random();
            for (int i = 0; i < 14; i++){
                int j = characters.Next(0, alphaNumeric.Length);
                newPasscode[i] = alphaNumeric[j];
            }
            // return newPasscode;
            var finalString = new String(newPasscode);
            System.Console.WriteLine("****************");
            System.Console.WriteLine(finalString);
            return finalString;
        }
        public IActionResult Index(){
            HttpContext.Session.SetInt32("Count", 1);
            ViewBag.IndexCount = HttpContext.Session.GetInt32("Count");
            ViewBag.Passcode = PasswordGenerator();
            // PasswordGenerator();
            return View();
        }

        public IActionResult GeneratePasscode(){
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", count.Value);
            System.Console.WriteLine(HttpContext.Session.GetInt32("Count"));
            ViewBag.IndexCount = count.Value;
            ViewBag.Passcode = PasswordGenerator();
            return View("Index");
        }

        public IActionResult Reset(){
            // HttpContext.Session.Clear();
            // HttpContext.Session.SetInt32("Count", 0);
            // ViewBag.Passcode = "NO PASSCODE";
            return RedirectToAction("Index");
        }
    }
}
