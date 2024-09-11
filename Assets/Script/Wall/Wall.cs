using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Vector2Int index;

    public bool isFrontWall;
    public bool isBackWall;
    public bool isRightWall;
    public bool isLeftWall;

    public GameObject frontWall;
    public GameObject backWall;
    public GameObject rightFrontWall;
    public GameObject leftFrontWall;

    void Start()
    {
        SetWall();
    }

    public void SetWall()
    {
        frontWall.SetActive(isFrontWall);
        backWall.SetActive(isBackWall);
        rightFrontWall.SetActive(isLeftWall);
        leftFrontWall.SetActive(isLeftWall);
    }

    public bool CheckAllWall()
    {
        return isFrontWall && isBackWall && isRightWall && isLeftWall;
    }
}
