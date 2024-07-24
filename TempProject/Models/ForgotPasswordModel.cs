using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using TempProject.Repository;
using System.ComponentModel.DataAnnotations;

namespace TempProject.Models
{
    public class ForgotPasswordModel 
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

      
    }
}
