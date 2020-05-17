using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public interface IOregoAsyncSignInInteractor : IOregoInteractor
    {
        event Action<object, OregoSignInResult> OnSignInFinishedEvent;

        IEnumerator SignIn(object sender, OregoSignInParams signInParams, Reference<OregoSignInResult> resultRef);
    }
}