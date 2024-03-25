using Microsoft.EntityFrameworkCore;
using TBC.Repository;
using TBC.Services;
using TBC.Services.Interfaces.Repositories;
using TBC.Services.Interfaces.Services;

namespace TBC.Task.Configuration
{
    public static class DependencyConfiguration
    {
        public static void ConfigureDependency(this WebApplicationBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IIndividualService, IndividualService>();
            builder.Services.AddScoped<ICityService, CityService>();

            builder.Services.AddDbContext<TbcDbContext>(options => options.UseSqlServer(connectionString));
        }

    }
}
