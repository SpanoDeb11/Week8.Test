using AcademyG.Week8.Esercitazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PlateViewModel> Plates { get; set; }

        public MenuViewModel()
        {
            Plates = new List<PlateViewModel>();
        }
    }
}
