using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyG.Week8.Esercitazione.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IMenuRepository _menuRepo;
        private readonly IPlateRepository _plateRepo;
        private readonly IUserRepository _userRepo;

        public MainBusinessLayer(IMenuRepository menuRepo, IPlateRepository plateRepo, IUserRepository userRepo)
        {
            this._menuRepo = menuRepo;
            this._plateRepo = plateRepo;
            this._userRepo = userRepo;
        }

        #region Menu

        public ResultBL CreateNewMenu(Menu newMenu)
        {
            if (newMenu == null)
                return new ResultBL(false, "Invalid menu");

            // il nome del menu è unique
            if (this._menuRepo.GetByName(newMenu.Name) != null)
                return new ResultBL(false, "Existing name");

            var result = this._menuRepo.Add(newMenu);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public ResultBL DeleteMenu(int id)
        {
            if (id <= 0)
                return new ResultBL(false, "Invalid menu id");

            if (this._menuRepo.GetById(id) == null)
                return new ResultBL(false, "Meno not found");

            var result = this._menuRepo.Delete(id);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public ResultBL EditMenu(Menu menu)
        {
            if (menu == null)
                return new ResultBL(false, "Invalid menu");

            if (this._menuRepo.GetById(menu.Id) == null)
                return new ResultBL(false, "Menu not found");

            var result = this._menuRepo.Update(menu);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public IEnumerable<Menu> GetAllMenus(Func<Menu, bool> filter = null)
        {
            return this._menuRepo.Fetch(filter);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;

            return this._menuRepo.GetById(id);
        }

        public Menu GetMenuByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;

            return this._menuRepo.GetByName(name);
        }

        #endregion

        #region Plate

        public ResultBL CreateNewPlate(Plate newPlate)
        {
            if (newPlate == null)
                return new ResultBL(false, "Invalid plate");

            var result = this._plateRepo.Add(newPlate);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public ResultBL DeletePlate(int id)
        {
            if (id <= 0)
                return new ResultBL(false, "Invalid plate id");

            if (this._plateRepo.GetById(id) == null)
                return new ResultBL(false, "Plate not found");

            var result = this._plateRepo.Delete(id);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public ResultBL EditPlate(Plate plate)
        {
            if (plate == null)
                return new ResultBL(false, "Invalid plate");

            if (this._plateRepo.GetById(plate.Id) == null)
                return new ResultBL(false, "Plate not found");

            var result = this._plateRepo.Update(plate);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public IEnumerable<Plate> GetAllPlates(Func<Plate, bool> filter)
        {
            return this._plateRepo.Fetch(filter);
        }

        public Plate GetPlateById(int id)
        {
            if (id <= 0)
                return null;

            return this._plateRepo.GetById(id);
        }

        #endregion

        #region User

        public ResultBL CreateNewUser(User newUser)
        {
            if (newUser == null)
                return new ResultBL(false, "Invalid user");

            if (this._userRepo.GetUserByEmail(newUser.Email) != null)
                return new ResultBL(false, "Existing email");

            var result = this._userRepo.Add(newUser);
            if (!result)
                return new ResultBL(result, "Something wrong");

            return new ResultBL(result, "Ok!");
        }

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return this._userRepo.GetUserByEmail(email);
        }

        #endregion

    }
}
