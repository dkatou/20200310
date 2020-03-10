using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api1Models.Data;
using api1Models.Models;

namespace api1Logic.Logics
{

    public class ItemLogic
    {
        private readonly api1Context _context;

        public ItemLogic(api1Context context)
        {
            _context = context;
        }

        public async Task<List<Item>> GetItem()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task<Item> GetItem(long id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return item;
            }

            return item;
        }


        public async Task<Item> PutItem(long id, Item item)
        {
            if (id != item.Id)
            {
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                }
                else
                {
                    throw;
                }
            }

            return item;
        }

        public async Task<Item> PostItem(Item item)
        {
            _context.Item.Add(item);
            await _context.SaveChangesAsync();

            return await GetItem(item.Id);
        }

        public async Task<Item> DeleteItem(long id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return item;
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(long id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}
