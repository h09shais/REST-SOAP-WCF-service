using System;
using System.Runtime.Serialization;

namespace WcfServiceSoapAndRest
{
    [DataContract]
    public class AuthorizationResponse
    {
        [DataMember]
        public bool Valid { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public DateTime? ValidToDate { get; set; }

        [DataMember]
        public string ReturnUrl { get; set; }
    }
}