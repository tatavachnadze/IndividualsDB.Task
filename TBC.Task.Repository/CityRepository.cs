using TBC.DTO;
using TBC.Services.Interfaces.Repositories;

namespace TBC.Repository
{
    internal sealed class CityRepository : RepositoryBase<City>, ICityRepository
    {
        internal CityRepository(TbcDbContext context) : base(context)
        {

        }
    }
}
