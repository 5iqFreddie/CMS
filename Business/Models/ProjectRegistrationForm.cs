namespace Business.Models;

public class ProjectRegistrationForm
{
   
    public string ProjectName { get; set; } = null!;
    public string Description { get; set; } = null!;

    public int CustomerId { get; set; }
}
