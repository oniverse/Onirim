using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class DoorDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text>().text = string.Join(Environment.NewLine, GameStateManager.DiscoveredDoors.Select(c => c.ToString()).ToArray());
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Text>().text = string.Join(Environment.NewLine, GameStateManager.DiscoveredDoors.Select(c => c.ToString()).ToArray());
	}
}
