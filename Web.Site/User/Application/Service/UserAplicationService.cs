namespace Web.Site.User.Application.Service
{
    using Web.Site.User.Application.Assembler;
    using Web.Site.User.Domain.Entity;
    using System;
    using Web.Site.User.Application.Dto;
    using Web.Site.Common.Application.Notification;
    using Web.Site.Common.Infrastructure.Persistence;
    using Web.Site.User.Domain.Repository;
    public class UserAplicationService: IAuthenticationAplicationService
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

        public bool SignUp(UserCreateDTO model)
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
                _roleRepository.Create(memberRole);

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

        private Notification ValidateModel(UserCreateDTO model)
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
            return notification;

        }
    }
}
