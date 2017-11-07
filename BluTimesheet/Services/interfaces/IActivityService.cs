using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IEnumerable<Activity> GetActivitesByUser(int id);
        IEnumerable<Activity> GetActivitesByProject(int id);
        IEnumerable<Activity> GetActivitesByActivityType(int id);

        //int SumOfHoursSpentOnProject(int id);
        //IDictionary<User,int> SumOfHoursSpentOnProjectPerUser(int id);
    }
}
