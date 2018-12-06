using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Assets.Scripts;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    private PlatformScript _platform;
    private CameraScript _camera;


    private readonly Vector3[] _positions = new Vector3[2];
    private readonly Quaternion[] _rotations = new Quaternion[2];
    public GameObject[] Texts;

    // Use this for initialization
    void Start()
    {
        _platform = GameObject.Find("Platform").GetComponent<PlatformScript>();
        _camera = GameObject.Find("Main Camera").GetComponent<CameraScript>();

        _positions[0] = new Vector3(7, 5, -2);
        _rotations[0] = Quaternion.Euler(30, -80, 0);
        _positions[1] = new Vector3(-2.4f, 1.9f, -4.0f);
        _rotations[1] = Quaternion.Euler(30, -300, 0);

        foreach (GameObject child in Texts)
        {
            child.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            toggleRotate();
        }
        else if (Input.GetKeyDown("1"))
        {
            setViewpoint(0);
        }
        else if (Input.GetKeyDown("2"))
        {
            setViewpoint(1);
        }
    }


    public void toggleRotate()
    {
        foreach (GameObject child in Texts)
        {
            child.SetActive(false);
        }
        _camera.ResetCamera();
        _platform.IsRotating = !_platform.IsRotating;
    }

    public void setViewpoint(int point)
    {
        _platform.resetPosition();
        foreach (GameObject child in Texts)
        {
            child.SetActive(false);
        }

        _camera.GoTo(_positions[point], _rotations[point], Texts[point]);
    }
}