using Onirim.Cards;
using Onirim.Deck;
using Onirim.Extensions;
using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {
	
	public static OnirimDeck DrawDeck;
    public static List<Card> Limbo = new List<Card>();
    public static List<DoorCard> DiscoveredDoors = new List<DoorCard>();
    public static List<LabyrinthCard> PlayerHand = new List<LabyrinthCard>();
    public static List<LabyrinthCard> CardDisplay = new List<LabyrinthCard>();
    public static List<LabyrinthCard> CurrentDoor = new List<LabyrinthCard>();
    public static TurnPhase CurrentTurnPhase;

    public enum TurnPhase
    {
        Play,
        Draw,
        Shuffle,
    }

	// Use this for initialization
	void Start () {

        DrawDeck = new OnirimDeck();
		DrawDeck.Shuffle();

        // Deal starting hand. Reshuffle in case doors/nightmares were encountered in initial draw.
        PlayerHand.DrawUpTo(5, DrawDeck, ignoreInterrupt: true);
        DrawDeck.Shuffle();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static LabyrinthCard CardAt(int i)
	{
		if (PlayerHand.Count < i + 1) {
			return null;
		}
		return PlayerHand [i];
	}
}