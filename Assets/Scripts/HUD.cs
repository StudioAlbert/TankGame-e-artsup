using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    [SerializeField] private UIDocument _hud;

    private Label _ennemiesLabel;
    private Label _endGameLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = _hud.rootVisualElement;
        if (root is not null)
        {
            _ennemiesLabel = root.Q<Label>("EnnemiesLabel");
            _endGameLabel = root.Q<Label>("EndGameWin");
        }
    }


    public void SetEnnemiesLabel(string lbl)
    {
        if (_ennemiesLabel is not null)
        {
            _ennemiesLabel.text = lbl;
        }
    }

    public void HideEndGame()
    {
        if(_endGameLabel is not null)
        {
            _endGameLabel.style.display = DisplayStyle.None;
        }
    }
    public void ShowEndGame()
    {
        if(_endGameLabel is not null)
        {
            _endGameLabel.style.display = DisplayStyle.Flex;
        }
    }
}
