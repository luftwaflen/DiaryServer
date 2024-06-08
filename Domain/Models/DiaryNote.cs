namespace Domain.Models;

public class DiaryNote
{
    public DiaryNote(string pressureSys, string pressureDia, string pulse, string description)
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        PressureSys = pressureSys;
        PressureDia = pressureDia;
        Pulse = pulse;
        Description = description;
    }

    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string PressureSys { get; set; }
    public string PressureDia { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}