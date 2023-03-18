﻿namespace FordApi.Base;

public abstract class BaseModel
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
