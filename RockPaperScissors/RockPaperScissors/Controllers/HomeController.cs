using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RockPaperScissors.Tournament;
using RockPaperScissors.Models;
using System.Data.Entity;
namespace RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        private championDBEntities db = new championDBEntities();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 10; //10 MB
                    string[] AllowedFileExtensions = new string[] { ".txt" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                        file.SaveAs(path);
                        Championship chmp = new Championship(path);
                        chmp.setFinalists();
                        ModelState.Clear();
                        int[] points = chmp.getpointsperwin();


                        var first = chmp._winner._name;
                        var second = chmp._secondPlace._name;
                        
                        int[] pts = chmp.getpointsperwin();
                        Database dataB = db.Database;
                        dataB.CreateIfNotExists();
                        var sql = @"EXEC dbo.usp_updatewinners {0},{1},{2},{3}";
                        db.Database.ExecuteSqlCommand(sql, first, second, pts[0], pts[1]);

                        ModelState.AddModelError("File", "File uploaded successfully;" + chmp.getWinners(points[0], points[1]));
                    }
                }
            }
            return View();
        }
      

    }
}
