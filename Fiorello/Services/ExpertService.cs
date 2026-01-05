using Fiorello.Data;
using Fiorello.Services.Interfaces;
using Fiorello.ViewModels.Blog;
using Fiorello.ViewModels.Expert;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;
        public ExpertService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpertVM>> GetAllAdminAsync()
        {
            IEnumerable<ExpertVM> experts = await _context.Experts.
                Select(e => new ExpertVM
                {
                    FullName = e.FullName,
                    Position = e.Position,
                    Image = e.Image
                })
                .ToListAsync();
            return experts;
        }

        public async Task<IEnumerable<ExpertUIVM>> GetAllAsync()
        {
            IEnumerable<ExpertUIVM> experts = await _context.Experts.
                Select(e => new ExpertUIVM
                {
                    FullName = e.FullName,
                    Position = e.Position,
                    Image = e.Image

                })
                .ToListAsync();
            return experts;

        }
    }
}
