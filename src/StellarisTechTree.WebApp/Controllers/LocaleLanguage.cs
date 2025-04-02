using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StellarisTechTree.WebApp.Controllers;

public enum LocaleLanguage
{
    [Display (Name = "braz_por")]
    Brazil,
    [Display (Name = "english")]
    English,
    [Display (Name = "french")]
    French,
    [Display (Name = "german")]
    German,
    [Display (Name = "japanese")]
    Japanese,
    [Display (Name = "korean")]
    Korean,
    [Display (Name = "polish")]
    Polish,
    [Display (Name = "russian")]
    Russian,
    [Display (Name = "simp_chinese")]
    SimplifiedChinese,
    [Display (Name = "spanish")]
    Spanish
}