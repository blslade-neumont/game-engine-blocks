﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] public ObjectPool m_objectPool = null;
    [SerializeField] public Game m_game = null;

    public List<Ball> m_balls = new List<Ball>();

    public void CreateBall(Vector3 position, Vector3 direction)
    {
        GameObject gameObject = m_objectPool.GetObject();
        gameObject.transform.parent = transform;
        Ball ball = gameObject.GetComponent<Ball>();
        ball.m_game = this.m_game;
        ball.Initialize(position, direction, Ball.eType.STANDARD, this);
    }

    public void RemoveBall(Ball ball)
    {
        m_balls.Remove(ball);
        m_objectPool.ReturnObject(ball.gameObject);
    }
}
