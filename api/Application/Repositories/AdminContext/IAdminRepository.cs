using Application.Output.DTO;
using Application.Output.Results.Interfaces;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.AdminContext
{
    public interface IAdminRepository
    {
        IResultBase InsertAdmin(Admin admin);
        Task<AdminDTO> GetAdminByIdAsync(Guid id);
        Task<AdminDTO> GetAdminByEmailAsync(string email);
        Task<AdminDTO> GetAdminByNameAsync(string name);
        IResultBase DeleteAdminByIdAsync(Guid id);
        IResultBase UpdateAdminAsync(AdminDTO adminDTO);
        IResultBase CheckPasswordAsync(AdminDTO adminDTO, string password);

    }
}
