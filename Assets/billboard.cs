using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class billboard : MonoBehaviour {
	Transform mainCam;

	// Start is called before the first frame update
	void Start() {
#if UNITY_EDITOR
		if(UnityEditor.EditorApplication.isPlaying) {
			mainCam = Camera.main.transform;
		}else{
			mainCam = (UnityEditor.SceneView.sceneViews[0] as UnityEditor.SceneView).camera.transform;
		}
#else
		mainCam = Camera.main.transform;
#endif
	}

	// Update is called once per frame
	void LateUpdate() {
		transform.forward = mainCam.forward * -1;
	}
}
