using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLongTentacle : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 5f;

	[SerializeField]
	float frequency = 20f;

	[SerializeField]
	float magnitude = 0.5f;

	bool facingRight = true;

	Vector3 position, localScale;

	// Use this for initialization
	void Start()
	{

		position = transform.position;

		localScale = transform.localScale;

	}

	// Update is called once per frame
	void Update()
	{

		CheckWhereToFace();

		if (facingRight)
			MoveRight();
		else
			MoveLeft();
	}

	void CheckWhereToFace()
	{
		if (position.x < -9f)
			facingRight = true;

		else if (position.x > 9f)
			facingRight = false;

		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;

		transform.localScale = localScale;

	}

	void MoveRight()
	{
		position += transform.right * Time.deltaTime * moveSpeed;
		transform.position = position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

	void MoveLeft()
	{
		position -= transform.right * Time.deltaTime * moveSpeed;
		transform.position = position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
	}

}
