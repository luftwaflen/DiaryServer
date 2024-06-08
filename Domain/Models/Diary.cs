namespace Domain.Models;

public class Diary
{
    public Diary()
    {
        Id = Guid.NewGuid();
        DiaryNotes = new List<DiaryNote>();
    }

    public Guid Id { get; set; }
    public virtual List<DiaryNote> DiaryNotes { get; set; }
}