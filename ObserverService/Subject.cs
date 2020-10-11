
using ObserverContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverService
{
    public abstract class Subject : ISubject

    {
        List<IObserver> _observers;
        public Subject()
        {
            _observers = new List<IObserver>();
        }
        public virtual void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public virtual void Dettach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public virtual void Notify(string data)
        {
            foreach (var o in _observers)
            {
                o.Update(data);
            }
        }
    }
}
