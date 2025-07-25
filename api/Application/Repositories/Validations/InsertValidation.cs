using Application.Repositories.Validations.Interfaces;
using OpCuriosidade.Entities.PersonnelContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories.Validations
{
    public class InsertValidation(List<Admin> adminDB) : IValidation
    {   
        public bool IsAdminAlreadyRegistered(string email)
        {
            if (adminDB.Any(admin => admin.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }
            return false;
        }
    }
}
