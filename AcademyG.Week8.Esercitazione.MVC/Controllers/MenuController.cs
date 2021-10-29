using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using AcademyG.Week8.Esercitazione.MVC.Helper;
using AcademyG.Week8.Esercitazione.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.Controllers
{
    [Authorize]
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer _mainBL;

        public MenuController(IMainBusinessLayer bl)
        {
            this._mainBL = bl;
        }

        public IActionResult Index()
        {
            var result = this._mainBL.GetAllMenus();

            var resultMapping = result.Select(m => m.ToMenuViewModel());

            return View(resultMapping);
        }

        [Route("/Menu/Detail/{name}")]
        public IActionResult Detail(string name)
        {
            if (string.IsNullOrEmpty(name))
                return View("NotFound");

            var menu = this._mainBL.GetMenuByName(name);
            if (menu == null)
                return View("NotFound");

            var resultMapped = menu.ToMenuViewModel();

            return View(resultMapped);
        }

        [Authorize(Policy = "RestaurantAdmin")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        [HttpPost]
        [Authorize(Policy = "RestaurantAdmin")]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Error!"));
            }

            Menu newMenu = model.ToMenu();
            var result = _mainBL.CreateNewMenu(newMenu);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "RestaurantAdmin")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var menuToEdit = _mainBL.GetMenuById(id);
            if (menuToEdit == null)
                return View("NotFound");
            var mvm = menuToEdit.ToMenuViewModel();
            return View(mvm);
        }

        [HttpPost]
        [Authorize(Policy = "RestaurantAdmin")]
        public IActionResult Edit(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            // per poter tenere i piatti (altrimenti me li rende null)
            var menuEdit = this._mainBL.GetMenuById(model.Id);
            menuEdit.Name = model.Name;

            var result = _mainBL.EditMenu(menuEdit);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }

            // altrimenti passa il model con piatti null
            var modelToSend = menuEdit.ToMenuViewModel();
            return View("Detail", modelToSend);
        }

        [Authorize(Policy = "RestaurantAdmin")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(false);

            var result = this._mainBL.DeleteMenu(id);

            return Json(result.Success);
        }
    }
}
