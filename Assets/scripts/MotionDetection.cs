using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class MotionDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	float lastSphereRadius;
	int drumThreshold = 45;

	public AudioClip drumAc;

	// Update is called once per frame
	void Update () {
		Controller controller = GameObject.Find ("Hand Controller").GetComponent<HandController>().GetLeapController();
		Frame frame = controller.Frame (); // controller is a Controller object
		HandList hands = frame.Hands;
		Hand firstHand = hands [0];

		float recentSphereRadius = firstHand.SphereRadius;
		if (recentSphereRadius > 0) {
			if (lastSphereRadius > drumThreshold && recentSphereRadius <= drumThreshold) {
				Debug.Log (firstHand.SphereRadius);
				AudioSource.PlayClipAtPoint (drumAc, transform.localPosition);
			}
			lastSphereRadius = recentSphereRadius;
		}
	}
}
