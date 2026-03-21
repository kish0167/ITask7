using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ITask7.Services.DbApi.Users;
using Microsoft.Extensions.Options;

namespace ITask7.Services.Integrations.SalesForce;

public class SalesForceIntegrationService(IOptions<SalesForceOptions> options, IUserService userService) : ISalesForceIntegrationService
{
    private readonly SalesForceOptions _options = options.Value;
    public async Task<string?> IntegrateUser(AdditionalProfileInfoDto model)
    {
        (string? instanceUrl, string? token) = await GetAccessTokenAsync();
        if (token == null || instanceUrl == null) return null;
        return await CreateAccountAndContactAsync(instanceUrl, token, model);
    }
    
    private async Task<(string?, string?)> GetAccessTokenAsync()
    {
        using HttpClient client = new HttpClient();
        FormUrlEncodedContent requestBody = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", _options.ClientId),
            new KeyValuePair<string, string>("client_secret", _options.ClientSecret)
        });
        HttpResponseMessage response = await client.PostAsync(_options.BaseUrl + "/services/oauth2/token", requestBody);
        string jsonResponse = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) return (null, null);
        using JsonDocument doc = JsonDocument.Parse(jsonResponse);
        return (doc.RootElement.GetProperty("instance_url").GetString() , doc.RootElement.GetProperty("access_token").GetString());
    }
    
    private async Task<string?> CreateAccountAndContactAsync(string instanceUrl, string accessToken,
        AdditionalProfileInfoDto dto)
    {
        using HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        HttpResponseMessage accountResponse = await Post(instanceUrl, "/Account/", client, dto.ToAccount());
        if (!accountResponse.IsSuccessStatusCode) return null;
        string? newAccountId = await GetId(accountResponse);
        if (newAccountId == null) return null;

        HttpResponseMessage contactResponse = await Post(instanceUrl, "/Contact", client, dto.ToContact(newAccountId));
        if (!contactResponse.IsSuccessStatusCode) return null;
        return await GetId(contactResponse);
    }

    private async Task<string?> GetId(HttpResponseMessage response)
    {
        string resultJson = await response.Content.ReadAsStringAsync();
        using JsonDocument contactDoc = JsonDocument.Parse(resultJson);
        return contactDoc.RootElement.GetProperty("id").GetString();
    }

    private async Task<HttpResponseMessage> Post(string instanceUrl, string endpoint, HttpClient client, object data)
    {
        return await client.PostAsync(
            instanceUrl.TrimEnd('/') + "/services/data/v60.0/sobjects" + endpoint,
            new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
        );
    }
}