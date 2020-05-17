using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public interface IOregoAutoAsyncSignInInteractor : IOregoInteractor
    {
        event Action<object, OregoSignInResult> OnAutoSignInFinishedEvent;

        bool IsAutoSignInAvailable();

        IEnumerator AutoSignIn(object sender, Reference<OregoSignInResult> resultRef);
    }
}