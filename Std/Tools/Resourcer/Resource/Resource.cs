using System;
using OregoFramework.Core;

namespace OregoFramework.Tool
{
    /**
     * Keep a info about resource.
     */

    public abstract class Resource : Element, IResource
    {
        #region Const

        protected const string RESOURCE_WORD = "Resource";

        protected const int FIRST_INDEX = 0;

        #endregion

        public virtual string path
        {
            get { return this.GetDefaultResourceName(); }
        }

        private string defaultName;

        protected virtual string GetDefaultResourceName()
        {
            if (this.defaultName != null)
            {
                return this.defaultName;
            }

            var clazzName = this.GetType().Name;
            if (clazzName.StartsWith(RESOURCE_WORD))
            {
                this.defaultName = clazzName.Substring(FIRST_INDEX + RESOURCE_WORD.Length, clazzName.Length);
                return this.defaultName;
            }

            if (clazzName.EndsWith(RESOURCE_WORD))
            {
                this.defaultName = clazzName.Substring(FIRST_INDEX, clazzName.Length - RESOURCE_WORD.Length);
                return this.defaultName;
            }

            throw new Exception("The prefab name " + clazzName + " doesn't start/end with "
                                + RESOURCE_WORD + "!" +
                                " Please, rename prefab or override property \'path\'!");
        }
    }
}