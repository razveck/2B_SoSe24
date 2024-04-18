using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
	
	public DialogScreen DialogScreen;
	public DialogItem Item;

	public void Interact(){
		DialogScreen.StartDialog(Item);
	}

}
