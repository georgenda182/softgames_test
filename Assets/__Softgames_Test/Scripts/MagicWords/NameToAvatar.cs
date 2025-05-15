using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MagicWords/NameToAvatar", fileName = "NameToAvatar")]
public class NameToAvatar : ScriptableObject
{
    [SerializeField] private DefinedAvatar _defaultAvatar;

    private Dictionary<string, DefinedAvatar> _nameToTexture = new Dictionary<string, DefinedAvatar>();

    public void SetAvatar(string name, Texture texture, string position)
    {
        if (_nameToTexture.ContainsKey(name))
        {
            _nameToTexture[name] = new DefinedAvatar(texture, position);
        }
        else
        {
            _nameToTexture.Add(name, new DefinedAvatar(texture, position));
        }
    }

    public DefinedAvatar GetAvatarByName(string name)
    {
        if (_nameToTexture.TryGetValue(name, out DefinedAvatar avatar))
        {
            return avatar;
        }

        Debug.LogWarning($"Avatar with name {name} not found. Default avatar will be returned");
        return _defaultAvatar;
    }
}
