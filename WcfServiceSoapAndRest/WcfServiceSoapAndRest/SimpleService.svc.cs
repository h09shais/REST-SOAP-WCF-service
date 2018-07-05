namespace WcfServiceSoapAndRest
{
    using System;
    using System.ServiceModel.Web;
    public class SimpleService : ISimpleService
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException(nameof(composite));
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public AuthorizationResponse Authenticate(AuthenticationRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (WebOperationContext.Current != null)
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.OK;

            AuthorizationResponse response;

            if (!string.IsNullOrEmpty(request.Username) && !string.IsNullOrEmpty(request.Password))
            {
                response = new AuthorizationResponse
                {
                    Valid = true,
                    ValidToDate = DateTime.Now.AddDays(1),
                    Message = "OK",
                    ReturnUrl = "http://test.test/"
                };
            }
            else
            {
                response = new AuthorizationResponse
                {
                    Valid = false,
                    ValidToDate = null,
                    Message = "Unable to authenticate",
                    ReturnUrl = string.Empty
                };
            }

            return response;
        }
    }
}
