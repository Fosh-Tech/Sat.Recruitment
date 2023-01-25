using Sat.Recruitment.Business.Interfaces;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Business.Concrete
{
    public class DIFriendlyUserFactory : IUserFactory
    {
        private readonly Dictionary<string, Func<IUser>> _factories;

        public DIFriendlyUserFactory(Dictionary<string, Func<IUser>> factories)
        {
            _factories = factories;
        }

        public IUser Create(string type)
        {
            if (!_factories.TryGetValue(type, out var factory) || factory is null)
                throw new ArgumentOutOfRangeException(nameof(type), $"Type '{type}' is not registered");
            return factory();
        }
    }
}