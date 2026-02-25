using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class TextGlitch : MonoBehaviour
{
	// Token: 0x0600004F RID: 79 RVA: 0x00003027 File Offset: 0x00001227
	private void Awake()
	{
		this.text = base.GetComponent<TMP_Text>();
		this.originalColor = this.text.color;
		this.originalPosition = this.text.transform.localPosition;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x0000305C File Offset: 0x0000125C
	private void Update()
	{
		if (!this.isGlitching && Random.value < this.glitchChance)
		{
			base.StartCoroutine(this.GlitchRoutine());
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003080 File Offset: 0x00001280
	private IEnumerator GlitchRoutine()
	{
		this.isGlitching = true;
		this.text.color = this.glitchColor;
		this.text.transform.localPosition = this.originalPosition + new Vector3(Random.Range(-this.positionOffset.x, this.positionOffset.x), Random.Range(-this.positionOffset.y, this.positionOffset.y), 0f);
		yield return new WaitForSeconds(this.glitchDuration);
		this.text.color = this.originalColor;
		this.text.transform.localPosition = this.originalPosition;
		this.isGlitching = false;
		yield break;
	}

	// Token: 0x0400004E RID: 78
	private TMP_Text text;

	// Token: 0x0400004F RID: 79
	[Header("Glitch Settings")]
	public float glitchChance = 0.02f;

	// Token: 0x04000050 RID: 80
	public float glitchDuration = 0.05f;

	// Token: 0x04000051 RID: 81
	public Color glitchColor = Color.red;

	// Token: 0x04000052 RID: 82
	public Vector2 positionOffset = new Vector2(2f, 2f);

	// Token: 0x04000053 RID: 83
	private Color originalColor;

	// Token: 0x04000054 RID: 84
	private Vector3 originalPosition;

	// Token: 0x04000055 RID: 85
	private bool isGlitching;
}
