using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //スコアを初期化
    int score = 0;
    // オブジェクト衝突時の得点の配列を初期化する
    int[] points = { 10, 20, 30, 40};

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;
    //ゲームのスコアを表示するテキスト
    private GameObject scoreText;
    //ゲームでの衝突した他のオブジェクトの情報を初期化
    private GameObject Other; 

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
        
        //ScoreTextにスコアを表示
        this.scoreText.GetComponent<Text>().text = "Score:" + score;
    }
    void OnCollisionEnter(Collision other)
    {
        //衝突時他のオブジェクトを取得
        this.Other = other.gameObject;

        if (Other.tag == "SmallStarTag") 
        {
            score += points[0];
            this.scoreText.GetComponent<Text>().text = "Score:" + score;

        }
        else if (Other.tag == "LargeStarTag")
        {
            score += points[1];
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }
        else if (Other.tag == "SmallCloudTag")
        {
            score += points[2];
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }
        else if (Other.tag == "LargeCloudTag")
        {
            score += points[3];
            this.scoreText.GetComponent<Text>().text = "Score:" + score;
        }
    }
    // Update is called once per frame
    void Update()
    {
       

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }
}
