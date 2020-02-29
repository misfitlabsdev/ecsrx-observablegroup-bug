using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Plugins.Views.Components;
using EcsRx.Unity.Dependencies;
using EcsRx.Unity.Systems;
using MisfitLabs.Examples.ObservableGroupsIssue.Components;
using UnityEngine;

namespace MisfitLabs.Examples.ObservableGroupsIssue.ViewResolvers
{
    public class BulletViewResolver : DynamicViewResolverSystem
    {
        private readonly GameObject _bulletPrefab;

        public BulletViewResolver(IEventSystem eventSystem,
            IEntityCollectionManager collectionManager,
            IUnityInstantiator instantiator,
            GameObject bulletPrefab) : base(eventSystem, collectionManager, instantiator)
        {
            _bulletPrefab = bulletPrefab;
        }

        public override IGroup Group { get; } = new Group(typeof(BulletComponent), typeof(ViewComponent));

        public override GameObject CreateView(IEntity entity)
        {
            var gameObject = Object.Instantiate(_bulletPrefab, Vector3.zero, Quaternion.identity);
            gameObject.name = $"bullet-{entity.Id}";

            var rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = Vector2.up;

            return gameObject;
        }

        public override void DestroyView(IEntity entity, GameObject view)
        {
            Object.Destroy(view);
        }
    }
}
