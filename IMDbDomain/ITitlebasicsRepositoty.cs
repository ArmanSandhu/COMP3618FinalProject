using IMDbDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMDbDomain
{
    
    public interface ITitlebasicsRepositoty : IRepository<Titlebasics>
    {
        Task<IEnumerable<Titlebasics>> GetAllTitlebasicsAsync();
        Task<Titlebasics> GetTitlebasicByIdAsync(Guid id);
        Task<Titlebasics> GetOwnerWithDetailsAsync(Guid id);
        Task CreateOwnerAsync(Titlebasics titlebasic);
        Task UpdateOwnerAsync(Titlebasics dbTitlebasic, Titlebasics titlebasic);
        Task DeleteOwnerAsync(Titlebasics titlebasic);
    }
}
