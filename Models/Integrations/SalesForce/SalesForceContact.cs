using ITask7.Services.Integrations.SalesForce;

namespace ITask7.Models.Integrations.SalesForce;

public class SalesForceContact
{
    public string? FirstName { get; set; }               
    public string? LastName { get; set; }              
    public string? Email { get; set; }               
    public string? AccountId { get; set; }           
    public string? Title { get; set; }              
    public string? Department { get; set; }          
    public string? Phone { get; set; }               
    public SalesForceContact(AdditionalProfileInfoDto dto)
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Email = dto.Email;
        Title = dto.JobTitle;
        Department = dto.Department;
        Phone = dto.Phone;
    }
}