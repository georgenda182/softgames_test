using TMPro;
using UnityEngine;

public class MagicWords_Installer : MonoBehaviour
{
    [Header("Chat config")]
    [SerializeField] private ChatView _chatView;
    [SerializeField] private NameToAvatar _nameToAvatar;
    [SerializeField] private string _url = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

    [Header("Message")]
    [SerializeField] private TextMeshProUGUI _message;
    [SerializeField] private string _onDownloadingText = "Downloading...";
    [SerializeField] private string _onErrorText = "Downloaded failed";

    private ContentDownloader _downloader;
    private ChatDownloadResult _chatDownloadResult;

    private void Awake()
    {
        _downloader = new ContentDownloader(_url);
    }

    private void Start()
    {
        PerformChatConstruction();
    }

    private async void PerformChatConstruction()
    {
        _message.text = _onDownloadingText;

        _chatDownloadResult = await _downloader.DownloadChat();

        if (_chatDownloadResult.Success)
        {
            await _downloader.DownloadAvatars(_chatDownloadResult.Chat.avatars, _nameToAvatar);
            _chatView.SetDialogue(_chatDownloadResult.Chat.dialogue);
            _message.gameObject.SetActive(false);
        }
        else
        {
            _message.color = Color.red;
            _message.text = _onErrorText;
        }
    }
}