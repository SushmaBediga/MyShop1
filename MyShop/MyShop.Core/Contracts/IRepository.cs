using MyShop.Core.Models;
using System.Linq;

namespace MyShop.Core.Contracts
{
    // we have created IRepository interface that declares all the repository methods which we want to use
    //then we have put that in core project so that we refer it in all projects
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}