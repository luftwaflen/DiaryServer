namespace API.Requests;

public class UpdateDiaryNoteRequest
{
    public string NoteId { get; set; }
    public string PressureSys { get; set; }
    public string PressureDia { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}