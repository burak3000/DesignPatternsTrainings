using System;

namespace Patterns.Singleton
{
    public class SingletonLazy
    {
        private static Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() => new SingletonLazy());
        private int _instanceCount = 0;

        private static int _getInstanceCallCount = 0;

        public int InstanceCount => _instanceCount;
        private SingletonLazy()
        {
            _instanceCount++;
            Console.WriteLine($"New instance is created. Current instance count is {_instanceCount}");
        }

        public static SingletonLazy GetInstance()
        {
            Console.WriteLine($"GetInstance method is called({++_getInstanceCallCount} times)");
            return _instance.Value;
        }
    }
}
