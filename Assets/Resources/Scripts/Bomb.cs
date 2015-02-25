using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {



	public float bombFuse = 2f;
	public GameObject spawnExplosion;


	// Use this for initialization
	void Start () {
	
		StartCoroutine("BombTimer");


	}
	
	// Update is called once per frame
	void Update () {
	

	}

	IEnumerator BombTimer (){

		Debug.Log("whatever");
		yield return new WaitForSeconds(bombFuse);
		GameObject.Find("Player").GetComponent<SpawnBomb>().amount--;
		GameObject.Destroy(this.gameObject);
		Instantiate(spawnExplosion,new Vector3 (transform.position.x,transform.position.y,transform.position.z+1), transform.rotation);
		//Instantiate(part1, part2, part3);
	}



}
