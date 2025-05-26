using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
  public interface IExtApiIntegration
  {
    public Task<ExtProduct?> GetExtProductAsync(int id);
    public Task AddExtProductToDBAsync();
  }
}
