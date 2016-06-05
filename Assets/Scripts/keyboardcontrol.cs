using UnityEngine;
using System.Collections;

using EZCameraShake;

public class keyboardcontrol : MonoBehaviour {

	public Transform lighting;
	private float lightime;
	public Transform rain;

	//public GameObject rain;

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

			Transform cloneLighting = Instantiate(lighting, new Vector3(0, 0, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f)) as Transform;
			Destroy (cloneLighting.gameObject, 3);
		}

		if (Input.GetKey ("r")) {
			Transform cloneRain = Instantiate(rain, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
			Destroy (cloneRain.gameObject, 3);
		}

		if (Input.GetKey ("e")) {
			if (shake == null || lightime <= 0.0f) {
				shake = CameraShaker.Instance.StartShake(magn, rough, fadeIn);
				shake.DeleteOnInactive = false;
				lightime = 3.0f;
			}
		}
		if (lightime > 0) {
			lightime -= Time.deltaTime;
		} else if (shake != null) {
			shake.DeleteOnInactive = true;
			shake.StartFadeOut(fadeOut);
			shake = null;
		}

	}
}
