using UnityEngine;
using System.Collections;

using EZCameraShake;

public class keyboardcontrol : MonoBehaviour {

	public Transform lighting;
	private float lightime;

	public GameObject rain;

	Vector3 posInf = new Vector3(0.25f, 0.25f, 0.25f);
	Vector3 rotInf = new Vector3(1, 1, 1);
	float magn = 5, rough = 3, fadeIn = 0.1f, fadeOut = 2f;

	bool modValues;
	bool showList;

	CameraShakeInstance shake;

	// Use this for initialization
	void Start () {
		lightime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a")) {
			/*
			if(lightime == -1.0f)
				Transform cloneLighting = Instantiate(lighting, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
			else if (lightime > 0)
				lightime -= Time.deltaTime;
			if(lightime == 0){
				//Destroy(cloneLighting);

			}
			*/
			Transform cloneLighting = Instantiate(lighting, new Vector3(0, 10, 0), Quaternion.identity) as Transform;
		}
		if (Input.GetKey ("r")) {
			Instantiate(rain, new Vector3(0, 0, 0), Quaternion.identity);
		}
		if (Input.GetKey ("e")) {
			if (shake == null) {
				shake = CameraShaker.Instance.StartShake(magn, rough, fadeIn);
				shake.DeleteOnInactive = false;
			}
		}
	}
}
