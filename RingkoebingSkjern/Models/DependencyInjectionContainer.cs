using Microsoft.Practices.Unity;

namespace RingkoebingSkjern.Models
{
    public class DependencyInjectionContainer
    {
        public static void RegisterElements(IUnityContainer container)
        {
            container.RegisterType<ILoginRepository, LoginRepository>();
        }
    }
}