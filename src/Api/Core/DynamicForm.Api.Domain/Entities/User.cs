using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Api.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; } = true;

        public ICollection<RefreshToken> RefreshTokens { get; set; }

        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }


        public User(string firstName, string lastName, string email, string? contactNumber, byte[] passwordHash, byte[] passwordSalt) : this()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            PasswordSalt = passwordSalt;
            Status = Status;
            PasswordHash= passwordHash;
        }
    }
}
