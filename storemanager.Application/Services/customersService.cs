using storemanager.Application.SeedWorks;
using storemanager.Application.Services.Interfaces;
using storemanager.Application.ViewModels.ResultView;
using storemanager.Entity.Entities;
using storemanager.Infrastructure.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storemanager.Application.Services
{
    public class customersService : BaseService, IcustomersService
    {
        private readonly IRepository<Tblcustomer> _customerRepo;
      

        public customersService(IUnitOfWork unitOfWork, IRepository<Tblcustomer> customerRepo) : base(unitOfWork)
        {
            _customerRepo = customerRepo;           
        }
        public async Task<ResultViewModel> Create(string FullName, DateTime DOB, string Email)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                Guid id = Guid.NewGuid();
                var customer = new Tblcustomer(id, FullName, DOB, Email);
                _customerRepo.Add(customer);
                await UnitOfWork.SaveChangeAsync();
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "lỗi phát sinh " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetId(Guid id)
        {
            ResultViewModel model = new ResultViewModel();
            try
            {

                var customer = _customerRepo.GetAsyncId(id).Result;
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = "Lỗi thêm dữ liệu " + ex.Message.ToString();
            }
            return model;
        }

        public async Task<ResultViewModel> GetList()
        {
            ResultViewModel model = new ResultViewModel();
            try
            {
                var customer = _customerRepo.GetAsync().Result;
                model.response = customer;
            }
            catch (Exception ex)
            {
                model.status = 0;
                model.message = ex.Message.ToString();
            }
            return model;
        }
    }
}
