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



        //DELETE : delete a InfoItem
        public async Task<bool> DeleteInfoItemAsync(int id)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var InfoItem = await context.InfoItems.FindAsync(id);
            if (InfoItem == null) return false;

            context.InfoItems.Remove(InfoItem);
            await context.SaveChangesAsync();
            return true;
        }


        //UPDATE : update a InfoItem
        public async Task<bool> UpdateInfoAsync(int id, string newFullName, string newJobTitle, string newSummary, string newEmail, string newPhone, string newLocation, string newWebsite)
        {
            await using var context = await _dbContextFactory.CreateDbContextAsync();

            var InfoItem = await context.InfoItems.FindAsync(id);
            if (InfoItem == null) return false;

            InfoItem.FullName = newFullName;
            InfoItem.JobTitle = newJobTitle;
            InfoItem.Summary = newSummary;
            InfoItem.Email = newEmail;
            InfoItem.Phone = newPhone;
            InfoItem.Location = newLocation;
            InfoItem.Website = newWebsite;
     

            await context.SaveChangesAsync();
            return true;
        }
    }
}

