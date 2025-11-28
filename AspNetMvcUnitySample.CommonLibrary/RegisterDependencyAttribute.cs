using System;
using Unity.Lifetime;

namespace AspNetMvcUnitySample.CommonLibrary
{
    /// <summary>
    /// クラスをDIコンテナに登録するための属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false)]
    public class RegisterDependencyAttribute : Attribute
    {
        /// <summary>
        /// <see cref="ITypeLifetimeManager"/>の派生クラス
        /// </summary>  
        /// <value><see cref="ITypeLifetimeManager"/>の派生クラス</value>
        public Type LifetimeManagerType { get; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="lifetimeManagerType"><see cref="ITypeLifetimeManager"/>の派生クラス</param>
        public RegisterDependencyAttribute(Type lifetimeManagerType = null)
        {
            LifetimeManagerType = lifetimeManagerType;
        }
    }
}
