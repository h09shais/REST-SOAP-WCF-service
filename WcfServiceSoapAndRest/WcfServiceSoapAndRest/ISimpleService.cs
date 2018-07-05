namespace WcfServiceSoapAndRest
{
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebInvoke(
            Method = "PUT",
            ResponseFormat = WebMessageFormat.Json, 
            RequestFormat = WebMessageFormat.Json, 
            UriTemplate = "AuthReq")]
        AuthorizationResponse Authenticate(AuthenticationRequest request);
    }
}
