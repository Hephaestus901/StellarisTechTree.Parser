using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StellarisTechTree.WebApp.Controllers;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Area
{
    [Display(Name = "physics")]
    Physics,
    [Display(Name = "society")]
    Society,
    [Display(Name = "engineering")]
    Engineering
}