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
            routine.Start(enumerator);
            yield return new WaitWhile(routine.IsWorking);
        }

        public static IEnumerator ForceJoin(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            yield return routine.ForceJoin(enumerator);
        }

        public static IEnumerator ForceJoin(this Routine routine, IEnumerator enumerator)
        {
            routine.ForceStart(enumerator);
            yield return new WaitWhile(routine.IsWorking);
        }

        #endregion
        
        #region Start

        public static void Start(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func.Invoke();
            routine.Start(enumerator);
        }

        public static void ForceStart(this Routine routine, Func<IEnumerator> func)
        {
            var enumerator = func?.Invoke();
            routine.ForceStart(enumerator);
        }

        public static void ForceStart(this Routine routine, IEnumerator enumerator)
        {
            if (routine.IsWorking())
            {
                routine.Cancel();
            }

            routine.Start(enumerator);
        }

        #endregion
    }
}