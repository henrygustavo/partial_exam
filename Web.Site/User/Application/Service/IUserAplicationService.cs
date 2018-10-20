namespace Web.Site.User.Application.Service
{
    using Web.Site.User.Application.Dto;

    public interface IUserAplicationService
    {
        bool SignUp(UserCreateDTO model);
    }
}
