using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using System;
using System.Collections.Generic;

namespace Sat.Recruitment.Business.Concrete
{
    public class GiftFactory : IGiftFactory
    {
        public readonly Dictionary<string, Func<IGift>> _factories;

        public GiftFactory(Dictionary<string, Func<IGift>> factories)
        {
            _factories = factories;
        }

        public IGift Create(string type)
        {
            if (!_factories.TryGetValue(type, out var factory) || factory is null)
                throw new ArgumentOutOfRangeException(nameof(type), $"Type '{type}' is not registered");
            return factory();
        }
    }
}
