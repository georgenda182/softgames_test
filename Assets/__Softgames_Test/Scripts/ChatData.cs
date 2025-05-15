using System;
using UnityEngine;

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

public class ChatDownloadResult
{
    public Chat Chat;
    public bool Success;
}

[Serializable]
public struct DefinedAvatar
{
    public Texture Texture;
    public bool IsRightPosition;

    public DefinedAvatar(Texture texture, string position)
    {
        Texture = texture;
        IsRightPosition = position == "right";
    }
}