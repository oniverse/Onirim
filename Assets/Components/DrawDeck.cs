using Onirim.Cards;
using Onirim.Extensions;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DrawDeck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.GetComponentInChildren<Text>().text = "Draw Deck";

		var button = gameObject.GetComponent<Button>();
		button.onClick.AddListener(DrawCards);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponentInChildren<Text> ().text = GetText();
	}

    private string GetText()
    {
        if (GameStateManager.CurrentTurnPhase == GameStateManager.TurnPhase.Draw)
        {
            return string.Format("{0} cards remaining\n\nClick to Draw", GameStateManager.DrawDeck.Count());
        }
        else if (GameStateManager.CurrentTurnPhase == GameStateManager.TurnPhase.Shuffle)
        {
            return string.Format("{0} cards remaining\n{1} in limbo\n\nClick to Shuffle", GameStateManager.DrawDeck.Count(), GameStateManager.Limbo.Count());
        }
        return string.Format("{0} cards remaining", GameStateManager.DrawDeck.Count());
    }

	private void DrawCards()
	{
        if (GameStateManager.CurrentTurnPhase == GameStateManager.TurnPhase.Draw)
        {
            for (var i = GameStateManager.PlayerHand.Count - 1; i >= 0; i--)
            {
                if (GameStateManager.PlayerHand[i] == null)
                {
                    GameStateManager.PlayerHand[i] = GameStateManager.DrawDeck.Draw<LabyrinthCard>();
                }
            }
            GameStateManager.CurrentTurnPhase = GameStateManager.Limbo.Any() ? GameStateManager.TurnPhase.Shuffle : GameStateManager.TurnPhase.Play;
        }
        else if (GameStateManager.CurrentTurnPhase == GameStateManager.TurnPhase.Shuffle)
        {
            if (GameStateManager.Limbo.Any())
            {
                GameStateManager.DrawDeck.Add(GameStateManager.Limbo);
                GameStateManager.Limbo.Clear();
                GameStateManager.DrawDeck.Shuffle();
            }
            GameStateManager.CurrentTurnPhase = GameStateManager.TurnPhase.Play;
        }
    }
}
