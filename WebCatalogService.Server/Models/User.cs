using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCatalogService.Server.Models
{
    [Table("AspNetUsers")]
    public class User:IdentityUser
    {
        public Guid Id { get; set; }
        public string Email {  get; set; }
        public Guid ClientId { get; set; }
    }
}
