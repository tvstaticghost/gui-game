using System;
using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public UIDocument settingsMenu;
    public UIDocument chatMenu;
    public UIDocument chatShortcut;
    public UIDocument settingsShortcut;
    private VisualElement settingsMenuRoot;
    private VisualElement chatMenuRoot;
    private Button settingsExitButton;
    private Button chatExitButton;
    private VisualElement chatIconRoot;
    private VisualElement settingsIconRoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingsMenuRoot = settingsMenu.rootVisualElement;
        chatMenuRoot = chatMenu.rootVisualElement;
        chatIconRoot = chatShortcut.rootVisualElement;
        settingsIconRoot = settingsShortcut.rootVisualElement;

        settingsExitButton = settingsMenuRoot.Q<Button>("ExitButton");
        chatExitButton = chatMenuRoot.Q<Button>("ExitButton");

        chatIconRoot = chatShortcut.rootVisualElement.Q<VisualElement>("ShortcutContainer");
        settingsIconRoot = settingsShortcut.rootVisualElement.Q<VisualElement>("ShortcutContainer");

        settingsExitButton.clicked += () => CloseMenu(settingsMenuRoot);
        chatExitButton.clicked += () => CloseMenu(chatMenuRoot);

        chatIconRoot.pickingMode = PickingMode.Position;
        chatIconRoot.RegisterCallback<ClickEvent>(evt =>
        {
            OpenMenu(chatMenuRoot);
        });

        settingsIconRoot.pickingMode = PickingMode.Position;
        settingsIconRoot.RegisterCallback<ClickEvent>(evt =>
        {
            OpenMenu(settingsMenuRoot);
        });

        //Test Add Text
        string[] messages = {"This is an example text message", "There is another message right here bitch"};
        AddMessagesToChat(messages);
    }

    private void CloseMenu(VisualElement menu)
    {
        menu.style.display = DisplayStyle.None;
    }

    private void OpenMenu(VisualElement menu)
    {
        menu.style.display = DisplayStyle.Flex;
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
