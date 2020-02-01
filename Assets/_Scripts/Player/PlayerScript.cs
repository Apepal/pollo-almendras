using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{

	[SerializeField] private float _speed = 5f;
	[SerializeField] private float _jumpForce;
	private WeaponScript _weapon;

	private bool isPaused = true;
	private bool isGrounded = true;
	

	private float attackTime = 0f;

	private Animator _animator;
	private Rigidbody2D _rigidbody2D;
	
	
	// CONSTANTS
	private static readonly int Attack = Animator.StringToHash("Attack");
	private static readonly string Background = "Background";
	private static readonly int Die = Animator.StringToHash("Die");
	private static readonly int Damage = Animator.StringToHash("Damage");

	// Use this for initialization
	void Start ()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_animator = GetComponentInChildren<Animator>();
		_weapon = GetComponentInChildren<WeaponScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
		if (!isPaused)
		{
			getMovement();
		}
	}

	private void getMovement()
	{
		float moveHorizontal = Input.GetAxisRaw("Horizontal");
		float moveVertical = Input.GetAxisRaw("Vertical");
		_rigidbody2D.velocity = new Vector2(moveHorizontal * _speed, _rigidbody2D.velocity.y);
		transform.localScale = new Vector3(moveHorizontal == 0 ? 1: moveHorizontal, 1, 1);
		_weapon.change(moveVertical);
		
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			_rigidbody2D.velocity = Vector2.up * _jumpForce;
		}

		if (Input.GetKeyDown(KeyCode.V) && attackTime < Time.time)
		{
			_animator.SetTrigger(Attack);
			_weapon.shot();
			attackTime = Time.time + 0.5f;
		}
	}


	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag(Background))
		{
			isGrounded = true;
		}
	}

	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag(Background))
		{
			isGrounded = false;
		}
	}


	public void resetPlayerScrip()
	{
		isPaused = false;
	}


	public void setPaused(bool paused)
	{
		isPaused = paused;
	}

	public void damage()
	{
		_animator.SetTrigger(Damage);
	} 

	public void die()
	{
		_animator.SetTrigger(Die);
	}

	public void moveTo(Vector2 lastPointTransform)
	{
		transform.Translate(lastPointTransform);
	}
}
