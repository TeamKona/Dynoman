using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine("DespawnExplosion");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay (Collider col)
	{

		if(col.gameObject.tag == "Combustible")
		{
			Destroy(col.gameObject);
		}

	}

	IEnumerator DespawnExplosion (){

		yield return new WaitForSeconds(2f);
		GameObject.Destroy(this.gameObject);
	}
}
