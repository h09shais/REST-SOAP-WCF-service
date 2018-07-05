using System.Runtime.Serialization;

namespace WcfServiceSoapAndRest
{
    [DataContract]
    public class AuthenticationRequest
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}