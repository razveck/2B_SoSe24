using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public static EventInstance MusicInstance;

	public EventReference MusicEvent;

	// Start is called before the first frame update
	void Start() {
		if(!MusicInstance.hasHandle()) {
			MusicInstance = RuntimeManager.CreateInstance(MusicEvent);
			MusicInstance.start();
		}
	}

	public void StartGame() {
		MusicInstance.setParameterByNameWithLabel("Scene", "Level");

		SceneManager.LoadScene(1);
	}

	public void MuteAudio(bool muted) {
		RuntimeManager.MuteAllEvents(muted);
	}


}
