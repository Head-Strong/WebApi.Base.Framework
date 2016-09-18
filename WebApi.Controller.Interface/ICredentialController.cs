namespace WebApi.Controller.Interface
{
    public interface ICredentialController
    {
        string EncodedCredentials(string username, string password);

        string DecodeCredentials(string credential);       
    }
}
