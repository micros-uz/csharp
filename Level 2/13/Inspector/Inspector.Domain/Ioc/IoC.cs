using Inspector.Domain.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Inspector.Domain.Ioc
{
    public static class IoC
    {
        private static IDictionary<Type, Type> _dict = new Dictionary<Type, Type>();
        private static IDictionary<Type, object> _cache = new Dictionary<Type, object>();

        public static void Register<TIntf, TImpl>(IoCMode mode = IoCMode.None)
        {
            var intf = typeof(TIntf);
            var impl = typeof(TImpl);

            _dict[intf] = impl;

            if (mode == IoCMode.Singleton)
            {
                _cache[impl] = null;
            }
        }

        public static T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        public static object Get(Type type)
        {
            object res = null;

            if (_dict.ContainsKey(type))
            {
                var impl = _dict[type];

                if (_cache.ContainsKey(impl))
                {
                    var obj = _cache[impl];

                    if (obj != null)
                        res = obj;
                }

                return res != null ? res : CreateObject(impl);
            }

            throw new IoCException();
        }

        private static object CreateObject(Type impl)
        {
            object res = null;

            var ctors = impl.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (ctors.Any())
            {
                var ctor = ctors[0];
                var ctorParams = ctor.GetParameters();

                if (!ctorParams.Any())
                {
                    res = Activator.CreateInstance(impl);
                }
                else
                {
                    var paramObjects = new object[ctorParams.Length];

                    for (var k = 0; k < ctorParams.Length; k++)
                    {
                        var paramInfo = ctorParams[k];
                        var obj = Get(paramInfo.ParameterType);
                        paramObjects[k] = obj;
                    }

                    res = ctor.Invoke(paramObjects);
                }
            }

            if (_cache.ContainsKey(impl))
            {
                var obj = _cache[impl];

                if (obj == null)
                    _cache[impl] = res;
            }

            return res;
        }

        public static System.Reflection.BindingFlags BindingFlags { get; set; }
    }
}
