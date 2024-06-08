namespace Domain.Models;

public class Diary
{
    public Guid Id { get; set; }
    public virtual List<DiaryNote> DiaryNotes { get; set; }
}