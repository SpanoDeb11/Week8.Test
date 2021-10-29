using AcademyG.Week8.Esercitazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.Models
{
    public class PlateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Typology Type { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
    }
}
