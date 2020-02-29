using EcsRx.Infrastructure.Dependencies;
using EcsRx.Infrastructure.Extensions;
using EcsRx.Zenject;
using UnityEngine;

namespace MisfitLabs.Examples.ObservableGroupsIssue
{
    public class Application : EcsRxApplicationBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;

        protected override void LoadModules()
        {
            base.LoadModules();

            Container.Bind<GameObject>(new BindingConfiguration {ToInstance = _bulletPrefab});
        }

        protected override void ApplicationStarted()
        {
        }
    }
}
