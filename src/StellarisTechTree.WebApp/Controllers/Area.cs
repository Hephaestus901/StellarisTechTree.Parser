using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StellarisTechTree.WebApp.Controllers;

[JsonConverter(typeof(JsonStringEnumConverter))]
[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API")]
public enum Area
{
    [Display(Name = "physics")]
    Physics,
    [Display(Name = "society")]
    Society,
    [Display(Name = "engineering")]
    Engineering
}