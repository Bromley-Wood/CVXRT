using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingTool.Models
{
    public class ActionsService : IActionsService
    {
        private readonly ActionsDbContext _context;

        public ActionsService(ActionsDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(long id)
        {
            _context.Actions.Remove(new Action { Id = id });
            await _context.SaveChangesAsync();
        }

        public Action Find(long id)
        {
            return _context.Actions.FirstOrDefault(x => x.Id == id);
        }

        public Task<Action> FindAsync(long id)
        {
            return _context.Actions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Action> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _context.Actions
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<Action[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Action action)
        {
            var isNew = action.Id == default(long);

            _context.Entry(action).State = isNew ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}
