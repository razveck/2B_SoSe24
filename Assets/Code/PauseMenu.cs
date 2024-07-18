//Author: João Azuaga

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Code {
	public class PauseMenu : MonoBehaviour {

		// Use this for initialization
		private void Start() {

		}

		public void ToMenu() {
			StartMenu.MusicInstance.setParameterByNameWithLabel("Scene", "Menu");
			LoadingManager manager = FindObjectOfType<LoadingManager>(true);
			manager.UnloadAndLoad(1, 0);
		}

		
	}
}
