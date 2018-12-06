using UnityEngine;

namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        private bool _isMoving = false;

        private GameObject _initialGameObject;
        private GameObject _fromGameObject;
        private GameObject _toGameObject;
        private float _slerpDeltaTime;


        void Start()
        {
            _initialGameObject = new GameObject();
            _fromGameObject = new GameObject();
            _toGameObject = new GameObject();
            _initialGameObject.transform.position = transform.position;
            _initialGameObject.transform.rotation = transform.rotation;
        }

        void Update()
        {
            if (_isMoving)
            {
                transform.rotation = Quaternion.Lerp(_fromGameObject.transform.rotation,
                    _toGameObject.transform.rotation, (Time.time - _slerpDeltaTime) * 1f);
                transform.position = Vector3.Lerp(_fromGameObject.transform.position, _toGameObject.transform.position,
                    (Time.time - _slerpDeltaTime) * 1f);
                if (transform == _toGameObject.transform)
                {
                    _isMoving = false;
                }
            }
        }


        public void GoTo(Vector3 position, Quaternion rotation)
        {
            _isMoving = true;
            _fromGameObject.transform.position = transform.position;
            _fromGameObject.transform.rotation = transform.rotation;
            _toGameObject.transform.position = position;
            _toGameObject.transform.rotation = rotation;
            _slerpDeltaTime = Time.time;
        }

        public void ResetCamera()
        {
            _isMoving = true;
            _fromGameObject.transform.position = transform.position;
            _fromGameObject.transform.rotation = transform.rotation;
            _toGameObject.transform.position = _initialGameObject.transform.position;
            _toGameObject.transform.rotation = _initialGameObject.transform.rotation;
            _slerpDeltaTime = Time.time;
        }
    }
}