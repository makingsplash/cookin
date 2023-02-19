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

        private int _spawnedGuestsAmount;
        private float _timeToSpawn;

        public SpawnGuestsSystem(GameContext context, LevelConfig levelConfig, UIRoot uiRoot)
        {
            _context = context;
            _levelConfig = levelConfig;
            _guestsRoot = uiRoot.GuestsRoot;
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
                    _spawnedGuestsAmount++;

                    SpawnWalkingGuest().Forget();
                }
            }
        }

        private async UniTaskVoid SpawnWalkingGuest()
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(_levelConfig.GuestViewPrefab, _guestsRoot);
            await asyncOperationHandle;
            GameObject guestGO = asyncOperationHandle.Result;

            MakeWalking(guestGO);
        }

        private void MakeWalking(GameObject guestGO)
        {
            Vector3 startPos = new Vector3(-1500, -312, 0); // get from some SpawningPositions
            Vector3 endPos = new Vector3(100, -312, 0); // get from some WalkingToPositions
            int direction = startPos.x > 0 ? -1 : 1;
            float speed = 300f;                               // get from config
            float walkingTime = Mathf.Abs((endPos - startPos).x) / speed;

            GuestViewBehaviour viewBehaviour = guestGO.GetComponent<GuestViewBehaviour>();
            viewBehaviour.Initialize(_context);
            guestGO.GetComponent<RectTransform>().localPosition = startPos;
            viewBehaviour.SetState(GuestState.WalkIn);

            GameEntity guestEntity = (GameEntity) guestGO.GetEntityLink().entity;
            guestEntity.AddPlayECSWalkingGuest(viewBehaviour, direction, speed, walkingTime);
        }
    }
}