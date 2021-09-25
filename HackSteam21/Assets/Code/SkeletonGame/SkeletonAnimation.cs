using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    public SkeletonGame skeletonGame;
    private void Start()
    {
        newBone();
    }
    public void newBone()
    {
        skeletonGame.newBone();
    }
}
