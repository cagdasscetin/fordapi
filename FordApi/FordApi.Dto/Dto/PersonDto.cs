
using FordApi.Base;
using System.ComponentModel.DataAnnotations;

namespace FordApi.Dto;

public class PersonDto : BaseDto
{
    [Required]
    [MaxLength(25)]
    [Display(Name = "Staff Id")]
    public string StaffId { get; set; }

    [Required]
    [MaxLength(500)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(500)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [EmailAddress]
    [MaxLength(500)]
    public string Email { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    [Phone]
    [MaxLength(25)]
    public string Phone { get; set; }

    [Required]
    [DateOfBirth]
    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }


    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

}
