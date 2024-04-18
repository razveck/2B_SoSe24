using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogScreen : MonoBehaviour {

	private DialogItem _currentItem;

	public GameObject Container;

	public TMP_Text TextBox;

	public List<GameObject> Buttons;


	// Start is called before the first frame update
	void Start() {
		EndDialog();
	}

	// Update is called once per frame
	void Update() {

	}

	public void StartDialog(DialogItem item) {
		Container.SetActive(true);

		TextBox.text = item.Text;

		//for schleife
		for(int i = 0; i < Buttons.Count; i++) {
			if(i < item.Options.Count) {
				Buttons[i].SetActive(true);
				Buttons[i].GetComponentInChildren<TMP_Text>().text = item.Options[i].Text;
			} else {
				Buttons[i].SetActive(false);
			}
		}

		_currentItem = item;
	}

	public void EndDialog() {
		Container.SetActive(false);
	}

	public void ChooseOption(int index) {
		DialogOption option = _currentItem.Options[index];

		if(option.NextDialog != null) {
			StartDialog(option.NextDialog);
		} else {
			EndDialog();
		}
	}
}
