using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class MotionDetection : MonoBehaviour {

	ArrayList sounds;

	public AudioClip drumAc;

	// Use this for initialization
	void Start () {
		sounds = new ArrayList ();
		sounds.Add (new DrumSound(ref drumAc, transform.position));
	}

	// Update is called once per frame
	void Update () {
		Controller controller = GameObject.Find ("Hand Controller").GetComponent<HandController>().GetLeapController();
		Frame frame = controller.Frame (); // controller is a Controller object
		foreach (AbstractSound sound in sounds) {
			sound.UpdateFrame (ref frame);
		}
	}
}
