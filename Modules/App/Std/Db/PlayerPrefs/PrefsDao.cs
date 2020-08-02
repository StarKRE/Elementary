using UnityEngine;

namespace ElementaryFramework.App
{
    public abstract class PrefsDao<T> : Dao<PrefsDatabase>, IPrefsDao
    {
        protected string daoKey { get; }

        protected PrefsDao()
        {
            var className = this.GetType().Name;
            this.daoKey = className;
        }

        protected T GetEntity(string key)
        {
            var fullKey = this.GetFullKey(key);
            var stringData = PlayerPrefs.GetString(fullKey);
            return this.DeserializeEntity(stringData);
        }

        protected virtual T DeserializeEntity(string stringData)
        {
            return JsonUtility.FromJson<T>(stringData);
        }

        protected bool HasEntity(string key)
        {
            var fullKey = this.GetFullKey(key);
            return PlayerPrefs.HasKey(fullKey);
        }

        protected void SetEntity(string key, T entity)
        {
            var stringData = this.SerializeEntity(entity);
            var fullKey = this.GetFullKey(key);
            PlayerPrefs.SetString(fullKey, stringData);
        }

        protected virtual string SerializeEntity(T entity)
        {
            return JsonUtility.ToJson(entity);
        }

        protected virtual string GetFullKey(string key)
        {
            return $"{this.daoKey}/{key}";
        }
    }
}