using HasanShouman.Models;
using HasanShouman.Models.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HasanShouman.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// For unit-test, we do not hace access to the Server.MapPath since the HTTPContext is null, so we need to mock the path.
        /// </summary>
        protected string AccFilPpath;

        public HomeController()
        {
        }
        /// <summary>
        /// This constructor will be called during unit-testing.
        /// </summary>
        /// <param name="pathProvider"></param>
        public HomeController(IPathProvider pathProvider)
        {
            AccFilPpath = pathProvider.MapPath("~/Files/");
        }

    

        /// <summary>
        /// Load the data from the file, and manipulate it depending on the <paramref name="Granularity"/> value.
        /// </summary>
        /// <param name="Granularity">Type of the grouping</param>
        /// <returns></returns>
        [HttpPost]
        public string LoadData(string Granularity)
        {
            try
            {
                
                List<GroupedData> lstGrouped = null;

                /// If AccFilPpath is null, then we are not running a unit test, so map the directory.
                if (AccFilPpath == null)
                {
                    AccFilPpath = Server.MapPath(@"/Files/");
                }

                // Read the data from the file and hold in a list.
                List<UserEvent> lstAllData = System.IO.File.ReadLines(AccFilPpath +  @"data1.txt")
                                    .Select(line =>
                                    {
                                        string[] ss = line.Split('>');
                                        return (ss.Length == 4)
                                   ? new UserEvent()
                                   {
                                       ID = ss[0],
                                       EventDate = Convert.ToDateTime(ss[1]),
                                       EventType = ss[2],
                                       Description = ss[3]

                                   }
                                   : null;
                                    })
                                    .Where(x => x != null)
                                    .ToList();

                // If the granularity is "hourly" then group by EvenDate & Eventype, then perform another group based on the key
                // of the first-level grouping and fill the children.
                if (Granularity == "h")
                {
                                       lstGrouped = lstAllData.GroupBy(r =>
                    new { r.EventDate.Hour, r.EventDate.Date, r.EventType })

                    .Select(gp => new GroupedData
                    {
                       EventDate = new DateTime(gp.Key.Date.Year, gp.Key.Date.Month, gp.Key.Date.Day, gp.Key.Hour, 0,0),

                        CountSender = gp.Count().ToString(),
                        CountReceiver = gp.Select(x => x.ID).Distinct().Count().ToString(),
                        EventType = gp.Key.EventType
                    }).GroupBy(x=> new { x.EventDate}).Select( innerGp=> new GroupedData // Inner group
                    {

                        EventDate = innerGp.Key.EventDate,
                        Children = innerGp.Where(y=> y.EventDate == innerGp.Key.EventDate).ToList()
                    })

                    .ToList();



                    return Functions.BuildSuccessMessage<GroupedData>(lstGrouped);
                }
                // No need to group
                else if (Granularity == "m")
                {
                    

                     lstGrouped = lstAllData.Select(x => new GroupedData
                    {
                        EventDate = x.EventDate,
                        Description = x.Description
                    }).ToList();


                    return Functions.BuildSuccessMessage<GroupedData>(lstGrouped);
                }


                return null;

            
            }
            catch (Exception ex)
            {

                return Functions.BuildErrorMessage(ex.Message);
            }
     
        }
        public ActionResult Index()
        {
            
            return View();
        }

      
     
    }
}