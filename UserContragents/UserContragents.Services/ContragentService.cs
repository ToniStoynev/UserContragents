using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserContragents.Data;
using UserContragents.Domain;
using UserContragents.Models;
using UserContragents.Models.ViewModels;
using UserContragents.Services.Contracts;

namespace UserContragents.Services
{
    public class ContragentService : IContragentService
    {
        private readonly UserContragetnsDbContext db;

        public ContragentService(UserContragetnsDbContext db)
        {
            this.db = db;
        }
        public bool AddContragent(AddContragentBindingModel model)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Id == model.UserId);

            user.Contragents.Add(new Contragents
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                DDSNumber = model.DDSNumber
            });

            int result = this.db.SaveChanges();

            return result > 0;
        }

        public IQueryable<Contragents> GetAll(string id)
        {
            var contragetnsFromDb = this.db.Contragents
                                .Where(x => x.UserId == id);

           
            return contragetnsFromDb;
        }

        public ContragentDetaislViewModel GetContragentById(string id)
        {
            var modelFromDb = this.db.Contragents.FirstOrDefault(x => x.Id == id);

            var viewModel = new ContragentDetaislViewModel
            {
                Name = modelFromDb.Name,
                Address = modelFromDb.Address,
                Email = modelFromDb.Email,
                DDSNumber = modelFromDb.DDSNumber
            };

            return viewModel; 
        }
    }
}
