using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpConsoleClockObserver
{
    public delegate void OnHundredthsDelegate();
    public delegate void OnTenthsDelegate();
    public delegate void OnSecondsDelegate();
    public delegate void OnMinutesDelegate();
    public delegate void OnHoursDelegate();

    class Ticker
    {
        private bool done;
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        public event OnHundredthsDelegate OnHundredthsTick;
        public event OnTenthsDelegate OnTenthsTick;
        public event OnSecondsDelegate OnSecondsTick;
        public event OnMinutesDelegate OnMinutesTick;
        public event OnHoursDelegate OnHoursTick;

        private void NullHandler() { }

        public Ticker()
        {
            OnHundredthsTick += NullHandler;
            OnTenthsTick += NullHandler;
            OnSecondsTick += NullHandler;
            OnMinutesTick += NullHandler;
            OnHoursTick += NullHandler;
        }

        public void Run()
        {
            int count = 0;

            while (!done)
            {
                Interlocked.Increment(ref count);

                OnHundredthsTick();

                if (count % 10 == 0)
                    OnTenthsTick();

                if (count % 100 == 0)
                    OnSecondsTick();

                if (count % 6000 == 0)
                    OnMinutesTick();

                if (count % 36000 == 0)
                {
                    OnHoursTick();
                    count = 0;
                }
            }
        }
    }
}
