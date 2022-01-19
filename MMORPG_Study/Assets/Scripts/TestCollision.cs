using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name} !");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger @ {other.gameObject.name} !");
    }

    void Update()
    {
        // Local <-> World <-> (Viewport, Screen(화면))
        //Debug.Log(Input.mousePosition); // Screen, 좌표 픽셀로 표시
        //Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition)); // Viewport, 좌표 비율로 표시
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }

        //if(Input.GetMouseButtonDown(0))
        //{       
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        //    Vector3 dir = mousePos - Camera.main.transform.position;
        //    dir = dir.normalized;

        //    Debug.DrawRay(Camera.main.transform.position, dir * 100f, Color.red, 1.0f);
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100f))
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //    }
        //}
    }
}
