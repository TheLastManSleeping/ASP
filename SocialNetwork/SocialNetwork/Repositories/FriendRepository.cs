using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Repositories
{
    public class FriendRepository : IRepository<Friend>
    {
        private readonly ApplicationContext _context;


        public FriendRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Friend> GetAllEntities()
        {
            return _context.Friend.ToList();
        }

        public Friend GetEntity(string id, string id2)
        {
            throw new NotImplementedException();
        }

        public void SaveEntity(Friend friend)
        {
            _context.Entry(friend).State = friend.Id == default ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntity(Friend friend)
        {
            _context.Remove(friend);
            _context.SaveChanges();

        }
    }
}