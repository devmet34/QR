using Core.Entities;
using Core.Interfaces;
using Infra;
using Microsoft.Extensions.Configuration;

namespace App.Services
{
  public class ExtApiIntegrationService : IExtApiIntegration
  {
    private readonly QrDbContext _qrDbContext;
    private readonly HttpClient _httpClient = new HttpClient();

    public ExtApiIntegrationService(QrDbContext qrDbContext, IConfiguration config)
    {
      _qrDbContext = qrDbContext;
      _httpClient.BaseAddress = new Uri(config["DummyExtApiUri"] ?? throw new InvalidOperationException("Base URL for external API not found."));
    }



    public async Task AddExtProductToDBAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<ExtProduct?> GetExtProductAsync(int id)
    {

      try
      {
        using var response = await _httpClient.GetAsync(id.ToString());
        if (response.IsSuccessStatusCode)
        {
          var json = response.Content.ReadAsStringAsync().Result;
          var extProduct = System.Text.Json.JsonSerializer.Deserialize<ExtProduct>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
          if (extProduct != null)
          {
            // Add the product to the database
            _qrDbContext.ExtProducts.Add(extProduct);
            await _qrDbContext.SaveChangesAsync();
            return extProduct;
          }
          else
          {
            return await GetExtProductFromDbAsync(id);
          }


        }
        return await GetExtProductFromDbAsync(id);
      }
      catch
      {
        return await GetExtProductFromDbAsync(id);

      }

    }

    private async Task<ExtProduct?> GetExtProductFromDbAsync(int id)
    {
      return await _qrDbContext.ExtProducts.FindAsync(id);

    }


  }
}
