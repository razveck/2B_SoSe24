using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour {


	// Start is called before the first frame update
	void Start() {
	}

	public void UnloadAndLoad(int unload, int load) {
		gameObject.SetActive(true);
		StartCoroutine(LoadingCoroutine(unload, load));
	}

	IEnumerator LoadingCoroutine(int unload, int load){

		AsyncOperation op = SceneManager.UnloadSceneAsync(unload);

		//1 Sekunde warten
		//yield return new WaitForSeconds(1f);
		//1 Frame warten
		//yield return null;

		//solange op is NICHT done, werden wir die Coroutine 1 Frame pausieren
		while(!op.isDone){
			yield return null;
			Debug.Log("not done");
		}

		yield return new WaitForSeconds(1f);

		Debug.Log("Loading");
		//entlädt alle offenen Scenes
		//SceneManager.LoadScene(0);

		//lädt ohne Scenes zu entladen
		op = SceneManager.LoadSceneAsync(load, LoadSceneMode.Additive);

		while(!op.isDone)
			yield return null;

		SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(load));
		
		gameObject.SetActive(false);
	}
}
