using UnityEngine;

public class ChatView : MonoBehaviour
{
    [SerializeField] private NameToAvatar _nameToAvatar;

    [SerializeField] private MessageView _messagePrefab;
    [SerializeField] private RectTransform _content;

    public void SetDialogue(Message[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            MessageView message = Instantiate(_messagePrefab, _content);
            message.Configure(_nameToAvatar.GetAvatarByName(messages[i].name), messages[i].name, messages[i].text);
        }
    }
}
