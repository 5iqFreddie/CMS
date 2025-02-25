using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    //Read All
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = await _db
            .Include(x => x.Customer)
            .ToListAsync();

        return entities;
    }

    //Find one
    public override async Task<ProjectEntity?> GetOneAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _db
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(expression);

        return entity;
    }
}