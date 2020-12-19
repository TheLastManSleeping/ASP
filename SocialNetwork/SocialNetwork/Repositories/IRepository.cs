using System;
using System.Collections.Generic;

namespace SocialNetwork.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAllEntities();
        T GetEntity(string id, string id2);
        void SaveEntity(T entity);
        void DeleteEntity(T entity);
        
    }
}