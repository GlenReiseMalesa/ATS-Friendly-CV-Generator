using ATS_Friendly_CV_Generator.Data;
using ATS_Friendly_CV_Generator.Models;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

namespace ATS_Friendly_CV_Generator.Services
{
    public class InfoService
    {
        private readonly ISqliteWasmDbContextFactory<AppDbContext> _dbContextFactory;


        public InfoService(ISqliteWasmDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        // READ : Get single item
        public async Task<InfoItem?> GetInfoItemsByIdAsync(int Id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();
            return await context.InfoItems.FirstOrDefaultAsync(t => t.Id == Id);

        }
    }
}

