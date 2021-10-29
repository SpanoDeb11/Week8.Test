using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Plate> Plates { get; set; }

        public Menu()
        {
            Plates = new List<Plate>();
        }
    }
}
