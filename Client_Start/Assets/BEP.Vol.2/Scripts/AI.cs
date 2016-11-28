﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour
{
    //V = k * m + b //速度与质量关系式
    private float MoveSpeed_k = 10.0f;//k = 10 / r
    private float MoveSpeed_b = 2.0f;
    public float force = 20.0f;

    private float angle = 0f;  
    public float keepwatchDis = 3;//半径为3的区域是否有雪球
    private GameObject player;
    private const float MAX_DIS = 100000.0f;
    private bool isautoForce = true;//是否主动添加一个力

    void Start()
    {
        angle = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<Food>().IsOnGround())
        {
            return;
        }

        ChangeForce();

        force = MoveSpeed_k / this.GetComponent<Transform>().localScale.x + MoveSpeed_b;
        force *= 6.0f;

        if (!this.GetComponent<Food>().IsOnGround())
        {
            //log.logHelper.DebugLog("玩家不在地上,不加力");
            return;
        }
        //添加力
        if (isautoForce) this.GetComponent<Rigidbody>().AddForce(new Vector3(force * Mathf.Cos(angle), 0, force * Mathf.Sin(angle)));
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
        MoveSpeed_k = player.GetComponent<Player>().MoveSpeed_k;
        MoveSpeed_b = player.GetComponent<Player>().MoveSpeed_b;
    }

    private int auto_relive_seconds = 3;
    private float totalTime = 0;
    private void ChangeForce()//3s中改变一次力的方向
    {
        //累加每帧消耗时间
        totalTime += Time.deltaTime;
        if (totalTime >= 1)//每过1秒执行一次
        {
            auto_relive_seconds--;           
            totalTime = 0;
        }

        //自动复活
        if (0 == auto_relive_seconds)
        {
            angle = Random.Range(0, 360);
            auto_relive_seconds = 3;
        }
    }
}