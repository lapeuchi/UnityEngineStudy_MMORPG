using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float _speed = 10.0f;
    void Start()
    {
        
    }

    // GameObject (Player)
        // Transform
        // PlayerController (*)
    void Update()
    {
        // deltaTime: 지난 시간 프레임 이후 경과된 시간(설명 직역), 간단히 설명해 시간.

        //방향 * 시간 * 속력
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * _speed;
    }
}
