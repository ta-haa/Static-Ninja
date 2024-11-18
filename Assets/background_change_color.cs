using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_change_color : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color[] colors = { new Color(1f, 0f, 0f, 120f / 255f), Color.white, new Color(0f, 1f, 190f / 255f, 120f / 255f), new Color(0f, 1f, 141f / 255f, 120f / 255f), Color.red };
    private int currentColorIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            spriteRenderer.color = colors[currentColorIndex];
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            yield return new WaitForSeconds(30f);
        }
    }
}
