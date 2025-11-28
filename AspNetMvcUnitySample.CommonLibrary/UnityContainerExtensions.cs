using System;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Lifetime;

namespace AspNetMvcUnitySample.CommonLibrary
{
    /// <summary>
    /// UnityContainerの拡張メソッド
    /// </summary>
    public static class UnityContainerExtensions
    {
        /// <summary>
        /// <see cref="RegisterDependencyAttribute"/>が付与されているクラスをDIコンテナに登録する
        /// </summary>
        /// <param name="container">UnityContainer</param>
        /// <param name="assembly">アセンブリ</param>
        /// <returns>UnityContainer</returns>
        public static IUnityContainer RegisterByAttribute(this IUnityContainer container, Assembly assembly)
        {
            // アセンブリ内の抽象クラスでないクラスを抽出
            var implementationTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);

            foreach (var type in implementationTypes)
            {
                // クラスにカスタム属性がある場合、クラス自身を登録
                var classAttr = type.GetCustomAttribute<RegisterDependencyAttribute>();
                if (classAttr != null)
                {
                    var lifetime = CreateLifetimeManager(classAttr.LifetimeManagerType);
                    container.RegisterType(type, type, lifetime);
                }

                // 実装しているインターフェースにカスタム属性がある場合、インターフェースとこのクラスを紐付けて登録
                var interfaces = type.GetInterfaces();
                foreach (var i in interfaces)
                {
                    var interfaceAttr = i.GetCustomAttribute<RegisterDependencyAttribute>();
                    if (interfaceAttr != null)
                    {
                        var lifetime = CreateLifetimeManager(interfaceAttr.LifetimeManagerType);
                        container.RegisterType(i, type, lifetime);
                    }
                }
            }

            return container;
        }

        /// <summary>
        /// <see cref="ITypeLifetimeManager"/>を作成する
        /// </summary>
        /// <param name="type">ITypeLifetimeManagerの派生クラス</param>
        /// <returns><see cref="ITypeLifetimeManager"/></returns>
        private static ITypeLifetimeManager CreateLifetimeManager(Type type)
        {
            if (type == null)
            {
                return null;
            }
            return (ITypeLifetimeManager)Activator.CreateInstance(type);
        }
    }
}
