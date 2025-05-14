using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour
{
    [SerializeField] private RawImage _avatar;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _body;

    public void Configure(Texture avatar, string name, string body)
    {
        if (avatar != null)
        {
            _avatar.texture = avatar;
        }

        _name.text = name;
        _body.text = body;
    }
}
