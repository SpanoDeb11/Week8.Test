using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.Helper
{
    public static class MappingExtension
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Name = menu.Name,
                Plates = menu.Plates.Select(p => p.ToPlateViewModel()).ToList()
            };
        }

        public static Menu ToMenu(this MenuViewModel mvm)
        {
            return new Menu
            {
                Id = mvm.Id,
                Name = mvm.Name,
                Plates = mvm.Plates.Select(p => p.ToPlate()).ToList()
            };
        }

        public static PlateViewModel ToPlateViewModel(this Plate plate)
        {
            return new PlateViewModel
            {
                Id = plate.Id,
                Name = plate.Name,
                Description = plate.Description,
                Type = plate.Type,
                Price = plate.Price,
                MenuId = plate.MenuId
            };
        }

        public static Plate ToPlate(this PlateViewModel pvm)
        {
            return new Plate
            {
                Id = pvm.Id,
                Name = pvm.Name,
                Description = pvm.Description,
                Type = pvm.Type,
                Price = pvm.Price,
                MenuId = pvm.MenuId
            };
        }

        public static User ToUser(this UserRegistrationViewModel userViewModel)
        {
            return new User
            {
                Email = userViewModel.Email,
                Password = userViewModel.Password,
                Role = Role.Client
            };
        }

        public static IEnumerable<SelectListItem> FromEnumToSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T))).Cast<T>().Select(
                    e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() }).ToList();
        }
    }
}
