namespace MathLib
{
    public class SlowMath
    {
        public SlowMath()
        {
            Console.WriteLine("Slow!");
        }
        public int Square(int d)
        {
            Thread.Sleep(4000);
            return d * d;
        }

        public int SquareRoot(int d)
        {
            Thread.Sleep(4000);
            return (int)Math.Sqrt(d);
        }

        public IAsyncResult BeginSquare(int d, AsyncCallback callback, object state)
        {
            var ao = new Administratie<int>(() => Square(d), callback, state);
            ao.Start();
            return ao;
        }
        public int EndSquare(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.WaitOne();
            return (ar as Administratie<int>).Result;
        }

        public Task<int> SquareAsync(int d)
        {
            return Task.Run(() => Square(d));
        }

        public IAsyncResult BeginSquareRoot(int d, AsyncCallback callback, object state)
        {
            var ao = new Administratie<int>(() => SquareRoot(d), callback, state);
            ao.Start();
            return ao;
        }
        public double EndSquareRoot(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.WaitOne();
            return (ar as Administratie<double>).Result;
        }

        private class Administratie<T> : IAsyncResult
        {
            private readonly Func<T> _function;
            private readonly AsyncCallback _callback;
            public object AsyncState { get; }

            private readonly AutoResetEvent _waitHandle;
            public WaitHandle AsyncWaitHandle => _waitHandle;
            public bool IsCompleted { get; private set; }
            public bool CompletedSynchronously => IsCompleted;
            public T Result { get; private set; }

            public Administratie(Func<T> function, AsyncCallback callback, object state)
            {
                _function = function;
                _callback = callback;
                _waitHandle = new AutoResetEvent(false);
                IsCompleted = false;
                AsyncState = state;
            }

            public void Start()
            {
                ThreadPool.QueueUserWorkItem(DoWork);
            }
            private void DoWork(object dummy)
            {
                Result = _function();
                IsCompleted = true;
                _waitHandle.Set();
                _callback?.Invoke(this);
            }
        }
    }
}