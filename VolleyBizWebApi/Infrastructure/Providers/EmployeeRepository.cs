using Microsoft.EntityFrameworkCore;
using VolleyBizWebApi.Applications.Interfaces;
using VolleyBizWebApi.Applications.Models;
using VolleyBizWebApi.Domain.DataContext;
using VolleyBizWebApi.Domain.Entities;

namespace VolleyBizWebApi.Infrastructure.Providers
{
    public class EmployeeRepository(Context context) : IEmployeeRepository
    {
        private readonly Context _context = context;

        public async Task<int> AddEmployeeAsyn(EmployeeViewModel employeeView)
        {
            try
            {
                var result = await _context.Employees.FindAsync(employeeView.Id);
                if (result == null)
                {
                    var data = new Employee()
                    {
                        Name = employeeView.Name,
                        Dob = employeeView.Dob,
                        Gender = employeeView.Gender,
                        Mobile = employeeView.Mobile,
                        MartialStatus = employeeView.MartialStatus,
                        Image = employeeView.Image,
                    };
                    await _context.AddAsync(data);
                    await _context.SaveChangesAsync();
                    return data.Id;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            try
            {
                var result = await _context.Employees.FindAsync(id);
                if (result != null)
                {
                    _context.Employees.Remove(result);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> EditEmployeeAsync(EmployeeViewModel employeeView)
        {
            try
            {
                var result = await _context.Employees.FindAsync(employeeView.Id);
                if (result != null)
                {
                    result.Name = employeeView.Name;
                    result.Dob = employeeView.Dob;
                    result.MartialStatus = employeeView.MartialStatus;
                    result.Mobile = employeeView.Mobile;
                    result.Gender = employeeView.Gender;
                    result.Image = employeeView.Image;
                    _context.Employees.Update(result);
                    await _context.SaveChangesAsync();
                    return 1;
                }
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }
        }

        public async Task<List<EmployeeViewModel>> GetAllEmployeeAsync()
        {
            try
            {
                var results = await _context.Employees.Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Dob = rec.Dob,
                    Gender = rec.Gender,
                    Mobile = rec.Mobile,
                    Image = rec.Image,
                    MartialStatus = rec.MartialStatus
                }).ToListAsync();
                return results;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<EmployeeViewModel> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var results = await _context.Employees.Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    Dob = rec.Dob,
                    Gender = rec.Gender,
                    Mobile = rec.Mobile,
                    Image = rec.Image,
                    MartialStatus = rec.MartialStatus
                }).FirstOrDefaultAsync(x=>x.Id==id);
                return results;
            }
            catch (Exception)
            {
                return new EmployeeViewModel { };
            }
        }
    }
}
