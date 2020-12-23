using UnityEngine;


namespace Labirint
{
    public sealed class MiniMap : MonoBehaviour
    {
        private Transform _player;
        private void Start()
        {
            _player = Camera.main.transform ;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position;
            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            GetComponent<Camera>().targetTexture = rt;
        }
        private void LateUpdate()
        {
            var newPosition = _player.position + new Vector3(0.0f, 0.0f, 6.0f);;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }
}

