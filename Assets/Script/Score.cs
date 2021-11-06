using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text text;
    public static int score;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "점수 : " + score.ToString();
    }
}
