using UnityEngine;
using System.Collections;

public class p8 : MonoBehaviour {

	private GameObject player;
	public float offset = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + offset);
	}
}
