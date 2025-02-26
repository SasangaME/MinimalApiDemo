using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalApiDemo.Features.Pet;

public class Pet
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public Breed? Breed { get; set; }
    public Color Color { get; set; } = new();
    public double Weight { get; set; }
    public DateOnly BirthDate { get; set; }
}

public class Breed
{
    public string Name { get; set; } = string.Empty;
    public string? CommonName { get; set; }
    public string? Description { get; set; }
}

public class Color
{
    public string GeneralColor { get; set; } = string.Empty;
    public string? Body { get; set; }
    public string? Face { get; set; }
    public string? Legs { get; set; }
    public string? Tail { get; set; }
}