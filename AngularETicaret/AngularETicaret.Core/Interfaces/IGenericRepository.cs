using AngularETicaret.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularETicaret.Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity //baseentityden türesin ve newlenebilsin diyorum
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();//performansı arttırmaya calısmak icin IReadonlyList kullanıyo entity tarafında cekerken bir kopya olusturuyomus normalde
    }
}
