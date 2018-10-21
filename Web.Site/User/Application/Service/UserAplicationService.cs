namespace Web.Site.User.Application.Service
{
    using Web.Site.User.Application.Assembler;
    using Web.Site.User.Domain.Entity;
    using System;
    using Web.Site.User.Application.Dto;
    using Web.Site.Common.Application.Notification;
    using Web.Site.Common.Infrastructure.Persistence;
    using Web.Site.User.Domain.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public class UserAplicationService: IUserAplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly UserCreateAssembler _userCreateAssembler;

        public UserAplicationService(IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            UserCreateAssembler userCreateAssembler)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userCreateAssembler = userCreateAssembler;

        }

        public List<UserOutputDto> GetAll()
        {
            var list = _userRepository.GetAll().ToList();
            var entities = _userCreateAssembler.FromEntityList(list);

            return entities;
        }

        public bool SignUp(UserCreateDto model)
        {

            Notification notification = ValidateModel(model);

            if (notification.HasErrors())
            {
                throw new ArgumentException(notification.ErrorMessage());
            }

            bool status = _unitOfWork.BeginTransaction();

            try
            {
                var  memberRole =  _roleRepository.GetByName(Roles.Member);

                if (memberRole == null)
                {
                    memberRole = new Role { Name = Roles.Member };

                    _roleRepository.Create(memberRole);
                }

                User user = _userCreateAssembler.ToUserEntity(model);
                user.Role = memberRole;
                _userRepository.Create(user);

                _unitOfWork.Commit(status);
            }
            catch(Exception ex)
            {
                _unitOfWork.Rollback(status);

                notification.AddError("there was error creating user");
                throw new ArgumentException(notification.ErrorMessage());

            }
            return true;

        }

        private Notification ValidateModel(UserCreateDto model)
        {
            Notification notification = new Notification();

            if (model == null)

            {
                notification.AddError("Invalid JSON data in request body");
                return notification;
            }

            if (string.IsNullOrEmpty(model.UserName))

            {
                notification.AddError("Please fill out the name");
                return notification;
            }

            if (string.IsNullOrEmpty(model.Password))

            {
                notification.AddError("Please fill out the password");
                return notification;
            }

            if (_userRepository.GetByName(model.UserName) != null)
            {
                notification.AddError("UserName already exists");
            }
            return notification;

        }
    }
}
