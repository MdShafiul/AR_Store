using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_with_camera : MonoBehaviour
{

    public Camera base_camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + base_camera.transform.rotation * Vector3.back, base_camera.transform.rotation * Vector3.up);
    }
}
