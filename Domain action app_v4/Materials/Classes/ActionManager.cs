using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_action_app_v4.Materials.Classes
{
    public class ActionManager
    {
        public static ObservableCollection<Groups> GetGroups()
        {
            var groups = new ObservableCollection<Groups>();

            groups.Add(new Groups { GroupName = "TestFirst" });
            groups.Add(new Groups { GroupName = "TestSecond" });

            return groups;
        }
    }
}
