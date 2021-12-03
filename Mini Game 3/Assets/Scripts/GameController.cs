using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public GameObject Enemy;
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void OnKill()
    {
        score++;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Enemy, transform.position + new Vector3(Random.Range(-1, 1), -1, Random.Range(-1, 1)), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score : {score}";
    }
}
