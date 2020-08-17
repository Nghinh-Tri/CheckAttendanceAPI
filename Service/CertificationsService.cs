using System.Linq;

using System.Collections.Generic;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class CertificationsService : BaseService, ICertificationsRepository
    {
        public CertificationsService(Context context) : base(context) { }

        public void Delete(Certifications certifications)
        {
            context.Certifications.Remove(certifications);
        }

        public List<Certifications> GetAll()
        {
            return context.Certifications.ToList();
        }

        public Certifications GetById(string userId)
        {
            return context.Certifications.FirstOrDefault(p => p.Student == userId);
        }

        public void Insert(Certifications certifications)
        {
            context.Certifications.Add(certifications);
        }

        public void Update(Certifications certifications) { }
    }
}