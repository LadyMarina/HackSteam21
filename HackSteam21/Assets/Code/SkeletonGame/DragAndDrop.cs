using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    private float starttingPosX;
    private float starttingPosY;

    private float firstPositonX;
    private float firstPositonY;
    private bool isBeingHeld = false;
    public SkeletonGame skeletonGame;
    public Text scoreText;

    private void Start()
    {
        firstPositonX = transform.localPosition.x;
        firstPositonY = transform.localPosition.y;


    }
    private void Update()
    {
        if (isBeingHeld == true)
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x-starttingPosX, mousePos.y-starttingPosY,0);  
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            starttingPosX = mousePos.x - transform.localPosition.x;
            starttingPosY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
        
    }
    private void OnMouseUp()
    {
        isBeingHeld = false;
        this.gameObject.transform.localPosition = new Vector3(firstPositonX, firstPositonY, 0);
        skeletonGame.newBoneToFix = true;
        skeletonGame.score += 5;
        scoreText.text = skeletonGame.score.ToString();
    }
}
