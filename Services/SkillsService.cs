using ATS_Friendly_CV_Generator.Data;
using ATS_Friendly_CV_Generator.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace ATS_Friendly_CV_Generator.Services
{
    public class SkillsService
    {
        private readonly ISqliteWasmDbContextFactory<AppDbContext> _dbContextFactory;


        public SkillsService(ISqliteWasmDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        //DELETE : delete a SkillItem
        public async Task<bool> DeleteSkillsItemAsync(int id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var SkillsItem = await context.SkillsItems.FindAsync(id);
            if (SkillsItem == null) return false;

            context.SkillsItems.Remove(SkillsItem);
            await context.SaveChangesAsync();
            return true;
        }


    }
}
