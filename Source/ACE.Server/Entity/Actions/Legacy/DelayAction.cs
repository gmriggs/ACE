using System;

namespace ACE.Server.Entity.Actions.Legacy
{
    /// <summary>
    /// Action that will not return until Timer.PortalYearTicks >= EndTime
    /// must only be inserted into DelayManager actor
    /// </summary>
    public class DelayAction : ActionEventBase, IComparable<DelayAction>
    {
        public double WaitTime { get; }
        public double EndTime { get; private set; }

        // For breaking ties on compareto, two actions cannot be equal
        private readonly long sequence;
        private static volatile uint glblSequence;

        public DelayAction(double waitTimePortalYearTicks)
        {
            WaitTime = waitTimePortalYearTicks;
            sequence = glblSequence++;
        }

        public void Start()
        {
            EndTime = Timers.PortalYearTicks + WaitTime;
        }

        public int CompareTo(DelayAction rhs)
        {
            int ret = EndTime.CompareTo(rhs.EndTime);

            if (ret == 0)
                return sequence.CompareTo(rhs.sequence);

            return ret;
        }
    }
}
