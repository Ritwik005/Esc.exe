using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class CameraShake : MonoBehaviour
{
	// Token: 0x06000009 RID: 9 RVA: 0x0000217F File Offset: 0x0000037F
	private void Awake()
	{
		this.originalPos = base.transform.localPosition;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002192 File Offset: 0x00000392
	public void Shake(float duration, float magnitude)
	{
		base.StopAllCoroutines();
		base.StartCoroutine(this.DoShake(duration, magnitude));
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000021A9 File Offset: 0x000003A9
	private IEnumerator DoShake(float duration, float magnitude)
	{
		float elapsed = 0f;
		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * magnitude;
			base.transform.localPosition = this.originalPos + new Vector3(x, 0f, 0f);
			elapsed += Time.deltaTime;
			yield return null;
		}
		base.transform.localPosition = this.originalPos;
		yield break;
	}

	// Token: 0x04000006 RID: 6
	private Vector3 originalPos;
}
