using Application.Mapper;
using Application.Output.DTO;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.AdminContext
{
    public class AdminRepository(List<Admin> adminDB) : IAdminRepository
    {
        private readonly AdminMapper adminMapper = new();
        public IResultBase DeleteAdminByIdAsync(Guid id)
        {
            Result result;
            var admin = adminDB.Find(admin => admin.Id == id) ??
                throw new KeyNotFoundException("Admin not found");
            admin.IsDeleted = true;
            result = new Result(resultCode: 200, message: "Admin deleted successfully",isOk: true);
            result.SetData(adminMapper.MapToDTO(admin));
            return result;
        }

        public async Task<AdminDTO> GetAdminByEmailAsync(string email)
        {
            var admin = adminDB.Find(admin => admin.Email.Equals(email, StringComparison.OrdinalIgnoreCase)) ??
                throw new KeyNotFoundException("Admin not found");
            Admin adminE = await Task.FromResult(admin);
            return adminMapper.MapToDTO(adminE);
        }

        public async Task<AdminDTO> GetAdminByIdAsync(Guid id)
        {
            var admin = adminDB.Find(admin => admin.Id == id) ??
                throw new KeyNotFoundException("Admin not found");
            Admin adminE = await Task.FromResult(admin);
            return adminMapper.MapToDTO(adminE);
        }

        public async Task<AdminDTO> GetAdminByNameAsync(string name)
        {
            var admin = adminDB.Find(admin => admin.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) ??
                throw new KeyNotFoundException("Admin not found");
            Admin adminE = await Task.FromResult(admin);
            return adminMapper.MapToDTO(adminE);
        }
        public void InsertAdmin(Admin admin)
        {
            adminDB.Add(admin);
        }
    }
}
