﻿using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Core.Extensions;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Services;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Data.Repositories;
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

        public async Task CreateAsync(UserShared userShared)
        {
            Validate(userShared);

            var userBL = mapper.Map<UserBL>(userShared);

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

        private void Validate(UserShared user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(UserShared));
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(string.Format(@"{0} -> {1}", nameof(UserShared), nameof(UserShared.Email)));
            if (!user.Email.IsMailAdress())
                throw new FormatException(string.Format(@"{0} -> {1}", nameof(UserShared), nameof(UserShared.Email)));
        }
    }
}
