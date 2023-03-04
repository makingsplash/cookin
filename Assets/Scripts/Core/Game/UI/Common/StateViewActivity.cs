using System.Collections.Generic;
using UnityEngine;

namespace Core.Game.UI.Common
{
    public class StateViewActivity : MonoBehaviour
    {
        [SerializeField]
        private List<string> _statesActive;

        public void OnStateChange(string state)
        {
            gameObject.SetActive(_statesActive.Contains(state));
        }
    }
}