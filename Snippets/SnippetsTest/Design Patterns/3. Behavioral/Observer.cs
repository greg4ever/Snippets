using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTmp._3._Behavioral
{
    interface IObserver
    {
        void Update();
    }
    
    class Observer : IObserver
    {
        public void Update() { }
    }

    interface IObservable
    {
        void AddObserver(IObserver observer);
        void Notify();
    }

    class Observable
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(x => x.Update());
        }
    }
}
