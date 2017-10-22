using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain_Morph : MonoBehaviour {

    MMD4MecanimMorphHelper rainDown;

    private float StartTime;
    private float CountTime;

	// Use this for initialization
	void Start () {
        StartTime = Random.Range(2.0f, 6.0f);
        CountTime = 0.0f;
        rainDown = GetComponent<MMD4MecanimMorphHelper>();
        rainDown.name = "down";
    }
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;

        if(CountTime > StartTime) StartCoroutine("DownRain");
	}
    
    IEnumerator DownRain()
    {
        rainDown.morphSpeed = 2.0f;
        rainDown.morphWeight = 1.0f;

        yield return new WaitForSeconds(4.0f);

        rainDown.morphSpeed = 0.0f;
        rainDown.morphWeight = 0.0f;

        CountTime = 0.0f;
        StartTime = Random.Range(2.0f, 6.0f);
    }
}
