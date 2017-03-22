using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace RingkoebingSkjern.Models
{
    public class DependencyInjectionContainer
    {
        public DependencyInjectionContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ILoginRepository, LoginRepository>();
            var controller = container.Resolve<LoginService>();
        }
    }
}