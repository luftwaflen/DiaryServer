using Domain.Models;

namespace API.Responses;

public class RecipeResponse
{
    public RecipeResponse(Recipe recipe)
    {
        Id = recipe.Id;
        DoctorId = recipe.DoctorId;
        PatientId = recipe.PatientId;
        Text = recipe.Text;
    }

    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public string Text { get; set; }
}