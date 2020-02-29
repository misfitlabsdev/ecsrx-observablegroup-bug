using EcsRx.Collections;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Plugins.ReactiveSystems.Custom;
using EcsRx.Plugins.Views.Components;
using MisfitLabs.Examples.ObservableGroupsIssue.Components;
using MisfitLabs.Examples.ObservableGroupsIssue.Events;

namespace MisfitLabs.Examples.ObservableGroupsIssue.Systems
{
    public class ShootBulletEventSystem : EventReactionSystem<ShootBulletEvent>
    {
        private readonly IEntityCollection _defaultCollection;

        public ShootBulletEventSystem(IEntityCollectionManager entityCollectionManager, IEventSystem eventSystem) :
            base(eventSystem)
        {
            _defaultCollection = entityCollectionManager.GetCollection();
        }

        public override void EventTriggered(ShootBulletEvent eventData)
        {
            var bulletEntity = _defaultCollection.CreateEntity();
            bulletEntity.AddComponent<BulletComponent>();
            bulletEntity.AddComponent<ViewComponent>();
        }
    }
}
