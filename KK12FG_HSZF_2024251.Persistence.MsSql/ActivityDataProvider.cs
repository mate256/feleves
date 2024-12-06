using KK12FG_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Persistence.MsSql
{
    public interface IActivityDataProvider
    {
        public IEnumerable<Activity> GetActivity();
        public void AddActivity(Activity activity);
        public void UpdateActivity(Activity activity);
        public void RemoveActivity(Activity activity);
    }
    public class ActivityDataProvider : IActivityDataProvider
    {
        private readonly PetRegistrationDbContext ctx;
        public ActivityDataProvider(PetRegistrationDbContext context)
        {
            ctx = context;
        }

        public void AddActivity(Activity activity)
        {
            ctx.Activities.Add(activity);
            ctx.SaveChanges();
        }

        public IEnumerable<Activity> GetActivity()
        {
            return ctx.Activities.Include(a => a.Animal).ToHashSet();
        }

        public void RemoveActivity(Activity activity)
        {
            ctx.Remove(activity);
            ctx.SaveChanges();
        }

        public void UpdateActivity(Activity activity)
        {
            var activityToUpdate = ctx.Activities.First(t => t.ActivityId == activity.ActivityId);
            activityToUpdate.Date = activity.Date;
            activityToUpdate.Description = activity.Description;
            ctx.Activities.Update(activityToUpdate);
            ctx.SaveChanges();
        }
    }
}
