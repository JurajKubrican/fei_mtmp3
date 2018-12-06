using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraScript : MonoBehaviour
    {
        private GameObject _initialGameObject;
        private GameObject _fromGameObject;
        private GameObject _toGameObject;
        private GameObject _text;
        private float _slerpDeltaTime;
        private bool _hasMoved = false;


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
            if (_hasMoved)
            {
                transform.rotation = Quaternion.Lerp(_fromGameObject.transform.rotation,
                    _toGameObject.transform.rotation, (Time.time - _slerpDeltaTime) * 1f);
                transform.position = Vector3.Lerp(_fromGameObject.transform.position, _toGameObject.transform.position,
                    (Time.time - _slerpDeltaTime) * 1f);
            }
        }

        private void ShowText()
        {
            _text.SetActive(true);
        }


        public void GoTo(Vector3 position, Quaternion rotation, GameObject text)
        {
            _hasMoved = true;
            _fromGameObject.transform.position = transform.position;
            _fromGameObject.transform.rotation = transform.rotation;
            _toGameObject.transform.position = position;
            _toGameObject.transform.rotation = rotation;
            _slerpDeltaTime = Time.time;
            _text = text;
            Invoke("ShowText", 1f);
        }

        public void ResetCamera()
        {
            _fromGameObject.transform.position = transform.position;
            _fromGameObject.transform.rotation = transform.rotation;
            _toGameObject.transform.position = _initialGameObject.transform.position;
            _toGameObject.transform.rotation = _initialGameObject.transform.rotation;
            _slerpDeltaTime = Time.time;
        }
    }
}