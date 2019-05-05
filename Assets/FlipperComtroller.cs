using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlipperComtroller : MonoBehaviour {
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;


    // Start is called before the first frame update
    void Start() {
        //HingJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        //Debug.Log("Screen Width : " + Screen.width);
    }

    // Update is called once per frame
    void Update() {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }

        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.defaultAngle);
        }

        //タッチ操作
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);

            //タッチ開始
            if (touch.phase == TouchPhase.Began) {

                //左矢印キーを押した時左フリッパーを動かす
                if (touch.position.x <= Screen.width / 2 && tag == "LeftFripperTag") {
                    SetAngle(this.flickAngle);
                    //Vector2 pos = touch.position;

                    //float x = Input.GetTouch(i).position.x;
                    //Debug.Log(x);
                    //Debug.Log(tag);
                }
                //右矢印キーを押した時右フリッパーを動かす
                if (touch.position.x > Screen.width / 2 && tag == "RightFripperTag") {
                    SetAngle(this.flickAngle);

                    //float x = Input.GetTouch(i).position.x;
                    //Debug.Log(x);
                    //Debug.Log(tag);
                }
            }

            //タッチ終了
            if (touch.phase == TouchPhase.Ended) {

                //矢印キー離された時フリッパーを元に戻す
                if (touch.position.x <= Screen.width / 2 && tag == "LeftFripperTag") {
                    SetAngle(this.defaultAngle);
                }
                if (touch.position.x > Screen.width / 2 && tag == "RightFripperTag") {
                    SetAngle(this.defaultAngle);
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle) {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
 }