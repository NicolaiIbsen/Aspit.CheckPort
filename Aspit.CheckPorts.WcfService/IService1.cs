using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Aspit.CheckPorts.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // Connectionstring

        [OperationContract]
        [WebGet(UriTemplate = "getPorts")]
        List<Port2> getPorts();

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DoWork/{doiso}")]
        List<Port2> DoWork();

    }

    [DataContract]
    public class Port2
    {
        string portSpecifier;
        int portNumber;
        bool portActivity;

        [DataMember]
        public string PortSpecifier { get => portSpecifier; set => portSpecifier = value; }
        [DataMember]
        public int PortNumber { get => portNumber; set => portNumber = value; }
        [DataMember]
        public bool PortActivity { get => portActivity; set => portActivity = value; }

    }
}
