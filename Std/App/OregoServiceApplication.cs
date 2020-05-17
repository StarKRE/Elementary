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
    public class OregoServiceApplication : OregoApplication
    {
        #region Const

        protected static readonly Type SERVICE_PARENT_TYPE = typeof(OregoServiceComponent);

        #endregion

        protected readonly Dictionary<Type, OregoServiceComponent> serviceMap;

        protected IEnumerable<OregoServiceComponent> services
        {
            get { return this.serviceMap.Values; }
        }

        protected GameObject unityServiceGameObject { get; private set; }

        public OregoServiceApplication()
        {
            this.serviceMap = new Dictionary<Type, OregoServiceComponent>();
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

            var componentTypePool = Orego.GetObject<IOregoComponentTypePool>(
                nameof(IOregoComponentTypePool)
            );
            var allComponentTypes = componentTypePool.componentTypes;
            var serviceTypes = allComponentTypes.Where(serviceType => SERVICE_PARENT_TYPE
                .IsAssignableFrom(serviceType));
            foreach (var serviceType in serviceTypes)
            {
                var service = (OregoServiceComponent) this.unityServiceGameObject.AddComponent(
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

        public override void OnStop()
        {
            base.OnStop();
            foreach (var service in this.services)
            {
                service.OnStop();
            }
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameObject.Destroy(this.unityServiceGameObject.gameObject);
        }

        public T GetService<T>() where T : OregoServiceComponent
        {
            return this.serviceMap.Find<T, OregoServiceComponent>();
        }

        public IEnumerable<T> GetServices<T>() where T : OregoServiceComponent
        {
            return this.serviceMap.FindAll<T, OregoServiceComponent>();
        }
    }
}