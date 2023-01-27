using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Extensions;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public class UserService : IUserService
    {
        public readonly IGiftFactory giftFactory;
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public IRepository<User> userRepository;
        public UserService(IGiftFactory _giftFactory, IMapper _mapper, IUnitOfWork _unitOfWork)
        {
            giftFactory = _giftFactory;
            mapper = _mapper;
            unitOfWork = _unitOfWork;
        }

        public async Task CreateAsync(UserBL userBL)
        {
            Validate(userBL);

            userRepository = unitOfWork.GetRepository<User>();
            var entity = await userRepository.GetOneAsync(x => x.Email == userBL.Email || x.Phone == userBL.Phone || (x.Name == userBL.Name && x.Address == userBL.Address));
            if (entity != null)
                throw new InvalidOperationException($"The User {userBL.Name} is alredy exist");

            var gift = giftFactory.Create(userBL.Type.ToLower());
            gift.ApplyToUser(userBL);

            var userEntity = mapper.Map<User>(userBL);
            try
            {
                await userRepository.InsertAsync(userEntity);

#warning "TXT MODE..."
                await userRepository.InsertTXTAsync(userEntity);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Validate(UserBL user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(UserBL));
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(string.Format(@"{0} -> {1}", nameof(UserBL), nameof(UserBL.Email)));
            if (!user.Email.IsMailAdress())
                throw new FormatException(string.Format(@"{0} -> {1}", nameof(UserBL), nameof(UserBL.Email)));
        }
    }
}
