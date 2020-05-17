using UnityEngine;

namespace OregoFramework.Util
{
    public abstract class ScriptableProduct : AutoScriptableObject, IProduct
    {
        public abstract string id { get; }
        
        [SerializeField]
        protected string m_titleCode;

        [SerializeField]
        protected string m_descCode;

        [SerializeField]
        protected Sprite m_iconSprite;

        public virtual Sprite iconSprite
        {
            get { return this.m_iconSprite; }
        }

        public virtual string titleCode
        {
            get { return this.m_titleCode; }
        }

        public virtual string descriptionCode
        {
            get { return this.m_descCode; }
        }
    }
}