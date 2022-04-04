using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winUI;
    public ItemBox[] itemBoxes;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        winUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
            // ScenceMangager.LoadScene(0); // 이렇게 게임 씬의 순번을 넣어도 된다.
        }
        if (isGameOver == true)
        {
            return;
        }

        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (itemBoxes[i].isOverlapped == true)
            {
                count++;
            }
        }

        if (count >= 3)
        {
            Debug.Log("게임 승리");
            isGameOver = true;
            winUI.SetActive(true);
        }
    }
}
