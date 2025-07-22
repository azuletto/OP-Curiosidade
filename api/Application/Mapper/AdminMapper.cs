using Application.Mapper.Interface;
using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class AdminMapper : IMapperBase
    {
        public AdminDTO MapToDTO(Admin admin)
        {
            if (admin == null)
            {
                return new AdminDTO
                {
                    Id = null,
                    Name = null,
                    Email = null,
                    IsDeleted = false,
                    TimeStamp = null,
                    Password = null
                };
            }
            return new AdminDTO
            {
                Id = null,
                Name = null,
                Email = null,
                IsDeleted = null,
                TimeStamp = null,
                Password = null
            };
        }
        public AdminDTO MapToDTO(Task<AdminDTO> adminTask)
        {
            if (adminTask == null)
            {
                return new AdminDTO
                {
                    Id = null,
                    Name = null,
                    Email = null,
                    IsDeleted = null,
                    TimeStamp = null,
                    Password = null
                };
            }

            // Obtém o resultado sincronamente (só use em casos específicos!)
            AdminDTO admin = adminTask.GetAwaiter().GetResult();

            return new AdminDTO
            {
                Id = admin.Id,
                Name = admin.Name,
                Email = admin.Email,
                IsDeleted = admin.IsDeleted,
                TimeStamp = admin.TimeStamp,
                Password = admin.Password
            };
        }
    }
}
