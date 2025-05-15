using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup _layout;
    [SerializeField] private RawImage _avatarImg;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _body;

    public void Configure(DefinedAvatar avatar, string name, string body)
    {
        _layout.reverseArrangement = avatar.IsRightPosition;

        _avatarImg.texture = avatar.Texture;
        _name.text = name;

        _body.text = body;
        _body.alignment = avatar.IsRightPosition ? TextAlignmentOptions.MidlineRight : TextAlignmentOptions.MidlineLeft;
    }
}
