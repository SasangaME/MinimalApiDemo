var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var buildInfo = new BuildDto();
builder.Configuration.GetSection("Build").Bind(buildInfo);

app.MapGet("/", () => Results.Json(buildInfo));

// pet endpoints
app.MapGet("/api/pets", () => Results.Ok(GetPets()));

app.MapGet("/api/pets/{id}", (int id) =>
{
    var pet = GetPetById(id);
    return pet is not null ? Results.Ok(pet) : Results.NotFound();
});

app.MapPost("/api/pets", (Pet pet) =>
{
    var newPet = CreatePet(pet);
    return Results.Created($"/api/pets/{newPet.Id}", newPet);
});

app.UseHttpsRedirection();

app.Run();

IEnumerable<Pet> GetPets()
{
    return new List<Pet>
    {
        new Pet { Id = 1, Name = "Pippa", Gender = Gender.Female },
        new Pet { Id = 2, Name = "Ollie", Gender = Gender.Male }
    };
}

Pet? GetPetById(int id)
{
    return GetPets().FirstOrDefault(p => p.Id == id);
}

Pet CreatePet(Pet pet)
{
    pet.Id = GetPets().Max(p => p.Id) + 1;
    return pet;
}

internal record BuildDto
{
    public string Title { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}

record Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
}

enum Gender
{
    Male = 1,
    Female,
    Unknown
}