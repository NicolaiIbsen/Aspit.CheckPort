using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Aspit.CheckPorts.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Aspit.Port;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Port2> getPorts()
        {
            List<Port2> brandList = new List<Port2>();
            SqlConnection connection = new SqlConnection(this.conString);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Port", connection);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Port2 brand = new Port2();
                brand.PortSpecifier = (string)sdr["PortSpecifier"];
                brand.PortNumber = (int)sdr["PortNumber"];
                brand.PortActivity = (bool)sdr["Activity"];

                brandList.Add(brand);
            }
            return brandList.ToList();
        }
        public List<Port2> DoWork()
        {
            Port2 port = new Port2();
            port.PortNumber = 1;
            port.PortSpecifier = "nice";

            List<Port2> list = new List<Port2>();
            list.Add(port);
            return list;
        }
    }
}
