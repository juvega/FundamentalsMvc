using System.ComponentModel.DataAnnotations;

namespace NetFundamentals.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="The First Name is required.")]
        [Display(Name ="First Name")]
        [StringLength(40, ErrorMessage ="First Name required max {1} chars and min {2} chars.", MinimumLength =2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Last Name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Last Name required max {1} chars and min {2} chars.", MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(80, ErrorMessage ="{0} allows max {1} chars.")]
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage ="The field {0} is required.")]
        [StringLength(60, ErrorMessage = "{0} allows max {1} chars.")]
        [EmailAddress(ErrorMessage ="The email is invalid.")]
        public string Email { get; set; }
        public int? SupportRepId { get; set; }
    }
}
