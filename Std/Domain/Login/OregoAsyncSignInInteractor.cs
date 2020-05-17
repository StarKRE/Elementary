using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoAsyncSignInInteractor : OregoInteractor, IOregoAsyncSignInInteractor
    {
        public abstract event Action<object, OregoSignInResult> OnSignInFinishedEvent;

        public abstract IEnumerator SignIn(
            object sender,
            OregoSignInParams signInParams,
            Reference<OregoSignInResult> resultRef
        );
    }
}