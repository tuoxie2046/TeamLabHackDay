using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

using EZCameraShake;

public class keyboardcontrol : MonoBehaviour {

	public Transform lighting;

    public GameObject handview;

	private float lightime;
	public Transform rain;

    private string handges;

    //public GameObject rain;

	public Sprite sunnyImage;
	public Sprite rainImage;
	public Sprite lightingImage;
	public Sprite earthquakeImage;

	public MeshRenderer fallingObject;

	//public AudioClip[] musicList;
	public AudioClip eqMusic;
	public AudioClip thunderMusic;
	AudioSource stingSource;

	//public GameObject rain;

    Vector3 posInf = new Vector3(0.25f, 0.25f, 0.25f);
	Vector3 rotInf = new Vector3(1, 1, 1);
	float magn = 5, rough = 3, fadeIn = 0.1f, fadeOut = 2f;

	bool modValues;
	bool showList;

	SpriteRenderer sr;

	CameraShakeInstance shake;

	// Use this for initialization
	void Start () {
		lightime = 0.0f;
		sr = GameObject.Find ("background").GetComponent<SpriteRenderer> ();
		stingSource = GameObject.Find ("soundeffect").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
        handges = handview.GetComponent<HandsViewer>().Gesture;
        Debug.Log("gesture"+handges);
        if (Input.GetKey ("a") || handges == "spreadfingers") {
            Debug.Log("spreadfingers");

			float xmyInt, zmyInt;
			xmyInt = Random.Range(-5,2);
			zmyInt = Random.Range(-2,3);

			Transform cloneLighting = Instantiate(lighting, new Vector3(xmyInt, 0.0f, zmyInt), Quaternion.Euler(0.0f, 0.0f, 90.0f)) as Transform;

			MeshRenderer cloneChair = Instantiate(fallingObject, new Vector3(Random.Range(-5,2), 2.0f, Random.Range(-2,3)), Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360))) as MeshRenderer;
			cloneChair.gameObject.AddComponent<Rigidbody>();

			Destroy (cloneLighting.gameObject, 3);
			Destroy (cloneChair.gameObject, 3);

			sr.sprite = lightingImage;
			stingSource.clip = thunderMusic;
			stingSource.Play ();
		}

		if (Input.GetKey ("g") || handges == "v-sign") {
			Transform cloneRain = Instantiate(rain, new Vector3(0, 0, 0), Quaternion.identity) as Transform;
			Destroy (cloneRain.gameObject, 3);
			sr.sprite = rainImage;
		}

		if (Input.GetKey ("e") || handges == "tap") {
			if (shake == null || lightime <= 0.0f) {
				shake = CameraShaker.Instance.StartShake(magn, rough, fadeIn);
				shake.DeleteOnInactive = false;
				lightime = 3.0f;
				sr.sprite = earthquakeImage;
				stingSource.clip = eqMusic;
				stingSource.Play ();
			}
		}
		if (lightime > 0) {
			lightime -= Time.deltaTime;
		} else if (shake != null) {
			shake.DeleteOnInactive = true;
			shake.StartFadeOut(fadeOut);
			shake = null;
			sr.sprite = sunnyImage;
		}

	}
}
