using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpConsoleClockObserver
{
    class SecondClock : Clock, IDisposable
    {
        private readonly Ticker _ticker;
        private bool _disposed;

        public SecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            _ticker = ticker;
            _ticker.OnSecondsTick += Second;
        }

        private void Second()
        {
            DateTime dt = DateTime.Now;
            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _ticker.OnSecondsTick -= Second;
            _disposed = true;
        }
    }

    class HundredthSecondClock : Clock, IDisposable
    {
        private readonly Ticker _ticker;
        private bool _disposed;

        public HundredthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            _ticker = ticker;
            _ticker.OnHundredthsTick += HundredthSecond;
        }

        private void HundredthSecond()
        {
            DateTime dt = DateTime.Now;
            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 10, 9, 0, 2);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _ticker.OnHundredthsTick -= HundredthSecond;
            _disposed = true;
        }
    }

    class TenthSecondClock : Clock, IDisposable
    {
        private readonly Ticker _ticker;
        private bool _disposed;

        public TenthSecondClock(int originalColumn, int originalRow, ConsoleColor? color, Ticker ticker)
            : base(originalColumn, originalRow, color)
        {
            _ticker = ticker;
            _ticker.OnTenthsTick += TenthSecond;
        }

        private void TenthSecond()
        {
            DateTime dt = DateTime.Now;
            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 100, 9, 0, 1);
        }

        public void Dispose()
        {
            if (_disposed) return;
            _ticker.OnTenthsTick -= TenthSecond;
            _disposed = true;
        }
    }
}
