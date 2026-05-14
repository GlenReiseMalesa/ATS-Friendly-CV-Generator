using ATS_Friendly_CV_Generator.Data;
using ATS_Friendly_CV_Generator.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace ATS_Friendly_CV_Generator.Services
{
    public class EducationService
    {
        private readonly ISqliteWasmDbContextFactory<AppDbContext> _dbContextFactory;


        public EducationService(ISqliteWasmDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // READ : Get single item
        public async Task<EducationItem?> GetSkillsItemsByIdAsync(int Id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.EducationItems.FirstOrDefaultAsync(t => t.Id == Id);

        }
    }
}
