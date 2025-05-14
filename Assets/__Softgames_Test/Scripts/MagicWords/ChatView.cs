using UnityEngine;

public class ChatView : MonoBehaviour
{
    [SerializeField] private AvatarNameToTexture _avatarNameToTexture;

    [SerializeField] private MessageView _messagePrefab;
    [SerializeField] private RectTransform _content;

    public void SetDialogue(ContentDownloader.Message[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            MessageView message = Instantiate(_messagePrefab, _content);
            message.Configure(_avatarNameToTexture.GetTextureByName(messages[i].name), messages[i].name, messages[i].text);
        }
    }
}
