using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class UIPrompt : MonoBehaviour
{
	// Token: 0x06000057 RID: 87 RVA: 0x0000317E File Offset: 0x0000137E
	private void Awake()
	{
		this.promptText.enabled = false;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x0000318C File Offset: 0x0000138C
	public void Show(string message, float time)
	{
		if (this.currentRoutine != null)
		{
			base.StopCoroutine(this.currentRoutine);
		}
		this.currentRoutine = base.StartCoroutine(this.ShowRoutine(message, time));
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000031B6 File Offset: 0x000013B6
	private IEnumerator ShowRoutine(string message, float time)
	{
		this.promptText.text = message;
		this.promptText.enabled = true;
		yield return new WaitForSeconds(time);
		this.promptText.enabled = false;
		yield break;
	}

	// Token: 0x0400005A RID: 90
	public TMP_Text promptText;

	// Token: 0x0400005B RID: 91
	private Coroutine currentRoutine;
}
