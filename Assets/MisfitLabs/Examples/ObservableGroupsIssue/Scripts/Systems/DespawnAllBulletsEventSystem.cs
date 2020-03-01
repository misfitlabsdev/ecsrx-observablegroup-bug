using System.Linq;
using EcsRx.Collections;
using EcsRx.Events;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Plugins.ReactiveSystems.Custom;
using EcsRx.Plugins.Views.Components;
using MisfitLabs.Examples.ObservableGroupsIssue.Components;
using MisfitLabs.Examples.ObservableGroupsIssue.Events;

namespace MisfitLabs.Examples.ObservableGroupsIssue.Systems
{
    public class DespawnAllBulletsEventSystem : EventReactionSystem<DespawnAllBulletsEvent>
    {
        private readonly IEntityCollectionManager _entityCollectionManager;
        private readonly Group _group;
        private readonly IObservableGroup _observableGroup;

        public DespawnAllBulletsEventSystem(IEventSystem eventSystem,
            IEntityCollectionManager entityCollectionManager) : base(eventSystem)
        {
            _entityCollectionManager = entityCollectionManager;

            _group = new Group(typeof(BulletComponent), typeof(ViewComponent));
            _observableGroup = entityCollectionManager.GetObservableGroup(_group);
        }

        public override void EventTriggered(DespawnAllBulletsEvent eventData)
        {
            //DespawnUsingObservableGroup();
            DespawnUsingObservableGroupToArray();
            // DespawnUsingGetEntitiesFor();
        }

        private void DespawnUsingGetEntitiesFor()
        {
            var entities = _entityCollectionManager.GetEntitiesFor(_group).ToArray();
            for (var i = 0; i < entities.Length; i++)
            {
                _entityCollectionManager.RemoveEntity(entities[i]);
            }
        }

        private void DespawnUsingObservableGroup()
        {
            for (var i = 0; i < _observableGroup.Count; i++)
            {
                _entityCollectionManager.RemoveEntity(_observableGroup[i]);
            }
        }

        private void DespawnUsingObservableGroupToArray()
        {
            var entities = _observableGroup.ToArray();
            for (var i = 0; i < entities.Length; i++)
            {
                _entityCollectionManager.RemoveEntity(entities[i]);
            }
        }
    }
}
