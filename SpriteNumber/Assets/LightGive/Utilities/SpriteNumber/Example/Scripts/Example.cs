using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
	[SerializeField]
	private SpriteNumber m_spriteNumber;
	[SerializeField]
	private int m_testNum;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			m_spriteNumber.SetNumber(m_testNum);
		}
	}
}
