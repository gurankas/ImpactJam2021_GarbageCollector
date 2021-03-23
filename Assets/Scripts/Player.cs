using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Players _player;
    [SerializeField]
    private float _speed = 5.0f;

    private void Update()
    {
        //Player 1 controls
        if (_player == Players.Player1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector2.up * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector2.down * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * Time.deltaTime * _speed);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Do Action here
            }
        }

        //Player 2 controls
        if (_player == Players.Player2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector2.up * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector2.down * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * Time.deltaTime * _speed);
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Do Action here
            }
        }
    }
}

enum Players
{
    Player1,
    Player2
}
