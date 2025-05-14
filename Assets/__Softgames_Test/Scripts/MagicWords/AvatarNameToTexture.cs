using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MagicWords/AvatarNameToTexture", fileName = "AvatarNameToTexture")]
public class AvatarNameToTexture : ScriptableObject
{
    private Dictionary<string, Texture> _nameToTexture = new Dictionary<string, Texture>();

    public void SetAvatar(string name, Texture texture)
    {
        if (_nameToTexture.ContainsKey(name))
        {
            _nameToTexture[name] = texture;
        }
        else
        {
            _nameToTexture.Add(name, texture);
        }
    }

    public Texture GetTextureByName(string name)
    {
        if (_nameToTexture.ContainsKey(name))
        {
            return _nameToTexture[name];
        }

        Debug.LogWarning($"Texture with name {name} not found. Null value will be returned");
        return null;
    }
}
