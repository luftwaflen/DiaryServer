using Domain.Models;

namespace API.Responses;

public class FamilyResponse
{
    public FamilyResponse(Family family)
    {
        Id = family.Id;
        FamilyMembers = new List<UserResponse>();
        var members = family.FamilyMembers;
        foreach (var user in members)
        {
            FamilyMembers.Add(new UserResponse(user));
        }
    }

    public Guid Id { get; set; }
    public List<UserResponse> FamilyMembers { get; set; }
}