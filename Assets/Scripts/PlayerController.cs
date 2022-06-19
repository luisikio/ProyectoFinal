using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _renderer;
        private Animator _animator;
       
        
        public float JumpForce = 10;
        public float velocity = 10;
        
        private static readonly int right = 1;
        private static readonly int left = -1;
        
          
        private static readonly int Animation_idle = 0;
        private static readonly int Animation_run = 1;
        
    void Start()
    { _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        ChangeAnimation(Animation_idle);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(right);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(left);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up*JumpForce,ForceMode2D.Impulse);
         //   ChangeAnimation(Animation_jump);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
          //  ChangeAnimation(Animation_slide);
        }
        if (Input.GetKeyUp(KeyCode.X))
        { 
           // Disparar();
         //   ChangeAnimation(Animation_shoot);
        }
    }
    private void Desplazarse(int position)
    {
        _rigidbody2D.velocity = new Vector2(velocity * position, _rigidbody2D.velocity.y);
        _renderer.flipX = position == left;
        ChangeAnimation(Animation_run);
    }
    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger("Estado",animation);
    }
}
