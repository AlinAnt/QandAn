using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using QandAn.Models;

public class DatabaseService
{
    private readonly ApplicationDbContext _dbContext;

    public DatabaseService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Question> GetQuestionById(int? id)
    {
        return _dbContext.Questions
                         .Include(u => u.Answers)
                         .ThenInclude(u => u.User)
                         .Where(d => d.ID == id)
                         .FirstOrDefaultAsync();
    }

    public Task<Answer> GetAnswerById(int id){
        return _dbContext.Answers
                         .Include(u => u.Question)
                         .ThenInclude(q => q.Answers)
                         .Include(u => u.User)
                         .Include(a => a.Voting)
                         .Where(a => a.ID == id)
                         .FirstOrDefaultAsync();
    }
}