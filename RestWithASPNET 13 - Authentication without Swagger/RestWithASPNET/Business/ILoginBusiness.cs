using RestWithASPNET.Model;

namespace RestWithASPNET.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
