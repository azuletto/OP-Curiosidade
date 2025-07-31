using Application.Mapper.Interface;
using Application.Output.DTO;
using OpCuriosidade.Entities.PersonnelContext;

namespace Application.Mapper
{
    public class AdminMapper : IMapperBase
    {
        public AdminDTO MapToDTO(Admin admin)
        {
            if (admin == null)
            {
                return new AdminDTO();
            }
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
