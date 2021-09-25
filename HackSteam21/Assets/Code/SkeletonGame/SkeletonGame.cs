using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonGame : MonoBehaviour
{
    public SpriteRenderer[] bonesToFix;
    public int randomNumer;
    public bool newBoneToFix=true;
    private int lastBone;
    public Animator animatorSkeleton;
    public Texture2D[] bonesOptionsImage;
    public SpriteRenderer[] bonesButton;
    private int[] bonesDone=new int[3];
    public int score;

    void Start()
    {
        randomNumer = Random.Range(0, bonesToFix.Length);
        lastBone = randomNumer;
    }


    void Update()
    {
        if (newBoneToFix)
        {
            animatorSkeleton.SetBool("Finish", true);
        }
    }

    public void newBone()
    {
        while (randomNumer == lastBone)
        {
            randomNumer = Random.Range(0, bonesToFix.Length);
        }
        lastBone = randomNumer;
        

        for (int i = 0; i < bonesToFix.Length; i++)
        {
            bonesToFix[i].color = new Color(255, 255, 255);
        }
        for (int i = 0; i < bonesDone.Length; i++)
        {
            bonesDone[i] = -1;
        }
        bonesDone[0] = lastBone;
        for (int i = 0; i < bonesButton.Length; i++)
        {
            
            int randomOption = Random.Range(0, bonesOptionsImage.Length);
            while ((randomOption == bonesDone[1] || randomOption == bonesDone[2]) && randomOption==bonesDone[0])
            {
                randomOption = Random.Range(0, bonesOptionsImage.Length);
            }
            bonesDone[i] = randomOption;
            Texture2D textureOne = bonesOptionsImage[Random.Range(0, bonesOptionsImage.Length)];
            bonesButton[i].sprite = Sprite.Create(textureOne, new Rect(0, 0, textureOne.width, textureOne.height), Vector2.zero);
        }
        Texture2D textureTwo = bonesOptionsImage[lastBone];
        bonesButton[Random.Range(0, bonesButton.Length)].sprite = Sprite.Create(textureTwo, new Rect(0, 0, textureTwo.width, textureTwo.height), Vector2.zero);
        bonesToFix[randomNumer].color = Color.red;
        newBoneToFix = false;
        animatorSkeleton.SetBool("Finish", false);
    }
}
