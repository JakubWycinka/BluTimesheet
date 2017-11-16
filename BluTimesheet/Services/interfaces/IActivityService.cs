using BluTimesheet.Models.DbModels;
using System.Collections.Generic;

namespace BluTimesheet.Services.interfaces
{
    public interface IActivityService
    {
        void Add(Activity activity);
        void Remove(int id);
        Activity Get(int id);
        void Update(Activity activity);        
        void Approve(Activity activity);
        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetActivitesByUser(string id);
        IEnumerable<Activity> GetActivitesByProject(int id);
        IEnumerable<Activity> GetActivitesByActivityType(int id);
    }
}
