using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	
	private MeshRenderer _renderer;

	public DialogScreen DialogScreen;
	public DialogItem Item;

	public Material NormalMaterial;
	public Material HighlightMaterial;

	private void Start() {
		_renderer = GetComponent<MeshRenderer>();
	}

	public void Interact(){
		DialogScreen.StartDialog(Item);
	}

	public void Highlight(){
		_renderer.material = HighlightMaterial;
	}

	public void Unhighlight(){
		_renderer.material = NormalMaterial;
	}

}
