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

            LayerMask mask = LayerMask.GetMask("Monster") | LayerMask.GetMask("Wall");
           // int mask = (1 << 8) | (1 << 9); //Layers 번호에 따라 ( 1 << 레이어 번호 ) 쉬프트 연산.

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name} {hit.collider.gameObject.tag}");
            }
        }
    }
}
