using Date;
using UnityEngine;

public class ChoiceIconsScript : MonoBehaviour
{
    public Sprite firstSprite;
    public Sprite secondSprite;
    public Sprite sprit;

    public void ChoiceIcon(int num)
    {
        if (num == 0)
            GameData.sprite = firstSprite;
        if (num== 1)
            GameData.sprite = secondSprite;
    }
}
