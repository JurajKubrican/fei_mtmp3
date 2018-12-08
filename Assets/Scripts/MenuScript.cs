using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class MenuScript : MonoBehaviour
    {
        private PlatformScript _platform;
        private CameraScript _camera;
        public GameObject ModelHolder;

        private readonly Vector3[,] _positions = new Vector3[,]
        {
            {new Vector3(5, 3.5f, -1.5f), new Vector3(-1.8f, 2f, -2f)},
            {new Vector3(-2.7f, 3.3f, -2.7f), new Vector3(-1.6f, 3.1f, 4.7f)},
            {new Vector3(0, 3.8f, -2), new Vector3(0, 2.5f, -2)},
            {new Vector3(0f, 4.7f, -5.4f), new Vector3(6.5f, 5.5f, -1.6f)},

        };

        private readonly Quaternion[,] _rotations = new Quaternion[,]
        {
            {Quaternion.Euler(30, -80, 0), Quaternion.Euler(30, -300, 0)},
            {Quaternion.Euler(30, 51, 0), Quaternion.Euler(30, 157, 0)},
            {Quaternion.Euler(30, 0, 0), Quaternion.Euler(30, 0, 0)},
            {Quaternion.Euler(30, 0, 0), Quaternion.Euler(30, -80, 0)},

        };

        // Use this for initialization
        private void Start()
        {
            _platform = GameObject.Find("Platform").GetComponent<PlatformScript>();
            _camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();
            SetModel(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("r"))
            {
                ToggleRotate();
            }
            else if (Input.GetKeyDown("q"))
            {
                SetViewpoint(0);
            }
            else if (Input.GetKeyDown("w"))
            {
                SetViewpoint(1);
            }
            else if (Input.GetKeyDown("1"))
            {
                SetModel(0);
                ToggleRotate(true);
            }
            else if (Input.GetKeyDown("2"))
            {
                SetModel(1);
                ToggleRotate(true);
            }
            else if (Input.GetKeyDown("3"))
            {
                SetModel(2);
                ToggleRotate(true);
            }
            else if (Input.GetKeyDown("4"))
            {
                SetModel(3);
                ToggleRotate(true);
            }
        }


        public void ToggleRotate()
        {
            ClearTexts();

            _camera.ResetCamera();
            _platform.IsRotating = !_platform.IsRotating;
        }

        public void ToggleRotate(bool rotate)
        {
            ClearTexts();

            _camera.ResetCamera();
            _platform.IsRotating = rotate;
        }

        public void SetViewpoint(int point)
        {
            _platform.resetPosition();
            var texts = ClearTexts();
            var i = _platform.ModelIndex;
            _camera.GoTo(_positions[i, point], _rotations[i, point], texts[point]);
        }


        public void SetModel(int index)
        {
            _platform.SetObject(index);

            var btn1 = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            btn1.SetText(ModelHolder.transform.GetChild(index).GetChild(1).GetChild(0).name + " (q)");

            var btn2 = this.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            btn2.SetText(ModelHolder.transform.GetChild(index).GetChild(1).GetChild(1).name + " (w)");
            ToggleRotate(true);
        }

        private GameObject[] ClearTexts()
        {
            var texts = _platform.GetTexts();
            foreach (var child in texts)
            {
                child.SetActive(false);
            }

            return texts;
        }
    }
}