using NUnit.Framework;
using Patterns.Singleton;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    public class SingletonLazyTest
    {

        [TestCase(10000)]
        public void GetInstance_MultipleCalls_InstanceCountMustBeOne(int threadCount)
        {
            Thread[] getInstanceThreads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                getInstanceThreads[i] = new Thread(() => { SingletonLazy.GetInstance(); });
            }

            Parallel.ForEach(getInstanceThreads, currentThread => currentThread.Start());
            SingletonLazy singletonInstance = SingletonLazy.GetInstance();

            Assert.AreEqual(1, singletonInstance.InstanceCount);
        }

    }
}