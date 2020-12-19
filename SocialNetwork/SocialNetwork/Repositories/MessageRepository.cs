using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Repositories
{
    public class MessageRepository : IRepository<Message>
    {
        private readonly ApplicationContext _context;


        public MessageRepository(ApplicationContext context)
        {
            _context = context;
        }
        

        Message IRepository<Message>.GetEntity(string id, string id2)
        {
            throw new NotImplementedException();
        }

        public void SaveEntity(Message entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntity(Message entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public List<Message> GetAllEntities()
        {
            return _context.Message.ToList();
        }

    }
}