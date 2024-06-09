namespace Domain.Models;

public class Recipe
{
    public Recipe(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
    }
    public Recipe(string text, Patient patient, Doctor doctor) : this(text)
    {
        Patient = patient;
        PatientId = patient.Id;
        Doctor = doctor;
        DoctorId = doctor.Id;
    }

    public Guid Id { get; set; }
    public Guid DoctorId { get; set; }
    public Guid PatientId { get; set; }
    public string Text { get; set; }

    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
}