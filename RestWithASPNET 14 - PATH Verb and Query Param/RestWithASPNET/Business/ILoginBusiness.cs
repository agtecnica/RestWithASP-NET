using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;

namespace RestWithASPNET.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}
