using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class CardDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().text = string.Join(Environment.NewLine, GameStateManager.CardDisplay.Select(c => c.ToString()).ToArray());
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = string.Join(Environment.NewLine, GameStateManager.CardDisplay.Select(c => c.ToString()).ToArray());
	}
}
