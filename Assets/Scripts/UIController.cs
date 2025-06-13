using System;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public UIDocument settingsMenu;
    public UIDocument chatMenu;
    private VisualElement settingsMenuRoot;
    private VisualElement chatMenuRoot;
    private Button settingsExitButton;
    private Button chatExitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsMenuRoot = settingsMenu.rootVisualElement;
        chatMenuRoot = chatMenu.rootVisualElement;

        settingsExitButton = settingsMenuRoot.Q<Button>("ExitButton");
        chatExitButton = chatMenuRoot.Q<Button>("ExitButton");

        settingsExitButton.clicked += () => CloseMenu(settingsMenuRoot);
        chatExitButton.clicked += () => CloseMenu(chatMenuRoot);

        //Test Add Text
        string[] messages = {"This is an example text message", "There is another message right here bitch"};
        AddMessagesToChat(messages);
    }

    private void CloseMenu(VisualElement menu)
    {
        menu.style.display = DisplayStyle.None;
    }

    private void AddMessagesToChat(string[] messages)
    {
        // var newMessage = new Label();
        // newMessage.text = "Here is an example message for a game.";
        // newMessage.AddToClassList("chat-message");

        VisualElement messageContainer = chatMenuRoot.Q<VisualElement>("MessageContainer");
        // messageContainer.Add(newMessage);

        foreach (string message in messages)
        {
            var newMessage = new Label();
            newMessage.text = message;
            newMessage.AddToClassList("chat-message");

            messageContainer.Add(newMessage);
        }
    }
}
