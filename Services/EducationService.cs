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

        //DELETE : delete a EducationItem
        public async Task<bool> DeleteEducationItemAsync(int id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var EducationItem = await context.EducationItems.FindAsync(id);
            if (EducationItem == null) return false;

            context.EducationItems.Remove(EducationItem);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
