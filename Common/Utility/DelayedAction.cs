using System;
using System.Collections.Generic;
using System.Threading;

namespace Common.Utility
{
    public class DelayedAction
    {
        
        protected static List<DelayedAction> ActionList = new List<DelayedAction>();

        public static void CheckActions()
        {
            for (int i = 0; i < ActionList.Count; i++)
            {
                try
                {
                    ActionList[i].Check();
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch
                // ReSharper restore EmptyGeneralCatchClause
                {
                    //Collection modified
                }

                if ((i & 511) == 0) // 2^N - 1
                    Thread.Sleep(1);
            }
        }

        protected Action Action;

        protected long InvokeUtc;

        public DelayedAction(Action action, int delay)
        {
            Action = action;
            InvokeUtc = TimeHelper.GetCurrentMilliseconds() + delay;

            ActionList.Add(this);
        }

        public void Abort()
        {
            ActionList.Remove(this);
        }

        protected void Check()
        {
            if (TimeHelper.GetCurrentMilliseconds() < InvokeUtc)
                return;
            try
            {
                Action.Invoke();
            }
            catch (Exception exeption)
            {
                throw exeption;
            }
            finally
            {
                Abort();
            }
        }
    }
}
