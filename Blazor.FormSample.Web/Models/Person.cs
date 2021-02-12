using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.FormSample.Web.Models
{
    public class Person
    {
        [Key] public long Id { get; set; }

        [Required]
        [Display(Description = "Username")]
        [StringLength(100, ErrorMessage = "Name is too long")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Description = "Job")]
        [DataType(DataType.Text)]
        public string Job { get; set; }

        [DataType("MultiSelect")]
        [Display(Description = "Skills")]
        public string Skill { get; set; }

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