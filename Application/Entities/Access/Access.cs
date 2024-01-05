
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Entities.Access;

public class Access : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? CompanyId { get; set; }
    public Company Company { get; set; }
    public Guid? BranchId { get; set; }
    public Branch Branch { get; set; }
    public Guid? CurrencyId { get; set; }
    public Currency Currency { get; set; }
}
