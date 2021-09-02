using OA_DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA_Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Add(T record);
    }
}
