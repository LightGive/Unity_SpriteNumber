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
	private float m_offset = 0.5f;
	[SerializeField]
	private float m_spriteSize = 1.0f;
	[SerializeField]
	private bool m_isDisplayZero;
	[SerializeField]
	private TextAlignment m_defaultTextAnchor;

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


	public void SetNumber(int _val)
	{
		SetNumber(_val, m_defaultTextAnchor);
	}

	public void SetNumber(int _val, TextAlignment _alignment)
	{
		_val = Mathf.Clamp(_val, 0, (int)Mathf.Pow(10, m_maxDigit) - 1);
		var digit = _val;
		int displayCount = 0;

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
				if (m_isDisplayZero || i == 0)
				{
					displayCount++;
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
				displayCount++;
				m_spriteRenderers[i].gameObject.SetActive(true);
				m_spriteRenderers[i].sprite = m_spriteNumbers[number[i]];
			}
		}

		float alignmentOffset = 0.0f;

		switch (_alignment)
		{
			case TextAlignment.Left:
				alignmentOffset = (displayCount * m_spriteSize) + (-m_spriteSize * 0.5f) + (m_offset * (displayCount - 1));
				break;
			case TextAlignment.Center:
				alignmentOffset = (-m_spriteSize * 0.5f) + (m_spriteSize * (displayCount - 1)) + ((m_offset * 0.5f) * (displayCount - 1));
				break;
			case TextAlignment.Right:
				alignmentOffset = -m_spriteSize * 0.5f;
				break;
		}

		//座標を変更する
		for (int i = 0; i < m_spriteRenderers.Length; i++)
		{
			if (m_spriteRenderers[i] == null)
				continue;

			m_spriteRenderers[i].transform.localPosition = new Vector3((-i * (m_spriteSize)) + (-i * m_offset) + alignmentOffset, 0.0f, 0.0f);
		}
	}
}
