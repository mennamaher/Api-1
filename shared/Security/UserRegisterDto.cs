using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.Security
{
    public record UserRegisterDto
    {
        [Required(ErrorMessage ="Display name is rquired")]
        public string DisplayName { get; init; }
        [Required(ErrorMessage = "email name is rquired")]

        public string Email { get; init; }
        [Required(ErrorMessage = "Password name is rquired")]

        public string Password { get; init; }
        public string userName { get; init; }
        public string? phoneNo { get; init; }


    }
}
