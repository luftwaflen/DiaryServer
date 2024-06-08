﻿namespace Domain.Models;

public class Patient : User
{
    public virtual Diary Diary { get; set; }
    public virtual List<Recipe>? Recipes { get; set; }
}