using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	/// <summary>
	/// Aims at the centre of the group of targets, with a certain deviation.
	/// Sets the speed used by spawner
	/// </summary>
	public GameObject[] targets;
	public Spawner spawner;
	public float spread;
	public float time_of_flight;
	public GameObject maxHeight;

	public GameObject gameController;
	Controller controller;

	Vector3 aim;
	// Use this for initialization
	void Start () {
		controller = gameController.GetComponent<Controller> ();
		Vector3 mean = chooseTarget();

		Vector3 init_vel = initial_velocity (mean - spawner.transform.position, time_of_flight);

		aim = init_vel;
		gameObject.transform.LookAt (aim);
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.running) {
			if (spawner.current_cooldown <= 0f) {
			
				Vector3 mean = chooseTarget ();
				mean = add_noise (mean);
				Vector3 init_vel = initial_velocity (mean - spawner.transform.position, time_of_flight);
				gameObject.GetComponentsInChildren<Spawner> () [0].set_speed (init_vel.magnitude);

				aim = init_vel;

				spawner.shoot ();
			}
			Vector3 next_euler;
			Quaternion aim_q = Quaternion.identity;
			aim_q.SetLookRotation (aim);
			next_euler = 0.1f * (aim_q.eulerAngles - gameObject.transform.rotation.eulerAngles) + gameObject.transform.rotation.eulerAngles;
			gameObject.transform.eulerAngles = next_euler;
		}

	}

	Vector3 add_noise(Vector3 target){
		Vector3 new_vector;

		new_vector = target + Random.insideUnitSphere * spread;

		if (new_vector.y > maxHeight.transform.position.y) {
			new_vector.y = maxHeight.transform.position.y;
		}

		return new_vector;
	}

	Vector3 initial_velocity(Vector3 target, float tof){
		Vector3 init_vel;
		init_vel.x = target.x / tof;
		init_vel.z = target.z / tof;
		init_vel.y = (target.y - 0.5f * Physics.gravity.y * tof * tof) / tof;

		return init_vel;
	}

	Vector3 chooseTarget(){

		int r = Random.Range (0, targets.Length);
		Vector3 target = targets [r].transform.position;
		return target;
	}
}
