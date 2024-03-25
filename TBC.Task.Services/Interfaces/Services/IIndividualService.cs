using TBC.DTO;

namespace TBC.Services.Interfaces.Services
{
    public interface IIndividualService
    {
        Task<Individual> GetIndividual(int individualId);
        Task<IQueryable<Individual>> GetIndividuals();
        void AddIndividual(Individual individual);
        void UpdateIndividual(Individual individual);
        void DeleteIndividual(int individualId);

    }
}
