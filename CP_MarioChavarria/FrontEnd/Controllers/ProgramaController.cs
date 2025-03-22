using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProgramaController : Controller
    {
        IProgramaHelper _programaHelper;

        public ProgramaController(IProgramaHelper programaHelper)
        {
            _programaHelper = programaHelper;
        }
        // GET: ProgramaController
        public ActionResult Index()
        {
            var Result = _programaHelper.GetProgramas();
            return View(Result);
        }

        // GET: ProgramaController/Details/5
        public ActionResult Details(int id)
        {
            var Result = _programaHelper.GetPrograma(id);
            return View(Result);
        }

        // GET: ProgramaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProgramaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.Add(programa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProgramaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProgramaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProgramaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
