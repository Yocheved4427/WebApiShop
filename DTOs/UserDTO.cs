using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record UserDTO
    (
        int Id,
        
        string Email,

        string FirstName,

        string LastName,

        string Password

        
    );
}
