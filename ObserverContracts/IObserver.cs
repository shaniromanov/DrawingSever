using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverContracts
{
    public interface IObserver
    {
        void Update(string data);
    }
}
