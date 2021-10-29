using AcademyG.Week8.Esercitazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Repositories
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Menu GetByName(string name); // suppongo che il nome sia univoco
    }
}
