using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class DrumSound : AbstractSound {

	float lastSphereRadius;
	int drumThreshold = 45;

	public DrumSound(ref AudioClip _ac, Vector3 _position)
		: base(ref _ac, _position) {
	}

	override public void UpdateFrame (ref Frame frame) {
		HandList hands = frame.Hands;
		Hand firstHand = hands [0];

		float recentSphereRadius = firstHand.SphereRadius;
		if (recentSphereRadius > 0) {
			if (lastSphereRadius > drumThreshold && recentSphereRadius <= drumThreshold) {
				Debug.Log (firstHand.SphereRadius);
				AudioSource.PlayClipAtPoint (ac, position);
			}
			lastSphereRadius = recentSphereRadius;
		}
	}
}
