using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {

	//const = konstant
	//nachdem der Konstante einen Wert gegeben wird, darf dieser Wert nicht geändert werden (im Runtime)
	const string masterVolumePref = "MasterVolume";

	public static EventInstance MusicInstance;

	public EventReference MusicEvent;

	public Slider MasterSlider;
	public Slider MusicSlider;
	public Slider AmbienceSlider;
	public Slider SfxSlider;

	// Start is called before the first frame update
	void Start() {
		if(!MusicInstance.hasHandle()) {
			MusicInstance = RuntimeManager.CreateInstance(MusicEvent);
			MusicInstance.start();
		}

		MasterSlider.onValueChanged.AddListener(MasterSliderChanged);
		MusicSlider.onValueChanged.AddListener(MusicSliderChanged);
		AmbienceSlider.onValueChanged.AddListener(AmbienceSliderChanged);
		SfxSlider.onValueChanged.AddListener(SfxSliderChanged);

		MasterSlider.value = PlayerPrefs.GetFloat(masterVolumePref);
		MusicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
		AmbienceSlider.value = PlayerPrefs.GetFloat("AmbienceVolume");
		SfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");


		//Fehler: dies ist keine Variabel (sondern const), darf nicht geändert werden
		//masterVolumePref = "jhgukygyu";

		//Code für selected object
		//UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(MasterSlider.gameObject);
	}

	public void StartGame() {
		MusicInstance.setParameterByNameWithLabel("Scene", "Level");

		SceneManager.LoadScene(1);
	}

	public void MasterSliderChanged(float value){
		//CHOOSE ONE:

		//bus
		//RuntimeManager.GetBus("bus:/").setVolume(value); //zwischen 0 und 1

		//VCA
		RuntimeManager.GetVCA("vca:/Master").setVolume(value);

		PlayerPrefs.SetFloat(masterVolumePref, value);
	}

	public void MusicSliderChanged(float value){
		RuntimeManager.GetVCA("vca:/Music").setVolume(value);
		PlayerPrefs.SetFloat("MusicVolume", value);
	}

	public void AmbienceSliderChanged(float value){
		RuntimeManager.GetVCA("vca:/Ambience").setVolume(value);
		PlayerPrefs.SetFloat("AmbienceVolume", value);
	}

	public void SfxSliderChanged(float value){
		RuntimeManager.GetVCA("vca:/SFX").setVolume(value);
		PlayerPrefs.SetFloat("SfxVolume", value);
	}

}
