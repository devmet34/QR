using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;




namespace Infra
{
  public static class ConfigDB
  {
    /// <summary>
    /// mc, Extension method to add the DbContexts to the service collection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static IServiceCollection AddDBContexts(this IServiceCollection services, IConfiguration config)
    {
      string QrDbConnStr = config["Sql:ConnectionString:QrDb"] ?? throw new InvalidOperationException("Connection string 'Identity' not found.");

      services.AddDbContext<QrDbContext>(options => 
        options.UseSqlServer(QrDbConnStr, opt =>  opt.CommandTimeout(5)));
      return services;

    }
  }
}
