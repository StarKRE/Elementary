using OregoFramework.Tool;

namespace OregoFramework.Db
{
    public abstract class OregoEncryptablePrefsDao<T> : OregoPrefsDao<T>
    {
        protected virtual string hash { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();
            this.hash = this.GetType().Name;
        }

        protected override string SerializeEntity(T entity)
        {
            var serializedEntity = base.SerializeEntity(entity);
            var encryptedEntity = Security.Encrypt(serializedEntity, this.hash);
            return encryptedEntity;
        }

        protected override T DeserializeEntity(string stringData)
        {
            var decryptedEntity = Security.Decrypt(stringData, this.hash);
            var deserializedEntity = base.DeserializeEntity(decryptedEntity);
            return deserializedEntity;
        }
    }
}