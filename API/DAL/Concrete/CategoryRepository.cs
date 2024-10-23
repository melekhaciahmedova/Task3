using API.DAL.Abstract;
using API.DAL.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Concrete
{
    public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
    {
        private readonly AppDbContext _context = appDbContext;
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
           .Include(c => c.SubCategories)
           .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
            .Include(c => c.SubCategories)
            .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
