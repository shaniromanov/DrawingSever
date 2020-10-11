using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverContracts
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Dettach(IObserver observer);
        void Notify(string data);

    }
}
