using Core.Game.Play.Configs;
using Core.UI.Elements;
using Cysharp.Threading.Tasks;
using Entitas;
using Entitas.Unity;
using Play.ECS;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class SpawnGuestsSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly LevelConfig _levelConfig;
        private readonly Transform _guestsRoot;

        private readonly IGroup<GameEntity> _group;
        private int _spawnedGuestsAmount;
        private float _timeToSpawn;

        public SpawnGuestsSystem(GameContext context, LevelConfig levelConfig, UIRoot uiRoot)
        {
            _context = context;
            _levelConfig = levelConfig;
            _guestsRoot = uiRoot.GuestsRoot;
            _group = _context.GetGroup(GameMatcher.PlayECSUnservedGuest);
            _group.OnEntityAdded += IncreaseSpawnedGuestsAmount;
            _group.OnEntityRemoved += DecreaseSpawnedGuestsAmount;
        }

        private void IncreaseSpawnedGuestsAmount(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            _spawnedGuestsAmount++;
        }

        private void DecreaseSpawnedGuestsAmount(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
        {
            _spawnedGuestsAmount--;
        }

        public void Execute()
        {
            if (_timeToSpawn > 0)
            {
                _timeToSpawn -= Time.deltaTime;
            }
            else
            {
                if (_spawnedGuestsAmount < _levelConfig.GuestsSpawnAmount)
                {
                    _timeToSpawn = _levelConfig.GuestsSpawnRate;

                    SpawnWalkingGuest().Forget();
                }
            }
        }

        private async UniTaskVoid SpawnWalkingGuest()
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(_levelConfig.GuestViewPrefab, _guestsRoot);
            await asyncOperationHandle;
            GameObject guestGO = asyncOperationHandle.Result;

            GuestViewBehaviour guestView = guestGO.GetComponent<GuestViewBehaviour>();
            guestView.Initialize(_context);

            SetInitialHorizontalPosition(guestGO.transform);
            MakeMoving(guestGO, guestView);
        }

        private void SetInitialHorizontalPosition(Transform transform)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(-1500, localPosition.y, localPosition.z);
            transform.localPosition = localPosition;
        }

        private void MakeMoving(GameObject guestGO, GuestViewBehaviour guestView)
        {
            guestView.SetState(GuestState.WalkIn);

            GameEntity guestEntity = (GameEntity) guestGO.GetEntityLink().entity;
            guestEntity.AddPlayECSStartHorizontalMovement(
                100, () =>
                {
                    guestEntity.AddPlayECSArrivedGuest(guestView);
                });
        }
    }
}