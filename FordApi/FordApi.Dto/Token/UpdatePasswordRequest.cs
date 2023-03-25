using FordApi.Base;
using System.ComponentModel.DataAnnotations;

namespace FordApi.Dto;

public class UpdatePasswordRequest
{
    [Required]
    [PasswordAttribute]
    public string OldPassword { get; set; }

    [Required]
    [Password]
    public string NewPassword { get; set; }
}
