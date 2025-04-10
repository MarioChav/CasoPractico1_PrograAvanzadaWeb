using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProgramaController : Controller
    {
        IProgramaHelper _programaHelper;
        IParametroHelper _parametroHelper;

        public ProgramaController(IProgramaHelper programaHelper, IParametroHelper parametroHelper)
        {
            _programaHelper = programaHelper;
            _parametroHelper = parametroHelper;
        }
        // GET: ProgramaController
        public ActionResult Index()
        {
            _programaHelper.Token = HttpContext.Session.GetString("Token");
            return View(_programaHelper.GetAll());

            //var Result = _programaHelper.GetProgramas();
            //return View(Result);
        }

        // GET: ProgramaController/Details/5
        public ActionResult Details(int id)
        {
            ProgramaViewModel programa = _programaHelper.GetById(id);
            return View(programa);



            //var Result = _programaHelper.GetPrograma(id);
            //return View(Result);
        }

        // GET: ProgramaController/Create
        public ActionResult Create()
        {
            ProgramaViewModel programa = new ProgramaViewModel();
            programa.Parametros = _parametroHelper.GetAll();
            return View(programa);




            //return View();
        }

        // POST: ProgramaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProgramaViewModel programa)
        {
            try
            {
                _programaHelper.AddPrograma(programa);
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
            ProgramaViewModel programa = _programaHelper.GetById(id);
            programa.Parametros = _parametroHelper.GetAll();
            return View(programa);
        }

        // POST: ProgramaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProgramaViewModel programa)
        {
            try 
            {
                _programaHelper.EditPrograma(programa);
                return RedirectToAction("Details", new { id = programa.ProgramaId });
            }
            catch
            {
                return View();
            }



            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: ProgramaController/Delete/5
        public ActionResult Delete(int id)
        {
            ProgramaViewModel programa = _programaHelper.GetById(id);
            return View(programa);
        }

        // POST: ProgramaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProgramaViewModel programa)
        {
            try 
            {
                _programaHelper.DeletePrograma(programa.ProgramaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }



            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
