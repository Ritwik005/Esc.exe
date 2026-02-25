using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class MenuFadeIn : MonoBehaviour
{
	// Token: 0x0600002D RID: 45 RVA: 0x0000274C File Offset: 0x0000094C
	private void Awake()
	{
		this.group = base.GetComponent<CanvasGroup>();
		if (this.group == null)
		{
			this.group = base.gameObject.AddComponent<CanvasGroup>();
		}
		this.group.alpha = 0f;
		this.group.interactable = false;
		this.group.blocksRaycasts = false;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000027AC File Offset: 0x000009AC
	public void FadeIn(float delay = 0f)
	{
		base.StartCoroutine(this.FadeRoutine(delay));
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000027BC File Offset: 0x000009BC
	private IEnumerator FadeRoutine(float delay)
	{
		if (delay > 0f)
		{
			yield return new WaitForSeconds(delay);
		}
		this.group.interactable = true;
		this.group.blocksRaycasts = true;
		while (this.group.alpha < 1f)
		{
			this.group.alpha += Time.deltaTime * this.fadeSpeed;
			yield return null;
		}
		this.group.alpha = 1f;
		yield break;
	}

	// Token: 0x04000026 RID: 38
	public float fadeSpeed = 1.5f;

	// Token: 0x04000027 RID: 39
	private CanvasGroup group;
}
