using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuriMorph : MonoBehaviour {

    MMD4MecanimMorphHelper morph;
    private float CountTime = 0.0f;
    private float StartTime = 0.0f;
	// Use this for initialization
	void Start () {
        morph = gameObject.GetComponent<MMD4MecanimMorphHelper>();
        morph.morphName = "まばたき"; //눈감기
        StartTime = Random.Range(0.0f, 5.0f);
    }
	
	// Update is called once per frame
	void Update () {
        CountTime += Time.deltaTime;
        if(CountTime > StartTime)
        {
            StartCoroutine("MorphUpdate");
        }
    }

    IEnumerator MorphUpdate()
    {
        morph.morphSpeed = 0.1f;
        morph.morphWeight = 0.7f;

        yield return new WaitForSeconds(0.1f);

        morph.morphSpeed = 0.1f;
        morph.morphWeight = 0.0f;
        CountTime = 0.0f;
        StartTime = Random.Range(0.0f, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Road")
        {
            transform.position = new Vector3(transform.position.x, other.transform.position.y, transform.position.z);
        }
    }
}
