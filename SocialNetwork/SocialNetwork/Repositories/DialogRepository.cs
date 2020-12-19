using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Repositories
{
    public class DialogRepository : IRepository<Dialog>
    {
        private readonly ApplicationContext _context;
        
        public DialogRepository(ApplicationContext context)
        {
            _context = context;
        }


        public Dialog GetEntity(string UserId, string FriendId)
        {
            var dialogs = GetAllEntities();
            foreach (var dialog in dialogs)
            {
                if (dialog.UserId == UserId && dialog.FriendId == FriendId)
                    return dialog;
            }
            return null;

        }

        public void SaveEntity(Dialog entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteEntity(Dialog entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
        
        public List<Dialog> GetAllEntities()
        {
            return _context.Dialog.ToList();
        }
    }
}