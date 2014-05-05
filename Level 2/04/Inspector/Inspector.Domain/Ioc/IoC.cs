using Inspector.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Inspector.Domain.Ioc
{
    public static class IoC
    {
        private static IDictionary<Type, Type> _dict = new Dictionary<Type, Type>();

        public static void Register<TIntf, TImpl>()
        {
            var intf = typeof(TIntf);
            var impl = typeof(TImpl);

            _dict[intf] = impl;
        }

        public static T Get<T>()
        {
            if (_dict.ContainsKey(typeof(T)))
            {
                var type = _dict[typeof(T)];

                var res = Activator.CreateInstance(type);

                return (T)res;
            }

            throw new IoCException();
        }
    }
}
