using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Exceptions;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Extensions;
using System;
using System.Linq.Expressions;
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

        public async Task<User> CreateAsync(UserBL userBL)
        {
            userRepository = unitOfWork.GetRepository<User>();

            await ValidateDuplicate(userBL);

            var gift = giftFactory.Create(userBL.Type.ToLower());
            gift.ApplyToUser(userBL);

            var userDAL = mapper.Map<User>(userBL);
            try
            {
                var newUserDAL = await userRepository.InsertAsync(userDAL);
#warning "TXT MODE..."
                await userRepository.InsertTXTAsync(userDAL);

                return newUserDAL;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task ValidateDuplicate(UserBL userBL)
        {
            var entity = await userRepository.GetOneAsync(x => x.Email == userBL.Email || x.Phone == userBL.Phone || (x.Name == userBL.Name && x.Address == userBL.Address));
            if (entity != null)
                throw new DuplicateEntityException($"The User {entity.Name} is already exist.");
        }
    }
}
