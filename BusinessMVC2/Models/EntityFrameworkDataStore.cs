using Google.Apis.Util.Store;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BusinessMVC2.Models
{
    public class EntityFrameworkDataStore : IDataStore
    {
        public async Task StoreAsync<T>(string key, T value)
        {
            using (var dbContext = new TokenDbContext())
            {
                var serializedValue = JsonConvert.SerializeObject(value);
                var token = await dbContext.Tokens.FindAsync(key);

                if (token == null)
                {
                    token = new Token { Key = key, Value = serializedValue };
                    dbContext.Tokens.Add(token);
                }
                else
                {
                    token.Value = serializedValue;
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync<T>(string key)
        {
            using (var dbContext = new TokenDbContext())
            {
                var token = await dbContext.Tokens.FindAsync(key);
                if (token != null)
                {
                    dbContext.Tokens.Remove(token);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task<T> GetAsync<T>(string key)
        {
            using (var dbContext = new TokenDbContext())
            {
                var token = await dbContext.Tokens.FindAsync(key);
                if (token == null)
                {
                    return default(T);
                }

                return JsonConvert.DeserializeObject<T>(token.Value);
            }
        }

        public async Task ClearAsync()
        {
            using (var dbContext = new TokenDbContext())
            {
                dbContext.Tokens.RemoveRange(dbContext.Tokens);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
