using Onirim.Cards;
using Onirim.Components;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public abstract class HandCardBase : MonoBehaviour {

	public abstract int Index { get; }
	private Button _button;

    // Use this for initialization
    void Start() {
        gameObject.GetComponentInChildren<Text>().text = GameStateManager.CardAt(Index) == null ? string.Empty : GameStateManager.CardAt(Index).ToString();

        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(PlayCard);
    }
	
	// Update is called once per frame
	void Update () {
		var canPlay = CanPlay();
		_button.image.color = canPlay ? GetCardColor() : Color.grey;
		_button.enabled = canPlay;
		gameObject.GetComponentInChildren<Text>().text = GameStateManager.CardAt(Index) == null ? string.Empty : GameStateManager.CardAt(Index).ToString();
	}
	
	private void PlayCard()
	{
		var playedCard = GameStateManager.PlayerHand[Index];
		GameStateManager.PlayerHand[Index] = null;
        GameStateManager.CardDisplay.Add(playedCard);

        // Check if last 3 cards Qualify for a door
        if (GameStateManager.CurrentDoor.Any(c => c.Color != playedCard.Color))
        {
            GameStateManager.CurrentDoor.Clear();
        }
        GameStateManager.CurrentDoor.Add(playedCard);

        if (GameStateManager.CurrentDoor.Count() == 3 && GameStateManager.DiscoveredDoors.Count(c => c.Color == playedCard.Color) < 2)
        {
            GameStateManager.CurrentDoor.Clear();

            var door = GameStateManager.DrawDeck.GetFirst(c => (c as DoorCard) != null && (c as DoorCard).Color == playedCard.Color);
            GameStateManager.DrawDeck.Remove(door);
            GameStateManager.DiscoveredDoors.Add(door as DoorCard);
            GameStateManager.DrawDeck.Shuffle();
        }
        GameStateManager.CurrentTurnPhase = GameStateManager.TurnPhase.Draw;
    }
	
	private bool CanPlay()
    {
        if (GameStateManager.CurrentTurnPhase != GameStateManager.TurnPhase.Play)
        {
            return false;
        }
        if (GameStateManager.CardAt(Index) == null)
        {
            return false;
        }
        var lastPlayed = GameStateManager.CardDisplay.LastOrDefault();
		return lastPlayed == null || (lastPlayed.Type != GameStateManager.CardAt(Index).Type);
	}
	
	private Color GetCardColor()
	{
		switch (GameStateManager.PlayerHand[Index].Color) {
			case CardColor.Blue:
				return Constants.Blue;
			case CardColor.Red:
				return Constants.Red;
			case CardColor.Green:
				return Constants.Green;
			case CardColor.Brown:
				return Constants.Brown;
			default:
				return Color.white;
		}
	}
}
