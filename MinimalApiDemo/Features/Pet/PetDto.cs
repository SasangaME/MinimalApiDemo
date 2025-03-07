﻿using MinimalApiDemo.Common.Enums;

namespace MinimalApiDemo.Features.Pet;

public class PetDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}