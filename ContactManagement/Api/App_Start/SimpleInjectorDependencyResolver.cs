using System.Web.Mvc;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace ContactsPrjApi
{
    public class SimpleInjectorDependencyResolver : System.Web.Mvc.IDependencyResolver,
             System.Web.Http.Dependencies.IDependencyResolver,
             System.Web.Http.Dependencies.IDependencyScope
    {
        public SimpleInjectorDependencyResolver(Container container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this.Container = container;
        }
        public Container Container { get; private set; }
        public object GetService(Type serviceType)
        {
            if (!serviceType.IsAbstract && typeof(IController).IsAssignableFrom(serviceType))
                return this.Container.GetInstance(serviceType);
            return ((IServiceProvider)this.Container).GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.Container.GetAllInstances(serviceType);
        }
        IDependencyScope System.Web.Http.Dependencies.IDependencyResolver.BeginScope()
        {
            return this;
        }
        object IDependencyScope.GetService(Type serviceType)
        {
            return ((IServiceProvider)this.Container)
                .GetService(serviceType);
        }
        IEnumerable<object> IDependencyScope.GetServices(Type serviceType)
        {
            IServiceProvider provider = Container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        void IDisposable.Dispose() { }

    }
}