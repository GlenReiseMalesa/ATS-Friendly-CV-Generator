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

        //DELETE : delete a ExperienceItem
        public async Task<bool> DeleteExperienceItemAsync(int id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var ExperienceItem = await context.ExperienceItems.FindAsync(id);
            if (ExperienceItem == null) return false;

            context.ExperienceItems.Remove(ExperienceItem);
            await context.SaveChangesAsync();
            return true;
        }




    }
}
