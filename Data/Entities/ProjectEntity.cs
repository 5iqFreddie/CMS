namespace Data.Entities;

public class ProjectEntity
{

    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
}