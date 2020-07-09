using System;
using System.Collections.Generic;
using System.Linq;
using OregoFramework.Core;
using OregoFramework.Service;
using OregoFramework.Util;
using UnityEngine;

namespace OregoFramework.App
{
    //EXPERIMENTAL:
    public class ServiceApplication : Application
    {
        #region Const

        protected static readonly Type SERVICE_PARENT_TYPE = typeof(Service.Service);

        #endregion

        protected readonly Dictionary<Type, Service.Service> serviceMap;

        protected IEnumerable<Service.Service> services
        {
            get { return this.serviceMap.Values; }
        }

        protected GameObject unityServiceGameObject { get; private set; }

        public ServiceApplication()
        {
            this.serviceMap = new Dictionary<Type, Service.Service>();
        }

        #region OnCreate

        public override void OnCreate()
        {
            base.OnCreate();
            this.LoadServices();
        }

        protected void LoadServices()
        {
            this.unityServiceGameObject = new GameObject
            {
                name = "OregoUnityServiceGameObject",
                hideFlags = HideFlags.HideInHierarchy
            };

            var componentTypePool = Orego.GetObject<IElementTypePool>(
                nameof(IElementTypePool)
            );
            var allComponentTypes = componentTypePool.elementTypes;
            var serviceTypes = allComponentTypes.Where(serviceType => SERVICE_PARENT_TYPE
                .IsAssignableFrom(serviceType));
            foreach (var serviceType in serviceTypes)
            {
                var service = (Service.Service) this.unityServiceGameObject.AddComponent(
                    serviceType
                );
                service.OnCreate();
                this.serviceMap.AddByType(service);
            }
        }

        #endregion

        public override void OnPrepare()
        {
            base.OnPrepare();
            foreach (var service in this.services)
            {
                service.OnPrepare();
            }
        }

        public override void OnReady()
        {
            base.OnReady();
            foreach (var service in this.services)
            {
                service.OnReady();
            }
        }

        public override void OnStart()
        {
            base.OnStart();
            foreach (var service in this.services)
            {
                service.OnStart();
            }
        }

        public override void OnFinish()
        {
            base.OnFinish();
            foreach (var service in this.services)
            {
                service.OnFinish();
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameObject.Destroy(this.unityServiceGameObject.gameObject);
        }

        public T GetService<T>() where T : Service.Service
        {
            return this.serviceMap.Find<T, Service.Service>();
        }

        public IEnumerable<T> GetServices<T>() where T : Service.Service
        {
            return this.serviceMap.FindAll<T, Service.Service>();
        }
    }
}