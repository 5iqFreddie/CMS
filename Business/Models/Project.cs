namespace Business.Models;

public class Project
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public Customer Customer { get; set; } = null!;
}