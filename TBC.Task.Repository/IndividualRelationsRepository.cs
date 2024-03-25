using TBC.DTO;
using TBC.Services.Interfaces.Repositories;

namespace TBC.Repository
{
    internal sealed class IndividualRelationsRepository : RepositoryBase<IndividualRelations>, IIndividualRelationsRepository
    {
        internal IndividualRelationsRepository(TbcDbContext context) : base(context)
        {
        }
    }
}
