using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop_Police_Line_Sc : MonoBehaviour {

    private Material thisMaretial;
    
    private float Offset;
    public float ScrollSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {
        thisMaretial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Offset += ScrollSpeed * Time.deltaTime;

        thisMaretial.mainTextureOffset = new Vector2(Offset, 0);
    }
}
