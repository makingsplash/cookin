using System;
using System.Collections.Generic;
using Core.UI.Elements;
using UnityEngine;

namespace Core.Game.Play.UI
{
    public class PlayUIRoot : UIRoot
    {
        [SerializeField]
        private Transform _guestSpawnPoint;

        public Transform GuestsRoot;
        public List<GuestSeat> GuestsSeats;

        public Vector3 GuestSpawnPoint => _guestSpawnPoint.localPosition;
    }

    [Serializable]
    public class GuestSeat
    {
        [SerializeField]
        private Transform _transform;

        public bool Available = true;
        public Vector3 Position => _transform.localPosition;
    }
}