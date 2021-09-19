using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace osuElements.Api.Throttling
{
    public class TimerThrottler: IThrottler
    {

        readonly SemaphoreSlim _waitSemaphore = new SemaphoreSlim(1, 1);

        readonly Timer _resetTimer;
        readonly TimeSpan _cooldown;
        private bool _disposedValue;

        public TimerThrottler(TimeSpan cooldown)
        {
            _cooldown = cooldown;
            _resetTimer = new Timer(_ => _waitSemaphore.Release(), null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
        }

        public TimerThrottler(int actions, TimeSpan perTime)
            : this(TimeSpan.FromMilliseconds(perTime.TotalMilliseconds / actions))
        {

        }



        public async Task WaitAsync()
        {
            await _waitSemaphore.WaitAsync();
            if (!_resetTimer.Change(_cooldown, Timeout.InfiniteTimeSpan))
                throw new Exception("Timer update error");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _resetTimer.Dispose();
                    _waitSemaphore.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
