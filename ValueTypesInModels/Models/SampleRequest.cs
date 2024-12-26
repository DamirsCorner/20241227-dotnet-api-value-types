using System.ComponentModel.DataAnnotations;

namespace ValueTypesInModels.Models;

public class SampleRequest
{
    [Required]
    public Color? Required { get; set; }

    public Color? Optional { get; set; }
}
