using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLights : MonoBehaviour
{
    private SpriteRenderer sR;

    public Sprite im1;
    public Sprite im2;
    public Sprite im3;

    private int currentIndex;

    private List<Sprite> imgList;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeLights", 0.4f, 0.4f);
        sR = GetComponent<SpriteRenderer>();
        imgList = new List<Sprite>();
        imgList.Add(im1);
        imgList.Add(im2);
        imgList.Add(im3);

        currentIndex = 0;
    }

    // Update is called once per frame
    void changeLights()
    {
        if (currentIndex == 2)
            currentIndex = 0;
        else
            currentIndex++;

        sR.sprite = imgList[currentIndex];
    }
}
