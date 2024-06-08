﻿namespace Domain.Models;

public class DiaryNote
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string PressureSys { get; set; }
    public string PressureDia { get; set; }
    public string Pulse { get; set; }
    public string Description { get; set; }
}