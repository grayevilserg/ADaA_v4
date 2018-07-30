using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain_action_app_v4.Materials.Classes;
using System.IO;
using System.Collections;

namespace Domain_action_app_v4.Materials.Classes
{
    public class ActionManager
    {
        private static string[] User_propertys = 
            { "givenName", "sn", "userPrincipalName", "mail", "whenCreated", "lockoutTime" };
        public static string LDAP_connection = "emea.roche.com";
        public static string LDAP_path = "LDAP://OU=Users,OU=IT,OU=Moscow,OU=AdminUnits,DC=emea,DC=roche,DC=com";

        public static DirectoryEntry createDirectoryEntry()
        {
            // create ldap parametres
            DirectoryEntry ldapconnection = new DirectoryEntry(LDAP_connection);
            ldapconnection.Path = LDAP_path;
            ldapconnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapconnection;
        }

        // check of existence of the user in AD
        public static bool Exists(string username) 
        {
            bool found = false;
            DirectoryEntry myconnection = createDirectoryEntry();
            string SearchFilter = string.Format("(&((&(objectCategory=Person)(objectClass=User)))(userPrincipalName={0}",
                username);
            DirectorySearcher searchname = new DirectorySearcher(myconnection, SearchFilter);
            searchname.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            searchname.PropertyNamesOnly = true;

            // get result values 
            SearchResult mysearchnameresult = searchname.FindOne();
            if (mysearchnameresult.Properties.Values.Equals(username))
            {
                found = true;
            }
            searchname.Dispose();
            return found;
        }

        public static ObservableCollection<User> GetUserInfo(bool found, string username)
        {
            ObservableCollection<User> arrayresult = new ObservableCollection<User>();
            bool foundname = Exists(username);
            //pull request to domain controller
            if (foundname == true)
            {
                DirectoryEntry myldapconnection = createDirectoryEntry();
                string SearchFilter = string.Format("(&((&(objectCategory=Person)(objectClass=User)))(userPrincipalName={0}",
                    username);
                DirectorySearcher search = new DirectorySearcher(myldapconnection, SearchFilter, User_propertys);
                search.SearchScope = System.DirectoryServices.SearchScope.Subtree;

                // get result values 
                SearchResultCollection mysearchresult = search.FindAll();
                
                if (mysearchresult != null)
                {
                    foreach (SearchResult searchresult in mysearchresult)
                    {
                        var entry = searchresult.GetDirectoryEntry();
                        arrayresult.Add( new User
                        {
                          UserName = entry.Properties["userPrincipalName"].Value.ToString(),
                          FirstName = entry.Properties["givenName"].Value.ToString(),
                          LastName = entry.Properties["sn"].Value.ToString(),
                          Email = entry.Properties["mail"].Value.ToString(),
                          CreationDate = entry.Properties["whenCreated"].Value.ToString(),
                          AccountStatus = entry.Properties["lockoutTime"].Value.ToString(),
                        });
                        entry.Close();
                        entry.Dispose();
                    }
                }
                search.Dispose();
            }
            return arrayresult;
        }

        public static ObservableCollection<Groups> GetGroups()
        {
            var groups = new ObservableCollection<Groups>();

            groups.Add(new Groups { GroupName = "TestFirst" });
            groups.Add(new Groups { GroupName = "TestSecond" });

            return groups;
        }
    }
}
