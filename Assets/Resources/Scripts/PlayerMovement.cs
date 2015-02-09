using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 500;
	private GameObject p8;
	private Vector3 p8position = new Vector3(0, 0, 0);
	public bool isMoving = false;
	public bool canTurn = true;
	public float turnDelay = 0.5f;

	private Vector3 vNorth = new Vector3(0, 0, 1);
	private Vector3 vSouth = new Vector3(0, 0, -1);
	private Vector3 vEast = new Vector3(1, 0, 0);
	private Vector3 vWest = new Vector3(-1, 0, 0);


	// Use this for initialization
	void Start () {
		p8 = GameObject.Find("P8");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
			if (!isMoving){
				isMoving = true;
				canTurn = false;
				StartCoroutine("MoveTurnDelay");
				p8position = p8.transform.position;
				StartCoroutine("MoveForwards");
			}
		}

		if (Input.GetKeyDown(KeyCode.A) && canTurn){
			StartCoroutine("RotateLeft");
		}
		if (Input.GetKeyDown(KeyCode.D) && canTurn){
			StartCoroutine("RotateRight");
		}

	}

	IEnumerator MoveForwards () {

		switch((int)transform.forward.z){
		case 1:
			//Debug.Log("North");
			do{
				rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z <= p8position.z);
			break;
		case -1:
			//Debug.Log("South");
			do{
				rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.z >= p8position.z);
			break;
		default:	
			break;
		}
		switch((int)transform.forward.x){
		case 1:
			//Debug.Log("East");
			do{
				rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.x <= p8position.x);
			break;
		case -1:
			//Debug.Log("West");
			do{
				rigidbody.AddForce(transform.forward * speed * Time.deltaTime);
				yield return null;
			}while(transform.position.x >= p8position.x);
			break;
		default:	
			break;
		}

		//Not Holding W Down
		if (!(Input.GetKey(KeyCode.W))){
			rigidbody.velocity = new Vector3(0, 0, 0);
		}

		//Normalize Position
		transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
		isMoving = false;
	}

	IEnumerator MoveTurnDelay (){
		yield return new WaitForSeconds(turnDelay);
		canTurn = true;
	}

	IEnumerator RotateLeft () {
		canTurn = false;
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, -3, 0));
			yield return null;
		}
		canTurn = true;
	}

	IEnumerator RotateRight () {
		canTurn = false;
		for (int i = 0; i < 90; i+=3){
			transform.Rotate(new Vector3 (0, 3, 0));
			yield return null;
		}
		canTurn = true;
	}
}
