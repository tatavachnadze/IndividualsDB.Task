using TBC.DTO;
using TBC.Services.Interfaces.Repositories;
using TBC.Services.Interfaces.Services;

namespace TBC.Services
{
    public sealed class IndividualService : IIndividualService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndividualService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<Individual> GetIndividual(int individualId)
        {
            Individual individual = _unitOfWork.IndividualsRepository.Get(individualId);
            if (individual != null)
            {
                return Task.FromResult(individual);
            }
            else
            {
                throw new InvalidDataException("PersonId could not be found within data.");
            }
        }

        public Task<IQueryable<Individual>> GetIndividuals()
        {
            var individuals = _unitOfWork.IndividualsRepository.Set();
            if (individuals != null)
            {
                return Task.FromResult(individuals);
            }
            else
            {
                throw new InvalidDataException("Persons could not be found within data.");
            }
        }

        public void AddIndividual(Individual individual)
        {
            if (individual == null) throw new ArgumentNullException("The person needs to be provided.");
            _unitOfWork.IndividualsRepository.Insert(individual);
            _unitOfWork.SaveChanges();
        }

        public void UpdateIndividual(Individual individual)
        {
            if (individual == null) throw new ArgumentNullException("The person needs to be provided.");
            _unitOfWork.IndividualsRepository.Update(individual);
            _unitOfWork.SaveChanges();
        }

        public void DeleteIndividual(int individualId)
        {
            Individual individual = _unitOfWork.IndividualsRepository.Get(individualId) ?? throw new InvalidDataException("CustomerId could not be found within data.");
            individual.IsDeleted = true;
            _unitOfWork.IndividualsRepository.Update(individual);
            _unitOfWork.SaveChanges();
        }
    }
}
