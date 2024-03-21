using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class UserOperationClaim : BaseEntity<int>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }

    public virtual User User { get; set; }
    public virtual OperationClaim OperationClaim { get; set; }

    public UserOperationClaim()
    {
    }

    public UserOperationClaim(int id, int userId, int operationClaimId)
    {
        Id = id;
        UserId = userId;
        OperationClaimId = operationClaimId;
    }
}