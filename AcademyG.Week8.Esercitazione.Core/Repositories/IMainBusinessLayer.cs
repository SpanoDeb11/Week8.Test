using AcademyG.Week8.Esercitazione.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core.Repositories
{
    public interface IMainBusinessLayer
    {
        #region Menu

        IEnumerable<Menu> GetAllMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        Menu GetMenuByName(string name);
        ResultBL CreateNewMenu(Menu newMenu);
        ResultBL EditMenu(Menu menu);
        ResultBL DeleteMenu(int id);

        #endregion

        #region Plate

        IEnumerable<Plate> GetAllPlates(Func<Plate, bool> filter);
        Plate GetPlateById(int id);
        ResultBL CreateNewPlate(Plate newPlate);
        ResultBL EditPlate(Plate plate);
        ResultBL DeletePlate(int id);

        #endregion

        #region User

        ResultBL CreateNewUser(User newUser);
        User GetUserByEmail(string email);

        #endregion
    }
}
