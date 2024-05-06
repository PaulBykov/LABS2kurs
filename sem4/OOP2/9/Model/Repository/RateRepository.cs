using _9.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace _9.Model.Repository
{
    public class RateRepository : IRateRepository
    {
        private readonly ClubContext context;

        public RateRepository(ClubContext context)
        {
            this.context = context;
        }

        public IEnumerable<Rate> GetAll()
        {
            return context.Rates.ToList();
        }

        public void Add(Rate rate)
        {
            context.Rates.Add(rate);
            context.SaveChanges();
        }

        public void Update(Rate rate)
        {
            context.Entry(rate).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Rate rate)
        {
            var existingRate = context.Rates.Find(rate.RateId);
            if (existingRate != null)
            {
                context.Rates.Remove(existingRate);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Rate not found");
            }
        }
    }
}
