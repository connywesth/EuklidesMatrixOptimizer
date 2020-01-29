using System;
using System.Collections.Generic;
using System.Text;

namespace EuklidesMatrixOptimizer_ClassLibraryNETStandard
{
    public class CallCounter
    {
        private DateTime BeginTimer { get; set; }
        private DateTime EndTimer { get; set; }
        private int Counter { get; set; }
        public CallCounter()
        {
            Reset();
        }

        public void Reset()
        {
            this.Counter = 0;
            this.BeginTimer = DateTime.Now;
            this.EndTimer = DateTime.Now;
        }

        public double ElapsedTime()
        {
            this.EndTimer = DateTime.Now;
            TimeSpan timeDiff = this.EndTimer - this.BeginTimer;
            return timeDiff.TotalMilliseconds;
        }

        public double AverageTime()
        {
            return ElapsedTime() / this.Counter;
        }

        public void IncreaseOne()
        {
            this.Counter++;
        }

        public void DecreaseOne()
        {
            this.Counter--;
        }

        public int GetValue()
        {
            return this.Counter;
        }

        public override string ToString()
        {
            return $"{Counter} ({ElapsedTime()} ms) Avg: {AverageTime()} ms/call";
        }
    }
}
