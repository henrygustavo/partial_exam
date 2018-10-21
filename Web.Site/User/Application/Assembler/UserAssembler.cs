namespace Web.Site.User.Application.Assembler
{
    using AutoMapper;
    using System.Collections.Generic;
    using Web.Site.User.Application.Dto;
    using Web.Site.User.Domain.Entity;
    public class UserCreateAssembler
    {
        private readonly IMapper _mapper;

        public UserCreateAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }


        public User ToUserEntity(UserCreateDto model)
        {
            return _mapper.Map<User>(model);
        }

        public List<UserOutputDto> FromEntityList(List<User> modelList)
        {
            return _mapper.Map<List<UserOutputDto>>(modelList);
        }
    }
}
