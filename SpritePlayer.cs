using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
	private SpriteRenderer sprite;

	private bool facingRight; //направление

	void start()
	{
		facingRight = true; 
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal"); //если нажата кнопка движения

		Flip(horizontal);
	}

	private void Flip(float horizontal) //отзеркаливание
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight; 

			Vector3 theScale = transform.localScale;

			theScale.x *= -1; 

			transform.localScale = theScale;
		}
	}
}
