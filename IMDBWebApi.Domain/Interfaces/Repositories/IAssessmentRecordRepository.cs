using IMDBWebApi.Domain.Entities;

namespace IMDBWebApi.Domain.Interfaces.Repositories
{
    public interface IAssessmentRecordRepository
    {
        void Create(AssessmentRecord ar);
        void Update(AssessmentRecord ar);
        void Delete(AssessmentRecord ar);

    }
}
