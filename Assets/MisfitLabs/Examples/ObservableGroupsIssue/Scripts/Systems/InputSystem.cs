using System;
using EcsRx.Events;
using EcsRx.Groups;
using EcsRx.Groups.Observable;
using EcsRx.Systems;
using MisfitLabs.Examples.ObservableGroupsIssue.Events;
using UniRx;
using UnityEngine;

namespace MisfitLabs.Examples.ObservableGroupsIssue.Systems
{
    public class InputSystem : IManualSystem
    {
        private readonly IEventSystem _eventSystem;

        private IDisposable _updateSubscription;

        public InputSystem(IEventSystem eventSystem)
        {
            _eventSystem = eventSystem;
        }

        public IGroup Group { get; } = new EmptyGroup();

        public void StartSystem(IObservableGroup observableGroup)
        {
            _updateSubscription = Observable.EveryUpdate().Subscribe(_ => ProcessInput());
        }

        public void StopSystem(IObservableGroup observableGroup)
        {
            _updateSubscription.Dispose();
        }

        private void ProcessInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _eventSystem.Publish(new ShootBulletEvent());
            }

            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                _eventSystem.Publish(new DespawnAllBulletsEvent());
            }
        }
    }
}
