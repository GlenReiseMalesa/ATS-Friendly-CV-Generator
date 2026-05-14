using ATS_Friendly_CV_Generator.Data;
using ATS_Friendly_CV_Generator.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace ATS_Friendly_CV_Generator.Services
{
    public class ExperienceService
    {
        private readonly ISqliteWasmDbContextFactory<AppDbContext> _dbContextFactory;


        public ExperienceService(ISqliteWasmDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // READ : Get single item
        public async Task<ExperienceItem?> GetSkillsItemsByIdAsync(int Id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.ExperienceItems.FirstOrDefaultAsync(t => t.Id == Id);

        }
    }
}
