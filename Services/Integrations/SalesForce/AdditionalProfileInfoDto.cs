using ITask7.Models.Integrations.SalesForce;

namespace ITask7.Services.Integrations.SalesForce;

public class AdditionalProfileInfoDto
{
    public string UserId { get; set; }
    public string? AccountType { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? CompanyName { get; set; }
    public string? Industry { get; set; }
    public string? Website { get; set; }
    public string? JobTitle { get; set; }
    public string? Department { get; set; }
    public string? Phone { get; set; }

    public SalesForceAccount ToAccount()
    {
        return new SalesForceAccount(this);
    }

    public SalesForceContact ToContact(string accountId)
    {
        return new SalesForceContact(this)
        {
            AccountId = accountId
        };
    }
}
