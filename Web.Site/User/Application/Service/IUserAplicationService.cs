namespace Web.Site.User.Application.Service
{
    using Web.Site.User.Application.Dto;

    public interface IAuthenticationAplicationService
    {
        bool SignUp(UserCreateDTO model);
    }
}
