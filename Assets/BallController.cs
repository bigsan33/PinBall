using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallController : MonoBehaviour {

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコア合計
    private int scoreSum = 0;


    // Use this for initialization
    void Start() {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update() {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ) {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //スコアを表示
        Text score = this.scoreText.GetComponent<Text>();
        score.text = "Score:" + scoreSum;
    }

    //衝突時に呼ばれる関数
    private void OnCollisionEnter(Collision other) {
        //Debug.Log(other.gameObject.tag);

        //SmallStarTagは10点
        if (other.gameObject.tag == "SmallStarTag") {
            scoreSum += 10;
        }

        //SmallCloudTagは20点
        if (other.gameObject.tag == "SmallCloudTag") {
            scoreSum += 20;
        }

        //LargeStarTagは50点
        if (other.gameObject.tag == "LargeStarTag") {
            scoreSum += 50;
        }

        //LargeCloudTagは100点
        if (other.gameObject.tag == "LargeCloudTag") {
            scoreSum += 100;
        }
    }
}