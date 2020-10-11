
using ObserverContracts;
using System;

namespace ObserverService
{
    abstract public class Observer : IObserver
    {
        protected ISubject _subject;
        public Observer(ISubject subject)
        {
            _subject = subject;
        }
        abstract public void Update(string data);

    }
}
