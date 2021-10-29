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
    [Authorize(Policy = "RestaurantAdmin")]
    public class PlateController : Controller
    {
        private readonly IMainBusinessLayer _mainBL;

        public PlateController(IMainBusinessLayer bl)
        {
            this._mainBL = bl;
        }

        public IActionResult Create(int id)
        {
            LoadViewBag();
            return View(new PlateViewModel() { MenuId = id });
        }

        [HttpPost]
        public IActionResult Create(PlateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Error!"));
            }

            Plate newPlate = model.ToPlate();
            newPlate.Id = 0;
            var result = this._mainBL.CreateNewPlate(newPlate);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }

            string menuName = this._mainBL.GetMenuById(model.MenuId).Name;

            return Redirect("~/Menu/Detail/" + menuName);
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var plate = _mainBL.GetPlateById(id);
            if (plate == null)
                return View("NotFound");
            var deleted = plate.ToPlateViewModel();
            return View(deleted);
        }

        [HttpPost]
        public IActionResult Delete(PlateViewModel pvm)
        {
            if (pvm == null)
                return View("ExceptionError", new ResultBL(false, "Invalid data"));

            var result = this._mainBL.DeletePlate(pvm.Id);

            if (!result.Success)
                return View("ExceptionError", new ResultBL(false, "Something wrong"));

            return Redirect("~/Menu/Index");
        }

        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");
            var plate = _mainBL.GetPlateById(id);
            if (plate == null)
                return View("NotFound");
            var updated = plate.ToPlateViewModel();
            LoadViewBag();
            return View(updated);
        }

        [HttpPost]
        public IActionResult Edit(PlateViewModel pvm)
        {
            if (!ModelState.IsValid)
            {
                return View(pvm);
            }
            if (pvm == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            var plateToEdit = pvm.ToPlate();
            var result = _mainBL.EditPlate(plateToEdit);
            if (!result.Success)
            {
                return View("ExceptionError", result);
            }
            return Redirect("~/Menu/Index");
        }

        private void LoadViewBag()
        {
            ViewBag.Categories = MappingExtension.FromEnumToSelectList<Typology>();
        }
    }
}
