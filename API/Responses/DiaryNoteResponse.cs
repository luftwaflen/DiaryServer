using Domain.Models;

namespace API.Responses;

public class DiaryNoteResponse
{
    public DiaryNoteResponse(DiaryNote diaryNote)
    {
        Id = diaryNote.Id;
        Date = diaryNote.Date;
        PressureSys = diaryNote.PressureSys;
        PressureDia = diaryNote.PressureDia;
        Pulse = diaryNote.Pulse;
        Description = diaryNote.Description;
    }
    
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string PressureSys { get; set; }
    public string PressureDia { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}