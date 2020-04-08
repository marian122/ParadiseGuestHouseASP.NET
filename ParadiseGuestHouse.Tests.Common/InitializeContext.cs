using Microsoft.EntityFrameworkCore;
using ParadiseGuestHouse.Data;
using System;

namespace ParadiseGuestHouse.Tests.Common
{
    public static class InitializeContext
    {
        public static ApplicationDbContext CreateContextForInMemory()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new ApplicationDbContext(options);
        }
    }
}
