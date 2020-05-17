using System;
using System.Collections;
using OregoFramework.Util;

namespace OregoFramework.Domain
{
    public abstract class OregoAutoSaveAsyncSignInInteractor : OregoInteractor, IOregoAutoAsyncSignInInteractor
    {
        #region Event

        public event Action<object, OregoSignInResult> OnAutoSignInFinishedEvent;

        #endregion

        private IOregoAsyncSignInInteractor signInInteractor;

        public override void OnPrepare()
        {
            base.OnPrepare();
            this.signInInteractor = this.GetInteractor<IOregoAsyncSignInInteractor>();
        }

        #region AutoSignInEnabled

        public bool IsAutoSignInAvailable()
        {
            return this.HasSavedSignInParams();
        }

        protected abstract bool HasSavedSignInParams();

        #endregion

        #region AutoSignIn

        public IEnumerator AutoSignIn(object sender, Reference<OregoSignInResult> resultRef)
        {
            if (!this.HasSavedSignInParams())
            {
                throw new Exception("Saved sign in params is absent!");
            }

            var savedSignInParams = this.LoadSavedSignInParams();
            yield return this.signInInteractor.SignIn(sender, savedSignInParams, resultRef);
            var result = resultRef.value;
            this.SaveNewSignInParams(result);
            yield return this.OnAutoSignInFinished(result);
            this.NotifyAboutAutoSignInFinished(sender, result);
        }

        protected abstract OregoSignInParams LoadSavedSignInParams();

        protected abstract void SaveNewSignInParams(OregoSignInResult result);

        protected virtual IEnumerator OnAutoSignInFinished(OregoSignInResult result)
        {
            yield break;
        }

        protected void NotifyAboutAutoSignInFinished(object sender, OregoSignInResult result)
        {
            this.OnAutoSignInFinishedEvent?.Invoke(sender, result);
        }

        #endregion
    }
}