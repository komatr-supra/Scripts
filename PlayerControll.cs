using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [Range(0.01f,100f)]
    [SerializeField] float moveSpeedOfCamera = .01f;
    void Start()
    {
        
    }
    void Update()
    {
        //move left OR right
        if (Input.GetKey(KeyCode.A))
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z + moveSpeedOfCamera * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z - moveSpeedOfCamera * Time.deltaTime);
        }

        //move up OR down
        if (Input.GetKey(KeyCode.W))
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x + moveSpeedOfCamera * Time.deltaTime, myCamera.transform.position.y, myCamera.transform.position.z);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myCamera.transform.position = new Vector3(myCamera.transform.position.x - moveSpeedOfCamera * Time.deltaTime, myCamera.transform.position.y, myCamera.transform.position.z);
        }

    }
}
