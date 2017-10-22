using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDropBackground : MonoBehaviour {

    public GameObject Rain01 = null;
    public GameObject Rain02 = null;

    private float CountTime = 0.0f;
    private float StartTime = 0.8f;

    // Use this for initialization
    void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;

        if (CountTime > StartTime)
        {
            Instantiate(Rain01.gameObject, this.gameObject.transform.position, 
                                            this.gameObject.transform.rotation);

            Instantiate(Rain02.gameObject, this.gameObject.transform.position,
                                            this.gameObject.transform.rotation);

            CountTime = 0.0f;
        }
	}
}
