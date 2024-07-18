//Author: João Azuaga

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Assets.Code {
	public class InputTest : MonoBehaviour {

		public PlayerInput input;

		// Use this for initialization
		private void Start() {

		}

		// Update is called once per frame
		private void Update() {
			if(input.actions.FindAction("Interact").WasPressedThisFrame())
				Debug.Log("BLA");
		}
	}
}
