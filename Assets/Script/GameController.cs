using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public BoxSpawner boxSpawner;
    public Box currentBox;
    public int score;
    public TextMeshProUGUI scoreText;
    public CameraFollow cameraFollow;
    public int moveCount;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        GetMouseInput();
    }

    void GetMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            currentBox.DropBox();
        }
    }

    public void SpawnNewBox()
    {
        Invoke("NextBox", 1f);
    }
    public void NextBox()
    {
        boxSpawner.SpawnBox();
    }
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void MoveCamera()
    {
        moveCount++;
        if (moveCount == 3)
        {
            moveCount = 0;
            cameraFollow.targetPos.y += 2;
        }
    }
}
