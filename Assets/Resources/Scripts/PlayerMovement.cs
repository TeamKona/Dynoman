using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;
	private GameObject p8;
	private Vector3 p8position = new Vector3(0, 0, 0);
	public bool isMoving = false;

	// Use this for initialization
	void Start () {
		p8 = GameObject.Find("P8");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			if (!isMoving){
				isMoving = true;
				p8position = p8.transform.position;
				StartCoroutine("MoveForwards");
			}
			//rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.A)){
			StartCoroutine("RotateLeft");
		}
		if (Input.GetKeyDown(KeyCode.D)){
			StartCoroutine("RotateRight");
		}

	}

	IEnumerator MoveForwards () {
		do{
			rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
			Debug.Log("Am Boofy");
			yield return null;
		}while(transform.position.z <= p8position.z);
		if (!(Input.GetKey(KeyCode.W))){
			rigidbody.velocity = new Vector3(0, 0, 0);
		}
		transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
		isMoving = false;
	}

	IEnumerator RotateLeft () {
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, -3, 0));
			yield return null;
		}
	}

	IEnumerator RotateRight () {
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, 3, 0));
			yield return null;
		}
	}
}
