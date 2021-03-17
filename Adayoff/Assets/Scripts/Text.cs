using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{

    private Image bg;
    private float colorAlpha;
    // Start is called before the first frame update
    void Start()
    {
        bg = gameObject.GetComponent<Image>();
        colorAlpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorAlpha >= 0)
        {
            colorAlpha -= Time.deltaTime / 2;
            bg.color = new Color(0, 0, 0, colorAlpha);
        }
    }
}
