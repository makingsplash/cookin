using UnityEngine;
using Zenject;

namespace Core.UI.Camera
{
    [DefaultExecutionOrder(-100)]
    public class UICamera : MonoBehaviour, IInitializable
    {
        public static int UI_PLANE_DISTANCE = 100;

        public UnityEngine.Camera Camera;

        private Vector2Int _resolution;

        public void Initialize()
        {
            _resolution = new Vector2Int(Screen.width, Screen.height);

            Resize();
        }

        private void Update()
        {
            if (_resolution.x != Screen.width || _resolution.y != Screen.height)
            {
                _resolution = new Vector2Int(Screen.width, Screen.height);

                Resize();
            }
        }

        private void Resize()
        {
            Camera.transform.position = new Vector3((float) _resolution.x / 2, (float) _resolution.y / 2);
            Camera.orthographicSize = (float) _resolution.y / 2;
        }
    }
}