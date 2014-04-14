using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LitJson;





public class MyJson : MonoBehaviour 
{
	string url=@"http://tsujimotter.info/api/SateliteTracker/orbitjsonp.cgi";
	string JsStr;
	List<string> lat;
	List<string> lng;
	List<string> alt;

	public SatPos satpos;
	int index=0;


	void Start()
	{
		StartCoroutine (GetJson ());
	}



	IEnumerator GetJson()
	{
		WWW www=new WWW(url);

		yield return www;



		JsStr = www.text.Remove (0, 6);
		JsStr = JsStr.Remove (JsStr.Length - 2);
		JsonData JsData = JsonMapper.ToObject (JsStr);
		lat = new List<string> (JsData ["orbits"].Count);
		lng = new List<string> (JsData ["orbits"].Count);
		alt = new List<string> (JsData ["orbits"].Count);

		Debug.Log ((string)JsData ["sateliteName"]);
		for (int i=0; i<JsData ["orbits"].Count; i++) 
		{
			lat.Add((string)JsData ["orbits"][i]["latitude"]);
			lng.Add((string)JsData ["orbits"][i]["longitude"]);
			alt.Add((string)JsData ["orbits"][i]["altitude"]);

		}
		Debug.Log ("Server Done!!!");
		StartCoroutine (RefreshPos ());


	}

	IEnumerator RefreshPos()
	{
		Debug.Log ("Done!!!");
		yield return new WaitForSeconds (12); 

		satpos.lat = float.Parse (lat [index]);
		satpos.lng = float.Parse (lng [index]);
		satpos.alt = float.Parse (alt [index]);

		satpos.Move ();
		index++;
		Debug.Log (alt [index]);
		StartCoroutine (RefreshPos ());

	}
}
