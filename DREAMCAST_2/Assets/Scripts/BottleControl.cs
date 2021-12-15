using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleControl : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    private int _liczbaKropelek;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.liczbaKropelek < sprites.Length)
        {
            _liczbaKropelek = GameController.buteleczka % 48;
            spriteRenderer.sprite = sprites[_liczbaKropelek];
        }
    }
}
