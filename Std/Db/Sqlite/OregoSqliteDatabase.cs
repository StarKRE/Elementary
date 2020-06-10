#if SQL

using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;

#pragma warning disable 618

namespace OregoFramework.Db
{
    public abstract class OregoSqliteDatabase : OregoDatabase<OregoSqliteDao>
    {
        public DbConnection connection { get; private set; }

        protected string connectionUri { get; private set; }

        protected string dataPath { get; private set; }

        protected RuntimePlatform platform { get; private set; }

        protected string persistentDataPath { get; private set; }

        protected abstract string databaseName { get; }

        public bool isInitialized { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();
            this.dataPath = UnityEngine.Application.dataPath;
            this.platform = UnityEngine.Application.platform;
            this.persistentDataPath = UnityEngine.Application.persistentDataPath;
        }

        #region Init

        public void Initialize()
        {
            string databasePath;
            if (platform == RuntimePlatform.Android)
            {
                this.InitAsAndroid(out databasePath);
            }
            else
            {
                this.InitAsEditor(out databasePath);
            }

            this.connectionUri = $"URI=file:{databasePath}";
            this.isInitialized = true;
        }

        private void InitAsAndroid(out string databasePath)
        {
            databasePath = $"{this.persistentDataPath}/{this.databaseName}";
            if (!File.Exists(databasePath))
            {
                var load = new WWW($"jar:file://{this.dataPath}!/assets/{this.databaseName}");
                while (!load.isDone)
                {
                }

                File.WriteAllBytes(databasePath, load.bytes);
            }
        }

        private void InitAsEditor(out string databasePath)
        {
            databasePath = $"{this.dataPath}/StreamingAssets/{this.databaseName}";
        }

        #endregion

        #region Connect

        public IEnumerator Connect()
        {
            if (!this.isInitialized)
            {
                throw new Exception("Database is not initialized! " +
                                    "Did you forget to call OregoSqliteDatabase.Initialize()");
            }

            this.connection = new SqliteConnection(this.connectionUri);
            this.connection.Open();
            if (this.connection.State != ConnectionState.Open)
            {
                throw new Exception("Can not connect to db!");
            }

            yield return this.OnConnect();
            foreach (var sqlDao in this.allComponents)
            {
                yield return sqlDao.OnConnect();
            }
        }

        protected virtual IEnumerator OnConnect()
        {
            yield break;
        }

        #endregion

        public void Disconnect()
        {
            this.connection.Close();
            this.connection.Dispose();
        }
    }
}

#endif