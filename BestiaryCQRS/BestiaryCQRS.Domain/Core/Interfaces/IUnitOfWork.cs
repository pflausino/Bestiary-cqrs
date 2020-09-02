using System;
using System.Threading.Tasks;

namespace BestiaryCQRS.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();

    }
}