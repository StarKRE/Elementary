using System.Collections;
using UnityEngine;

namespace ElementaryFramework.Util
{
    public static class ParticleSystemUtils
    {
        public static IEnumerator PlayOneShot(this ParticleSystem particleSystem)
        {
            particleSystem.Play();
            yield return new WaitForSeconds(particleSystem.main.duration);
            particleSystem.Stop();
        }
    }
}