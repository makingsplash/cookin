using Entitas;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class TimerTickSystem : IExecuteSystem
    {
        private GameContext _gameContext;

        public TimerTickSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Execute()
        {
            var group = _gameContext.GetGroup(GameMatcher.PlayECSTimerView);

            foreach (var entity in group)
            {
                var timer = entity.playECSTimerView;

                if (timer.Finished)
                {
                    entity.playECSTimerView.CurrentTime += Time.deltaTime;

                    if (timer.CurrentTime >= timer.MaxTime)
                    {
                        timer.Finished = false;

                        Debug.Log("Timer finished");
                    }
                }
            }
        }
    }
}