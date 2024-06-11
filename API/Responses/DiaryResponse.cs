using Domain.Models;

namespace API.Responses;

public class DiaryResponse
{
    public DiaryResponse(Diary diary)
    {
        Id = diary.Id;
        var notes = diary.DiaryNotes;
        foreach (var note in notes)
        {
            DiaryNotes.Add(new DiaryNoteResponse(note));
        }
    }

    public Guid Id { get; set; }
    public List<DiaryNoteResponse> DiaryNotes { get; set; }
}