namespace Web.Site.User.Application.Assembler
{
    using AutoMapper;
    using Web.Site.User.Application.Dto;
    using Web.Site.User.Domain.Entity;
    public class UserCreateAssembler
    {
        private readonly IMapper _mapper;

        public UserCreateAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }


        public User ToUserEntity(UserCreateDTO model)
        {
            return _mapper.Map<User>(model);
        }
    }
}
