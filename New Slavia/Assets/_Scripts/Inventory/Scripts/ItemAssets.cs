using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite AppleSprite;
    public Sprite BullHeartSprite;
    public Sprite ShadowInABottleSprite;
    public Sprite BirchLeavesSprite;
    public Sprite SnakeSkinSprite;
    public Sprite PigeonFeatherSprite;
    public Sprite MagnetSprite;
    public Sprite FireOpal;
    public Sprite SandClock;
    public Sprite MagicBook;
    public Sprite LuckyCoin;
}