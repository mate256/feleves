using KK12FG_HSZF_2024251.Model;
using KK12FG_HSZF_2024251.Persistence.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK12FG_HSZF_2024251.Application
{
    public interface IActivityService
    {
        IEnumerable<Activity> GetActivity();
        void AddActivity(Activity activity);
        void UpdateActivity(Activity activity, int Id);
        void RemoveActivity(string AnimalID);

        void AddMultipleActivity(IEnumerable<Activity> activities);
    }
    public class ActivityService : IActivityService
    {
        private readonly IActivityDataProvider activityDataProvider;
        public ActivityService(IActivityDataProvider activityDataProvider)
        {
            this.activityDataProvider = activityDataProvider;
        }

        public void AddActivity(Activity newActivity)
        {
            var activity = activityDataProvider.GetActivity().FirstOrDefault(t => t.Type == newActivity.Type);
            if (activity == null)
            {
                activityDataProvider.AddActivity(newActivity);
            }
            
        }

        public void AddMultipleActivity(IEnumerable<Activity> activities)
        {
            foreach (var item in activities)
            {
                activityDataProvider.AddActivity(item);
            }
        }

        public IEnumerable<Activity> GetActivity()
        {
            return activityDataProvider.GetActivity();
        }

        public void RemoveActivity(string AnimalID)
        {
            throw new NotImplementedException();
        }

        public void UpdateActivity(Activity activity, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
