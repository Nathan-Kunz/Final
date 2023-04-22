using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class efEntRepository:iEntRepository
    {
        private EntertainmentAgencyExampleContext context { get; set; }
        public efEntRepository(EntertainmentAgencyExampleContext temp)
        {
            context = temp;
        }
        public IQueryable<Entertainers> Entertainers => context.Entertainers;
        public long GetNextId()
        {
            long maxId = context.Entertainers.Max(e => (int?)e.EntertainerId) ?? 0;
            return maxId + 1;
        }
        public void SaveEntertainer(Entertainers entertainer)
        {
            if (entertainer.EntertainerId == 0)
            {
                long nextId = GetNextId();
                entertainer.EntertainerId = nextId;
                context.Entertainers.Add(entertainer);
            }
            else
            {
                // Update existing record
                Entertainers dbEntry = context.Entertainers.FirstOrDefault(e => e.EntertainerId == entertainer.EntertainerId);
                if (dbEntry != null)
                {
                    // Update fields
                    dbEntry.EntStageName = entertainer.EntStageName;
                    dbEntry.EntStreetAddress = entertainer.EntStreetAddress;
                    dbEntry.EntCity = entertainer.EntCity;
                    dbEntry.EntState = entertainer.EntState;
                    dbEntry.EntZipCode = entertainer.EntZipCode;
                    dbEntry.EntWebPage = entertainer.EntWebPage;
                    dbEntry.EntEmailAddress = entertainer.EntEmailAddress;
                    dbEntry.EntPhoneNumber = entertainer.EntPhoneNumber;
                }
            }
            context.SaveChanges();
        }

        public void DeleteEntertainer(Entertainers e)
        {
            context.Entertainers.Remove(e);
            context.SaveChanges();
        }


        public void SaveChanges()
        {
            context.SaveChanges();
        }

      




    }
}
