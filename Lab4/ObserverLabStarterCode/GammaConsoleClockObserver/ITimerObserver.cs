using System;
using System.Collections.Generic;
using System.Text;

namespace GammaConsoleClockObserver
{
    interface ITimerObserver
    {
        void HundredthSecond();
        void TenthSecond();
        void Second();
        void Minute();
        void Hour();
    }
}
