using System.Linq;
using System.Threading.Tasks;

namespace ReportingTool.Models
{
    public interface IActionsService
    {
        Task DeleteAsync(long id);
        Action Find(long id);
        Task<Action> FindAsync(long id);
        IQueryable<Action> GetAll(int? count = null, int? page = null);
        Task<Action[]> GetAllAsync(int? count = null, int? page = null);
        Task SaveAsync(Action action);
    }
}
