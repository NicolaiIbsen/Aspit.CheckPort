using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Aspit.CheckPorts.Entities;
using Newtonsoft.Json.Linq;

namespace Aspit.CheckPorts.DataAccess
{
    public class MockDataProvider
    {
        /// <summary>The url</summary>
        private string url = "https://randomuser.me/api/?results=";

        /// <summary>
        /// Gets user data from API
        /// </summary>
        /// <param name="amount">The amount of users you want</param>
        /// <returns>List<Person> filled with all the data from the API</returns>
        public List<Port> GetPeople(int amount)
        {
            List<Port> persons = new List<Port>();
            WebClient wc = new WebClient();
            string respone = wc.DownloadString(url + amount);
            JObject jsonRespone = JObject.Parse(respone);

            for (int i = 0; i < amount; i++)
            {
                JObject name = (JObject)jsonRespone["results"][i]["name"];
                JToken firstname = name["first"];
                JToken titleOfCourtesy = name["title"];
                persons.Add(new Port(firstname.ToString(), (int)2, titleOfCourtesy.HasValues));
            }
            return persons;
        }
    }
}
