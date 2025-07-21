using Application.Mapper;
using Application.Output.DTO;
using Application.Output.Results;
using Application.Output.Results.Interfaces;
using Application.Repositories.Validations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.AdminContext
{
    public class AdminRepository(List<Admin> adminDB) : IAdminRepository
    {
        public InsertValidation InsertValidation { get; } = new(adminDB);
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
        public IResultBase UpdateAdminAsync(AdminDTO adminDTO)
        {
            Result result;
            var adminToEdit = adminDB.Find(adminToEdit => adminToEdit.Id == adminDTO.Id) ??
                throw new KeyNotFoundException("Admin not found");
            adminToEdit.Name = adminDTO.Name;
            adminToEdit.Email = adminDTO.Email;
            adminToEdit.SetPassword(adminDTO.Password);

            if (adminToEdit.Validation() == false)
            {
                result = new Result(resultCode: 400, message: "Erro na criação do admin ", isOk: false);
                return result;
            }

            adminDB[adminDB.IndexOf(adminToEdit)] = adminToEdit;
            result = new Result(resultCode: 200, message: "Dados do admin atualizados com sucesso.", isOk: true);
            result.SetData(adminMapper.MapToDTO(adminToEdit));
            return result;
        }
        public IResultBase InsertAdmin(Admin admin)
        {
            Result result;
            if (InsertValidation.IsAdminAlreadyRegistered(admin.Email) == false)
            {
                result = new Result(resultCode: 201, message: "Admin criado com sucesso.", isOk: true);
                adminDB.Add(admin);
                result.SetData(adminMapper.MapToDTO(admin));
                return result;
            }
            else
            {
                result = new Result(resultCode: 400, message: "Admin já existente", isOk: false);
                Notification notification = new Notification("O email já está sendo utilizado. Tente novamente.", "alreadyDb");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
        }
        public IResultBase CheckPasswordAsync(AdminDTO admin, string password)
        {
            Result result;
            if (password == null)
            {
                result = new Result(resultCode: 400, message: "Senha não pode ser vazia", isOk: false);
                return result;
            }
            else if (admin.Password == password)
            {
                result = new Result(resultCode: 200, message: "Senha correta", isOk: true);
                return result;
            }
            else
            {
                Console.WriteLine("Senha digitada: " + password);
                Console.WriteLine("Senha do admin: " + admin.Password);

                result = new Result(resultCode: 400, message: "Senha incorreta", isOk: false);
                Notification notification = new Notification("Senha incorreta. Tente novamente.", "password");
                result.SetNotifications(new List<Notification> { notification });
                return result;
            }
        }
    }
}
