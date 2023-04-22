using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public interface iEntRepository
    {
        
        IQueryable<Entertainers> Entertainers { get; }

        void SaveEntertainer(Entertainers record);
        void SaveChanges();
        void DeleteEntertainer(Entertainers record);
        long GetNextId();
    }

}

