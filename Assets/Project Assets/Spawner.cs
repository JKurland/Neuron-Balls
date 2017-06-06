using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject Projectile;
	float speed = 0f;
	public float cooldown;
	public float current_cooldown = 5f;

	public void set_speed(float n_speed){
		speed = n_speed;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		current_cooldown -= Time.deltaTime;
	}

	public void shoot(){
		current_cooldown = cooldown;

		GameObject new_ball;
		Rigidbody rigid_body;

		new_ball =(GameObject) GameObject.Instantiate (Projectile);
		new_ball.transform.position = gameObject.transform.position;
		new_ball.transform.rotation = gameObject.transform.rotation;
		rigid_body = new_ball.GetComponentsInChildren<Rigidbody> ()[0];

		rigid_body.velocity = transform.TransformDirection(new Vector3 (0, 0, speed));
	}
}
