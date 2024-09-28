using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKey : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite unpressedZ;
    public Sprite pressedZ;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = unpressedZ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            spriteRenderer.sprite = pressedZ;
        }
        if (Input.GetKeyUp("z"))
        {
            spriteRenderer.sprite = unpressedZ;
        }
    }
}
