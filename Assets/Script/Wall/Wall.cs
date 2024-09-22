using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Vector2Int index; //x,y 좌표

    //벽이 있는지 여부
    public bool isFrontWall;
    public bool isBackWall;
    public bool isRightWall;
    public bool isLeftWall;

    public GameObject frontWall;
    public GameObject backWall;
    public GameObject RightWall;
    public GameObject LeftWall;

    private void Start()
    {
        SetWall();
    }

    public void SetWall()
    {
        frontWall.SetActive(isFrontWall);
        backWall.SetActive(isBackWall);
        RightWall.SetActive(isRightWall);
        LeftWall.SetActive(isLeftWall);
    }

    public bool CheckAllWall()
    {
        return isFrontWall && isBackWall && isRightWall && isLeftWall;
    }
}
