using System;
using System.Collections;
using UnityEngine;

namespace OregoFramework.Util
{
    public static class RoutineExtensions
    {
        #region Join

        public static IEnumerator Join(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            yield return routine.Join(enumerator);
        }

        public static IEnumerator Join(this Routine routine, IEnumerator enumerator)
        {
            routine.Run(enumerator);
            yield return new WaitWhile(routine.IsRunning);
        }

        public static IEnumerator TryJoin(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            yield return routine.TryJoin(enumerator);
        }

        public static IEnumerator TryJoin(this Routine routine, IEnumerator enumerator)
        {
            if (routine.IsRunning())
            {
                yield break;
            }

            yield return routine.Join(enumerator);
        }

        public static IEnumerator ForceJoin(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            yield return routine.ForceJoin(enumerator);
        }

        public static IEnumerator ForceJoin(this Routine routine, IEnumerator enumerator)
        {
            routine.ForceRun(enumerator);
            yield return new WaitWhile(routine.IsRunning);
        }

        #endregion

        #region Run

        public static void Run(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            routine.Run(enumerator);
        }

        public static void TryRun(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            routine.TryRun(enumerator);
        }

        public static void TryRun(this Routine routine, IEnumerator enumerator)
        {
            if (routine.IsRunning())
            {
                return;
            }

            routine.Run(enumerator);
        }

        public static void ForceRun(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func?.Invoke();
            routine.ForceRun(enumerator);
        }

        public static void ForceRun(this Routine routine, IEnumerator enumerator)
        {
            if (routine.IsRunning())
            {
                routine.Cancel();
            }

            routine.Run(enumerator);
        }

        #endregion
    }
}