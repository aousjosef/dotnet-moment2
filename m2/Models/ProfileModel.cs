using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace m2.Models;

public class ProfileModel
{

    //Properites

    [Required]
    [Display(Name = "Username")]
    public string? Name { get; set; }

    [Display(Name = "Age of user")]
    [Required]
    public int? Age { get; set; }

    [Display(Name = "Workplace")]
    [Required]
    public string? Work { get; set; }


    [Required]
    public string? City { get; set; }


}
