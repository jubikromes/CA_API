namespace Application.Entities;

public class Branch : BaseEntity
{
    public string BranchName { get; set; }
    public Company Company { get; set; }
    public Guid CompanyId { get; set; }
}
