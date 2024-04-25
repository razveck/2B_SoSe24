using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {
	
	private MeshRenderer _renderer;

	public DialogScreen DialogScreen;
	public DialogItem Item;

	public Material NormalMaterial;
	public Material HighlightMaterial;

	public UnityEvent OnInteracted;

	private void Start() {
		_renderer = GetComponent<MeshRenderer>();
	}

	public void Interact(){
		OnInteracted.Invoke();

		DialogScreen.StartDialog(Item);
	}

	public void Highlight(){
		_renderer.material = HighlightMaterial;
	}

	public void Unhighlight(){
		_renderer.material = NormalMaterial;
	}

	public void SetDialog(DialogItem newItem){
		Item = newItem;
	}

}
