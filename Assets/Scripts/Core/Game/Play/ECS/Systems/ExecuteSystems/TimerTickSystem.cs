using Entitas;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class TimerTickSystem : IExecuteSystem
    {
        private GameContext _gameContext;


        public TimerTickSystem(GameContext context)
        {
            _gameContext = context;
        }

        public void Execute()
        {
            var group = _gameContext.GetGroup(GameMatcher.PlayECSRunningTimer).GetEntities();

            foreach (var entity in group)
            {
                if (entity.isPlayECSFinishedTimer)
                {
                    continue;
                }

                var timer = entity.playECSRunningTimer;

                timer.CurrentTime += Time.deltaTime;

                if (timer.CurrentTime >= timer.MaxTime)
                {
                    entity.RemovePlayECSRunningTimer();
                    entity.isPlayECSFinishedTimer = true;
                }
            }
        }
    }
}