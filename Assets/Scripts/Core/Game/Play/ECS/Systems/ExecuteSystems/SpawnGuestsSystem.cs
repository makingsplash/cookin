    using System.Collections.Generic;
using System.Linq;
using Core.Game.Play.Configs;
using Core.Game.Play.UI;
using Cysharp.Threading.Tasks;
using Entitas;
using Play.ECS;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class SpawnGuestsSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly LevelConfig _levelConfig;
        private readonly PlayUIRoot _playUIRoot;
        private readonly Transform _guestsRoot;
        private readonly LevelDishes _levelDishes;

        private float _timeToSpawn;


        public SpawnGuestsSystem(GameContext context, LevelConfig levelConfig, PlayUIRoot playUIRoot, LevelDishes levelDishes)
        {
            _context = context;
            _levelConfig = levelConfig;
            _levelDishes = levelDishes;
            _playUIRoot = playUIRoot;
            _guestsRoot = playUIRoot.GuestsRoot;
        }

        public void Execute()
        {
            if (_levelDishes.DishesToAssign.Any() && _playUIRoot.GuestsSeats.Any(seat => seat.Available))
            {
                if (_timeToSpawn > 0)
                {
                    _timeToSpawn -= Time.deltaTime;
                }
                else
                {
                    _timeToSpawn = _levelConfig.GuestsSpawnRate;

                    SpawnGuest().Forget();
                }
            }
        }

        private async UniTaskVoid SpawnGuest()
        {
            var asyncOperationHandle = Addressables.InstantiateAsync(_levelConfig.GuestViewPrefab, _guestsRoot);
            await asyncOperationHandle;
            GameObject guestGO = asyncOperationHandle.Result;

            GuestViewBehaviour guestView = guestGO.GetComponent<GuestViewBehaviour>();
            guestView.Initialize(_context);

            SetInitialHorizontalPosition(guestGO.transform);
        }

        private void SetInitialHorizontalPosition(Transform transform)
        {
            var localPosition = transform.localPosition;
            localPosition = new Vector3(_playUIRoot.GuestSpawnPoint.x, localPosition.y, localPosition.z);
            transform.localPosition = localPosition;
        }
    }
}