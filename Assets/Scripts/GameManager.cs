using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeScale = 1;

    public Text scoreText;
    int score;
    public GameObject winPanel;
    int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }

    public void HitEnemy()
    {
        enemyCount--;
        score += 100;
        scoreText.text = $"Á¡¼ö : {score}";

        if (enemyCount <= 0)
        {
            winPanel.SetActive(true);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
