using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ContentDownloader
{
    private string URL = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";

    public ContentDownloader(string url)
    {
        URL = url;
    }

    public async Task<ChatDownloadResult> DownloadChat()
    {
        ChatDownloadResult chatDownloadResult = new();

        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            await request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                chatDownloadResult.Success = true;
                string downloadedJson = request.downloadHandler.text;
                chatDownloadResult.Chat = JsonUtility.FromJson<Chat>(downloadedJson);
                DialogueFormatter.Format(ref chatDownloadResult.Chat.dialogue);
            }
            return chatDownloadResult;
        }
    }

    public async Task DownloadAvatars(Avatar[] avatars, NameToAvatar nameToAvatar)
    {
        for (int i = 0; i < avatars.Length; i++)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(avatars[i].url))
            {
                await request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogWarning($"Could not register avatar \"{avatars[i].url}\". Error displayed below:\n\n{request.error}");
                }
                else
                {
                    nameToAvatar.SetAvatar(avatars[i].name, DownloadHandlerTexture.GetContent(request), avatars[i].position);
                }
            }
        }
    }
}
