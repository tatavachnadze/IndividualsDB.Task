using TBC.DTO;
using TBC.Services.Interfaces.Repositories;

namespace TBC.Repository
{
    internal sealed class IndividualsRepository : RepositoryBase<Individual>, IIndividualRepository
    {
        internal IndividualsRepository(TbcDbContext context) : base(context)
        {

        }
    }
}
