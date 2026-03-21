namespace ITask7.Services.Integrations.SalesForce;

public interface ISalesForceIntegrationService
{ 
    Task<string?> IntegrateUser(AdditionalProfileInfoDto model);
}