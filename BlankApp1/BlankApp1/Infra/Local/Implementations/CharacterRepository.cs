using BlankApp1.Entities.SQLEntities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Infra.Local.Implementations
{
    public class CharacterRepository
    {
        readonly SQLiteAsyncConnection _database;

        public CharacterRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Character>().Wait();
        }

        public Task<List<Character>> GetCharactersAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        public Task<Character> GetCharacterAsync(int id)
        {
            return _database.Table<Character>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCharacterAsync(Character Character)
        {
            if (Character.ID != 0)
            {
                return _database.UpdateAsync(Character);
            }
            else
            {
                return _database.InsertAsync(Character);
            }
        }

        public Task<int> DeleteCharacterAsync(Character Character)
        {
            return _database.DeleteAsync(Character);
        }
    }
}
