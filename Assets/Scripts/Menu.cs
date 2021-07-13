using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private InputField inputField;
    private  Button startButton;
    private int characterLimit = 12;
    private int requiredCharacters = 3;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponentInChildren<InputField>();
        inputField.onValueChanged.AddListener(delegate {ButtonInteractableHandler();});
        inputField.characterLimit = characterLimit;

        startButton = GetComponentInChildren<Button>();
        startButton.interactable = false;
        startButton.onClick.AddListener(OnStartClick);
    }
    public bool NameLength()
    {
        if (inputField.text.Length >= requiredCharacters)
            return true;
        else
            return false;
    }
    public void ButtonInteractableHandler()
    {
        if (NameLength())
            startButton.interactable = true;
        else
            startButton.interactable = false;
    }
    public void OnStartClick()
    {
        DataPersistence.SetPlayerName(inputField.text);
        SceneManager.LoadScene(1);
    }
}
