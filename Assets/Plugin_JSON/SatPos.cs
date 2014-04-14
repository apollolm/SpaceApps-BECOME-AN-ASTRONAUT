using UnityEngine;
using System.Collections;

public class SatPos : MonoBehaviour {

	public GameObject Sat;
	public GameObject SatChild;

	public float lat;
	public float lng;
	public float alt;

	public const float EarthRadius=27.53f * 6.35f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	public void Move () 
	{


        Sat.transform.rotation = Quaternion.Euler(27.53f * lat, 27.53f * lng, 0);
        SatChild.transform.localPosition = new Vector3(0, 0, EarthRadius + 27.53f * alt / 1000);
		Debug.Log (alt);

	}
}
