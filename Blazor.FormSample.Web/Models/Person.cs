using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FormSample.Web.Models
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Description = "Username")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Description = "Job")]
        [DataType(DataType.Text)]
        public string Job { get; set; }

        [Required]
        [Display(Description = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Description = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Display(Description = "Picture URL")]
        [DataType(DataType.Text)]
        public string PictureUrl { get; set; }
    }
}