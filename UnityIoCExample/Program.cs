using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityIoCExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // initilize the Unity IoC container
            UnityContainer container = new UnityContainer();
            // load IoC configuration from App.Config
            container.LoadConfiguration();
            // resolve a dependent class
            Dependent dependency = container.Resolve<Dependent>();

            dependency.DoSomething();
            Console.ReadLine();
        }
    }

    public class Dependent
    {
        private IDependency _dependency;

        public Dependent(IDependency dependency)
        {
            _dependency = dependency;
        }
        public void DoSomething()
        {
            _dependency.DoSomeWork();
        }
    }

    public interface IDependency
    {
        void DoSomeWork();
    }

    public class DependencyOne : IDependency
    {
        public void DoSomeWork()
        {
            Console.WriteLine("DependencyOne doing work");
        }
    }

    public class DependencyTwo : IDependency
    {
        public void DoSomeWork()
        {
            Console.WriteLine("DependencyTwo doing some work");
        }
    }
}
