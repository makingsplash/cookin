using System.Collections.Generic;
using Entitas;
using Play.ECS;
using UnityEngine;

namespace Core.Game.Play.ECS.Systems.ExecuteSystems
{
    public class WalkGuestSystem : IExecuteSystem
    {
        private readonly GameContext _context;
        private readonly IGroup<GameEntity> _group;
        readonly List<GameEntity> _buffer = new ();


        public WalkGuestSystem(GameContext context)
        {
            _context = context;
            _group = _context.GetGroup(GameMatcher.PlayECSWalkingGuest);
        }

        public void Execute()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                WalkingGuestComponent walkingGuest = e.playECSWalkingGuest;

                if (walkingGuest.WalkingTimeLeft > 0)
                {
                    walkingGuest.WalkingTimeLeft -= Time.deltaTime;

                    walkingGuest.View.transform.localPosition += new Vector3(walkingGuest.Direction * walkingGuest.Speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    e.AddPlayECSArrivedGuest(walkingGuest.View);
                }
            }
        }
    }
}