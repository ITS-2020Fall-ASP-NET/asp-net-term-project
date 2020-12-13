using NeighTrade.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NeighTrade.Models
{
    public class User : IValidatableObject
    {
        public int UserId { get; set; }

        [StringLength(50)]
        [Index("Ix_Email", Order = 1, IsUnique = true)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        public decimal Reputation { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            NeighTradeContext db = new NeighTradeContext();
            List<ValidationResult> validationResult = new List<ValidationResult>();
            var validateEmail = db.Users.FirstOrDefault(x => x.Email == Email && x.UserId != UserId);
            if (validateEmail != null) {
                ValidationResult errorMessage = new ValidationResult
                ("Email already exists.", new[] { "Email" });
                validationResult.Add(errorMessage);
                return validationResult;
            } else {
                return validationResult;
            }
        }
    }
}