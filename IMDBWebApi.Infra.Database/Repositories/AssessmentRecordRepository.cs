using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBWebApi.Infra.Database.Repositories
{
    internal class AssessmentRecordRepository : IAssessmentRecordRepository
    {
        private readonly AppDbContext _context;
        public AssessmentRecordRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(AssessmentRecord assessmentRecord)
            => _context.AssessmentRecords.Add(assessmentRecord);

        public void Delete(AssessmentRecord assessmentRecord)
            => _context.AssessmentRecords.Remove(assessmentRecord);

        public void Update(AssessmentRecord assessmentRecord)
            => _context.AssessmentRecords.Update(assessmentRecord);

        public async Task<bool> IsUniqueAssessmentRecord(int commonUserId, int movieId, CancellationToken cancellationToken)
            => await _context.AssessmentRecords.AnyAsync(a => a.CommonUserId == commonUserId
            && a.MovieId == movieId, cancellationToken) is false;
    }
}
