using grocercy.Api.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerogercyApp.Api.Data.Entities
{
    [Table(nameof(User))]
    public class User//Dependent
    {
        public User()
        {
            Addresses = new HashSet<Address>();
        }
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Email { get; set; }
        //we shouldn't have plain password
        //having this for simplicity
        [Required,MaxLength(25)]
        [Comment("We should not have plain password. Having this just for simplicity and demo purpose")]
        public string Password { get; set; }
        [Required, MaxLength(20)]   
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }    
        public static IEnumerable<User> GetInitialUsers()
        {
            return new List<User>
            {
                new User()
                {
                    Id = 1,
                    Name="wael shaaban",
                    Email = "hackerwael55@gmail.com",
                    Mobile="01011354758",
                    Password="1234567",
                    RoleId = DatabaseConstants.Roles.Admin.Id,
                },
            };
        }
    }
}