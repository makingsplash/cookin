using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace Core.Game.Play.ECS.Systems
{
    public class SystemsExecutor : IInitializable, ITickable, IDisposable
    {
        private readonly Contexts _contexts;
        private readonly Feature _mainSystems;

        private bool _isPaused;


        public SystemsExecutor(Contexts contexts, List<ISystem> systems)
        {
            _contexts = contexts;

            _mainSystems = new Feature("Main Systems");

            foreach (var system in systems)
            {
                _mainSystems.Add(system);
            }
        }

        public void Initialize()
        {
            _mainSystems.Initialize();
        }

        public void Tick()
        {
            if (_isPaused)
                return;

            _mainSystems.Execute();
            _mainSystems.Cleanup();
        }

        public void Pause(bool isPaused)
        {
            _isPaused = isPaused;
        }

        public void Reset()
        {
            Pause(true);

            _mainSystems.DeactivateReactiveSystems();
            _mainSystems.ClearReactiveSystems();

            try
            {
                foreach (var context in _contexts.allContexts)
                {
                    context.DestroyAllEntities();
                    context.ResetCreationIndex();
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }

            _mainSystems.ActivateReactiveSystems();
            Initialize();

            Pause(false);
        }

        public void Dispose()
        {
            _mainSystems.DeactivateReactiveSystems();
            _mainSystems.ClearReactiveSystems();
            _contexts.Reset();
        }
    }
}