using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject projectile;
	public GameObject gameController;
	Controller controller;

	float speed = 0f;
	public float cooldown;
	public float current_cooldown;
	public int total_spawned = 0;
	public void set_speed(float n_speed){
		speed = n_speed;
	}

	// Use this for initialization
	void Start () {
		controller = gameController.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.running) {
			current_cooldown -= Time.deltaTime;
		}
	}

	public void shoot(){
		current_cooldown = cooldown;

		GameObject new_ball;
		Rigidbody rigid_body;

		new_ball =(GameObject) GameObject.Instantiate (projectile);
		total_spawned++;
		new_ball.transform.position = gameObject.transform.position;
		new_ball.transform.rotation = gameObject.transform.rotation;
		rigid_body = new_ball.GetComponentsInChildren<Rigidbody> ()[0];

		rigid_body.velocity = transform.TransformDirection(new Vector3 (0, 0, speed));
	}
}
