using UnityEngine;
using System.Collections;


public class get : MonoBehaviour
{
	// Use this for initialization
	string Url;
	void Start()
	{
		Url = "http://192.168.2.16:8080/getDatos";
		Debug.Log (Url);
		GetData();
	}

	// Update is called once per frame
	void Update()
	{

	}
	//Invoke this function where to want to make request.
	void GetData()
	{
		//sending the request to url
		WWW www = new WWW(Url);
		Debug.Log (www.error);

		StartCoroutine("GetdataEnumerator", www );
	}
	IEnumerator GetdataEnumerator(WWW www)
	{
		//Wait for request to complete

		yield return www;

		if (www.error == null)
		{
			
			string serviceData = www.text;
			//Data is in json format, we need to parse the Json.
			Debug.Log(serviceData);
		}
		else
		{
			Debug.Log(www.error);
		}
	}
}
