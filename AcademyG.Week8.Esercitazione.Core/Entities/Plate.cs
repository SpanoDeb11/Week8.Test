using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Entities
{
    public enum Typology
    {
        First,
        Second,
        Side,
        Dessert
    }
    public class Plate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Typology Type { get; set; }
        public decimal Price { get; set; }
        public Menu Menu { get; set; }
        public int MenuId { get; set; }
    }
}
