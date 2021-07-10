using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TrainSchedule.Models;
using TrainSchedule.Data;

namespace TrainSchedule.Pages
{
    public class ResultsModel : PageModel
    {
        private readonly TrainScheduleContext _context;
        public ResultsModel(TrainScheduleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Result> Results { get; set; }
        public Condition Conditions { get; set; }
        public void OnGet()
        {
            Conditions = new Condition();
            Conditions.FromStation = Request.Cookies["FromStation"];
            Conditions.ToStation = Request.Cookies["ToStation"];
            Conditions.Date = DateTime.Parse(Request.Cookies["Date"]);
            Conditions.Time = DateTime.Parse(Request.Cookies["Time"]);
            Conditions.IsDeparture = Boolean.Parse(Request.Cookies["IsDeparture"]);
            Conditions.IsExpress = Boolean.Parse(Request.Cookies["IsExpress"]);
            Conditions.IsIntercity = Boolean.Parse(Request.Cookies["IsIntercity"]);
            Conditions.IsRegional = Boolean.Parse(Request.Cookies["IsRegional"]);
            Conditions.IsWifi = Boolean.Parse(Request.Cookies["IsWifi"]);
            Conditions.IsBicycleCarriage = Boolean.Parse(Request.Cookies["IsBicycleCarriage"]);

            Results = SelectResults.FindResults(_context, Conditions);
        }
        public IActionResult OnPost()
        {
            Response.Cookies.Append("ValidForm", "False");
            return RedirectToPage("/Index");
        }


        public PartialViewResult OnGetResult(int id)
        {
            Conditions = new Condition();
            Conditions.FromStation = Request.Cookies["FromStation"];
            Conditions.ToStation = Request.Cookies["ToStation"];
            Conditions.Date = DateTime.Parse(Request.Cookies["Date"]);
            Conditions.Time = DateTime.Parse(Request.Cookies["Time"]);
            Conditions.IsDeparture = Boolean.Parse(Request.Cookies["IsDeparture"]);
            Conditions.IsExpress = Boolean.Parse(Request.Cookies["IsExpress"]);
            Conditions.IsIntercity = Boolean.Parse(Request.Cookies["IsIntercity"]);
            Conditions.IsRegional = Boolean.Parse(Request.Cookies["IsRegional"]);
            Conditions.IsWifi = Boolean.Parse(Request.Cookies["IsWifi"]);
            Conditions.IsBicycleCarriage = Boolean.Parse(Request.Cookies["IsBicycleCarriage"]);
            return Partial("_ResultsDetails", SelectResults.SelectResult(_context, Conditions, id));
        }
    }
}
