using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayHeight : MonoBehaviour
{
    private Ray ray;
    private RaycastHit[] rayHit;
    private float distance = 10.0f;

    public float heigtY
    {
        get; set;
    }
    public bool isRoad
    {
        get; set;
    }

    // Use this for initialization
    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        isRoad = false;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        RayHitRoad();
    }

    void RayHitRoad()
    {
        rayHit = Physics.RaycastAll(ray, distance);

        if (this.rayHit != null)
        {
            for (int i = 0; i < this.rayHit.Length; i++)
            {
                heigtY = rayHit[i].point.y;
                isRoad = true;
                if(isRoad) return;
                isRoad = false;
            }

        }
    }

    //OnDrawGizmos()에 기즈모 관련 추가하면 동작함
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f); 
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
    }
}
