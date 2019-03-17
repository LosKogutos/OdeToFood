using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OdeToFood.Models
{
    public interface IOdeToFoodBase : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void SaveChanges();
    }


    public class OdeToFoodBase : DbContext, IOdeToFoodBase
    {
        public OdeToFoodBase() : base("name=DefaultConnection")
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> Reviews { get; set; }

        IQueryable<T> IOdeToFoodBase.Query<T>()
        {
            return Set<T>();
        }

        void IOdeToFoodBase.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IOdeToFoodBase.Update<T>(T entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        void IOdeToFoodBase.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void IOdeToFoodBase.SaveChanges()
        {
            SaveChanges();
        }
    }
}