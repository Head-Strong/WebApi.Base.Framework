namespace WebApi.Controller.Interface
{
    public interface ICredentialController
    {
        string Get(string username, string password);

        string Get(string credential);
    }
}
