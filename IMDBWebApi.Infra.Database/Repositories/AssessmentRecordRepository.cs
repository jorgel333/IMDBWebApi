using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Infra.Database.Context;
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
        public void Create(AssessmentRecord ar)
            => _context.AssessmentRecords.Add(ar);

        public void Delete(AssessmentRecord ar)
            => _context.AssessmentRecords.Remove(ar);

        public void Update(AssessmentRecord ar)
            => _context.AssessmentRecords.Update(ar);
    }
}
