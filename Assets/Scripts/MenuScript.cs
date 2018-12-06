using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private PlatformScript _platform;
    private CameraScript _camera;


    private readonly Vector3[] _positions = new Vector3[1];
    private readonly Quaternion[] _rotations = new Quaternion[1];

    // Use this for initialization
    void Start()
    {
        _platform = GameObject.Find("Platform").GetComponent<PlatformScript>();
        _camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();

        _positions[0] = new Vector3(7, 5, -2);
        _rotations[0] = Quaternion.Euler(30, -80, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void toggleRotate()
    {
        _camera.ResetCamera();
        _platform.IsRotating = !_platform.IsRotating;
    }

    public void setViewpoint(int point)
    {
        _platform.resetPosition();
        _camera.GoTo(_positions[point],_rotations[point]);
    }


    
}