namespace API.Requests;

public class AddDiaryNoteRequest
{
    public string PatientId { get; set; }
    public string PressureSys { get; set; }
    public string PressureDia { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}