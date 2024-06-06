using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	EventInstance _musicInstance;
	public EventReference MusicEvent;

	// Start is called before the first frame update
	void Start() {
		_musicInstance = RuntimeManager.CreateInstance(MusicEvent);
		_musicInstance.start();
	}

	public void StartGame() {
		_musicInstance.setParameterByNameWithLabel("Scene", "Level");

		SceneManager.LoadScene(1);
	}

	public void MuteAudio(bool muted) {
		RuntimeManager.MuteAllEvents(muted);
	}


}
