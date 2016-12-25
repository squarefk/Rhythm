using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public abstract class AbstractSound {

	protected AudioClip ac;
	protected Vector3 position;

	public AbstractSound (ref AudioClip _ac, Vector3 _position) {
		ac = _ac;
		position = _position;
	}

	abstract public void UpdateFrame (ref Frame frame);

}
