using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITUniver.TeleCalc.Core.Operations;
using ITUniver.TeleCalc.Web.Repositories;
using ITUniver.TeleCalc.Web.Models;
using ITUniver.TeleCalc.Core;
using System.Data.SqlClient;

namespace ITUniver.TeleCalc.Web.Controllers 
{
    public class CalcController : Controller
    {
        private Calc Calc { get; set; }

        private HistoryRepository HistoryRepository { get; set; }

        private OperationRepository OperationRepository { get; set; }

        public CalcController()
        {
            var connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Z:\it\ITUniver.TeleCalc.Web\App_Data\TeleCalcDB.mdf;Integrated Security=True";
            Calc = new Calc();
            HistoryRepository = new HistoryRepository(connString);
            OperationRepository = new OperationRepository(connString);
        }

        [HttpGet]
        public ActionResult Index(string opName, double? x, double? y)
        {
            ViewBag.x = x;
            ViewBag.y = y;
            ViewBag.opName = opName;
            ViewBag.result = new Calc().Exec(opName, new[] { x ?? 0, y ?? 0 });
            return View();
        }
        [HttpGet]
        public ActionResult Operations()
        {
            ViewBag.operations = OperationRepository.Find("").Select(o => o.Name);
            return View();
        }

        [HttpGet]
        public ActionResult Exec()
        {
            var model = new CalcModel();
            model.OperationList = new SelectList(Calc.getOperNames());
            return View(model);
        }

        [HttpPost]
        public PartialViewResult Exec(CalcModel model)
        {
            var result = double.NaN;

            if (Calc.getOperNames().Contains(model.OperName))
            {
                result = Calc.Exec(model.OperName, model.InputData);

                var operation = OperationRepository.LoadByName(model.OperName);

                if (operation != null)
                {
                    var history = new HistoryItemModel()
                    {
                        Operation = operation.Id,
                        Initiator = 1,
                        Result = result,
                        Args = string.Join(";", model.InputData),
                        CalcDate = DateTime.Now,
                        Time = 15
                    };

                    HistoryRepository.Save(history);
                }

            }

            return PartialView("ExecResult", result);
        }


        public ActionResult History()
        {
            var items = HistoryRepository.Find("");

            return View(items);
        }

       
    }

}