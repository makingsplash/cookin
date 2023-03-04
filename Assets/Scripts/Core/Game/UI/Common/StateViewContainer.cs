using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.UI.Common
{
    public class StateViewContainer : MonoBehaviour
    {
        [SerializeField]
        private List<StateViewActivity> _views;

        [SerializeField]
        private string _state = string.Empty;

        public string State
        {
            get => _state;
            set
            {
                _state = value;

                NotifyViews();
            }
        }

        private void Awake()
        {
            NotifyViews();
        }

        private void NotifyViews()
        {
            foreach (StateViewActivity view in _views)
            {
                if (view == null) continue;
                view.OnStateChange(_state);
            }
        }
    }
}