using ITask7.Services.Integrations.SalesForce;

namespace ITask7.Models.Integrations.SalesForce;

public class SalesForceAccount
{
    public string? Name { get; set; }             
    public string? Industry { get; set; }         
    public string? Website { get; set; }           
    public string? Phone { get; set; }                  
    public string? Type { get; set; }       
    
    public SalesForceAccount(AdditionalProfileInfoDto dto)
    {
        if (dto.AccountType == "Business") Name = dto.CompanyName;
        else Name = dto.LastName + " personal";
        Industry = dto.Industry;
        Website = dto.Website;
        Phone = dto.Phone;
        Type = dto.AccountType;
    }
}