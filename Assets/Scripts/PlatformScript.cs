using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformScript : MonoBehaviour
    {
        public bool IsRotating = true;

        private bool _isResetting = false;

        public GameObject ModelHolder;
        public int ModelIndex = 0;

        private Quaternion _from;
        private Quaternion _to;
        private Quaternion _initialQuaternion;
        private float _slerpDeltaTime;
        private GameObject _spinningGameObject;


        // Use this for initialization
        void Start()
        {
            _initialQuaternion = transform.rotation;
  
        }

        // Update is called once per frame
        void Update()
        {
            if (IsRotating)
            {
                transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
            }

            if (_isResetting)
            {
                transform.rotation = Quaternion.Lerp(_from, _to, (Time.time - _slerpDeltaTime) * 1f);
                if (transform.rotation == _to)
                {
                    _isResetting = false;
                }
            }
        }


        public void resetPosition()
        {
            IsRotating = false;
            _isResetting = true;
            _slerpDeltaTime = Time.time;
            _from = transform.rotation;
            _to = _initialQuaternion;
        }

        public void SetObject(int index)
        {
            Destroy(_spinningGameObject);
            ModelIndex = index;
            _spinningGameObject = Instantiate(ModelHolder.transform.GetChild(ModelIndex), transform.position,
                Quaternion.identity).gameObject;
            _spinningGameObject.transform.parent = transform;
        }

        public GameObject[] GetTexts()
        {
            return new[]
            {
                _spinningGameObject.transform.GetChild(1).GetChild(0).gameObject,
                _spinningGameObject.transform.GetChild(1).GetChild(1).gameObject
            };
        }
    }
}