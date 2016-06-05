using UnityEngine;
using System.Collections;

public class keyboardcontrol : MonoBehaviour {

	public Transform lighting;
	private float lightime;

	// Use this for initialization
	void Start () {
		lightime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("a")) {
			if(lightime == -1.0f)
				Transform cloneLighting = Instantiate(lighting, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
			else if (lightime > 0)
				lightime -= Time.deltaTime;
			if(lightime == 0){
				//Destroy(cloneLighting);

			}
		}
	}
}
