using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RockPaperScissors.Models;
using System.Web.UI;
using System.Web;
using RockPaperScissors.Tournament;
namespace RockPaperScissors.Controllers
{
    public class championshipController : ApiController
    {
        private championDBEntities db = new championDBEntities();



        

        // GET api/championship/5
        [ResponseType(typeof(Winner))]
        public IHttpActionResult GetWinner(string result)
        {
            Winner winner = db.Winners.Find(result);
            if (winner == null)
            {
                return NotFound();
            }

            return Ok(winner);
        }

      


        // POST api/championship/result
        public string[] PostResultWinner()
        {
            var c = HttpContext.Current;
            var second = c.Request.Params["second"];
            var first = c.Request.Params["first"];
            var chmp = new Championship();
            int[] pts = chmp.getpointsperwin();
            Database dataB = db.Database;
            dataB.CreateIfNotExists();
            var sql = @"EXEC dbo.usp_updatewinners {0},{1},{2},{3}";
            db.Database.ExecuteSqlCommand(sql, first, second, pts[0], pts[1]);
 

            return new string[]
                {
                     "success"
                };


        }


        // POST api/championship/new
        public string[] PostNewWinner()
        {
            var c = HttpContext.Current;
            var data = c.Request.Params["data"];
            Championship getwinner = new Championship(); 
            getwinner.setNodes(data);

          
            return new string[]
                {
                    "winner : [" + '"' + getwinner._winner._name + '"' + ", " + '"' + getwinner._winner._play + '"' + "]"  
                };
            
        }


        // GET api/championship/top
        public string[] GetTopWinners()
        {
            var c = HttpContext.Current;
            var count = c.Request.Params["count"];
            if (count == null)
                count = "10";
            Database dataB = db.Database;
            dataB.CreateIfNotExists();
            var sql = @"EXEC dbo.usp_obtainwinners {0}";
            DataTable dt = new DataTable();
            //Winner result = db.Database.ExecuteSqlCommand(sql, count);
           // return Ok(db.Database.s(sql, count));
            return new string[]
                {
                  count 
                };

    
        }


        // POST api/championship/delete
        [ResponseType(typeof(Winner))]
        public IHttpActionResult DeleteWinners()
        {
            Winner winner = db.Winners.First() ;
            if (winner == null)
            {
                return NotFound();
            }

            db.Winners.Remove(winner);
            db.SaveChanges();

            return Ok(winner);
        }

     
    }
}