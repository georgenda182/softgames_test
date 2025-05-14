using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ContentDownloader : MonoBehaviour
{
    [Serializable]
    public class Chat
    {
        public Message[] dialogue;
        public Avatar[] avatars;
    }

    [Serializable]
    public class Message
    {
        public string name;
        public string text;
    }

    [Serializable]
    public class Avatar
    {
        public string name;
        public string url;
        public string position;
    }

    private readonly string URL = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

    private string _downloadedJson;

    [SerializeField] private AvatarNameToTexture _avatarNameToTexture;
    [SerializeField] private Chat _chat;
    [SerializeField] private ChatView _chatView;

    private void Start()
    {
        StartCoroutine(GetText());
    }

    private IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                _downloadedJson = request.downloadHandler.text;
                _chat = JsonUtility.FromJson<Chat>(_downloadedJson);

                StartCoroutine(GetAvatars());
            }
        }
    }

    private IEnumerator GetAvatars()
    {
        for (int i = 0; i < _chat.avatars.Length; i++)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(_chat.avatars[i].url))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    _avatarNameToTexture.SetAvatar(_chat.avatars[i].name, DownloadHandlerTexture.GetContent(request));
                }
            }
        }
        ChangeIdsToEmojis();
        SetDialogueToChatView();
    }

    private void ChangeIdsToEmojis()
    {
        string[] ids =
        {
            "{satisfied}",
            "{intrigued}",
            "{neutral}",
            "{affirmative}",
            "{win}",
            "{laughing}"
        };
        string[] emojis =
        {
            "<sprite name=\"satisfied\">",
            "<sprite name=\"intrigued\">",
            "<sprite name=\"neutral\">",
            "<sprite name=\"affirmative\">",
            "<sprite name=\"win\">",
            "<sprite name=\"laughing\">"
        };

        for (int i = 0; i < _chat.dialogue.Length; i++)
        {
            for (int j = 0; j < ids.Length; j++)
            {
                _chat.dialogue[i].text = _chat.dialogue[i].text.Replace(ids[j], emojis[j]);
            }
        }
    }

    private void SetDialogueToChatView()
    {
        _chatView.SetDialogue(_chat.dialogue);
    }
}
