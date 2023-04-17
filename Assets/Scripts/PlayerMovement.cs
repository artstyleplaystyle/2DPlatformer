using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _highJump;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Animator animation;
    private SpriteRenderer sprite;

    void Start()
    {
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _highJump);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (Input.GetKey(KeyCode.D) == true)
        {
            animation.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            animation.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            animation.SetBool("running", false);
        }
    }
}
