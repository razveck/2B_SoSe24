using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UIElements;

public class FootstepPlayer : MonoBehaviour {

	public EventInstance footstepInstance;

	//2 Möglichkeiten
	//event path
	//public string EventPath;
	//event reference
	public EventReference FootstepEvent;



	public string defaultSound = "Leaves";
	public string concreteSound = "Concrete";
	public string forestSound = "Forest";

	// Start is called before the first frame update
	void Start() {
		footstepInstance = RuntimeManager.CreateInstance(FootstepEvent);
		footstepInstance.setParameterByNameWithLabel("Untergründe", defaultSound);

	}

	public void PlayFootstep(){
		footstepInstance.set3DAttributes(RuntimeUtils.To3DAttributes(transform));

		footstepInstance.start();

		//RuntimeManager.PlayOneShot(FootstepEvent, transform.position);
	}
}
