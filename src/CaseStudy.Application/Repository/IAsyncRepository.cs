using CaseStudy.Domain.Common;
using System.Threading.Tasks;

namespace CaseStudy.Application.Repository
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetAsync(string id);
        Task<T> CreateAsync(T entity);
        Task RemoveAsync(string id);
        Task UpdateAsync(string id, T entity);
    }
}