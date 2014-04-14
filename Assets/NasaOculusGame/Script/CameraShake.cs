using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	
	void Update () 
    {
            float RandomX = Random.Range(0.03f, -0.03f);
            float RandomY = Random.Range(0.03f, -0.03f);
            float RandomZ = Random.Range(0.03f, -0.03f);

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.transform.position += new Vector3(RandomX, RandomY, RandomZ);
        }
	}
}
