using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshBlink : MonoBehaviour
{
	public enum MeshBlinkMode
	{
		colorPingPong,
		alphaPingPong
	}
	private float currentAlpha = 1f;
	private bool toDown = true;
	private List<Renderer> renders = new List<Renderer>();
	
	public MeshBlinkMode mode = MeshBlinkMode.colorPingPong;
	public Color color0 = Color.grey;
	public Color color1 = Color.white;
	public float duration = 1f;
	
	void Start()
	{
		if (renders.Count == 0) Refresh();
	}
	
	void Update()
	{
		if (renders.Count == 0) Refresh();
		
		switch (mode)
		{
		case MeshBlinkMode.colorPingPong:
			if (duration < 0f) duration = 0f;
			float f = Mathf.PingPong(Time.time, duration);
			foreach (Renderer r in renders)
			{
				if (r != null) r.material.color = Color.Lerp(color0, color1, f);
			}
			break;
			
		case MeshBlinkMode.alphaPingPong:
			if (toDown)
			{
				currentAlpha -= duration;
			}
			else
			{
				currentAlpha += duration;
			}
			
			if (currentAlpha <= 0f)
			{
				toDown = false;
			}
			else if (currentAlpha >= 1f)
			{
				toDown = true;
			}
			
			foreach (Renderer r in renders)
			{
				if (r != null)
				{
					color0 = r.material.color;
					color0.a = currentAlpha;
					r.material.color = color0;
				}
			}
			break;
		}
	}
	
	private void Refresh()
	{
		if (gameObject.GetComponent<Renderer>() != null)
		{
			renders.Add(gameObject.GetComponent<Renderer>());
		}
		foreach (Renderer tmp in GetComponentsInChildren<Renderer>())
		{
			renders.Add(tmp);
		}
	}
	
	public void ResetColor()
	{
		foreach (Renderer r in renders)
		{
			if (r != null) r.material.color = color1;
		}
	}
}