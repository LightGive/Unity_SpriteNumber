using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteNumber : MonoBehaviour
{
	private const int MinDigit = 1;
	private const int MaxDigit = 10;

	[SerializeField]
	private Sprite[] m_spriteNumbers = new Sprite[10];
	[SerializeField]
	private Sprite m_spriteDot;
	[SerializeField, Range(MinDigit, MaxDigit)]
	private int m_maxDigit = 3;
	[SerializeField]
	private float m_offset = 1.0f;
	[SerializeField]
	private bool m_isDisplayZero;

	private SpriteRenderer[] m_spriteRenderers = new SpriteRenderer[MaxDigit];

	private void Start()
	{
		m_spriteRenderers = new SpriteRenderer[m_maxDigit];
		for (int i = 0; i < m_maxDigit; i++)
		{
			var obj = new GameObject("Number" + i.ToString("0"));
			obj.transform.SetParent(transform);
			m_spriteRenderers[i] = obj.AddComponent<SpriteRenderer>();
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			var ran = Random.Range(0, 99);
			Debug.Log(ran);
			SetNumber(ran);
		}
	}

	public void SetNumber(int _val)
	{
		var digit = _val;

		//要素数0には１桁目の値が格納
		List<int> number = new List<int>();
		while (digit != 0)
		{
			_val = digit % 10;
			digit = digit / 10;
			number.Add(_val);
		}

		//表示
		for (int i = 0; i < m_spriteRenderers.Length; i++)
		{
			if (number.Count <= i && i != number.Count - 1)
			{
				if (m_isDisplayZero)
				{
					m_spriteRenderers[i].gameObject.SetActive(true);
					m_spriteRenderers[i].sprite = m_spriteNumbers[0];
				}
				else
				{
					m_spriteRenderers[i].gameObject.SetActive(false);
				}
			}
			else
			{
				m_spriteRenderers[i].gameObject.SetActive(true);
				m_spriteRenderers[i].sprite = m_spriteNumbers[number[i]];
			}
		}
	}
}
