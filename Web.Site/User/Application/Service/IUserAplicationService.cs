namespace Web.Site.User.Application.Service
{
    using System.Collections.Generic;
    using Web.Site.User.Application.Dto;

    public interface IUserAplicationService
    {
        List<UserOutputDto> GetAll();
        bool SignUp(UserCreateDto model);
    }
}
