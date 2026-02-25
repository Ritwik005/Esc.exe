using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class FlashlightFlicker : MonoBehaviour
{
	// Token: 0x0600001A RID: 26 RVA: 0x00002458 File Offset: 0x00000658
	private void Start()
	{
		if (this.flashlight == null)
		{
			this.flashlight = base.GetComponent<Light>();
		}
		this.normalIntensity = this.flashlight.intensity;
		base.StartCoroutine(this.FlickerRoutine());
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00002492 File Offset: 0x00000692
	private IEnumerator FlickerRoutine()
	{
		for (;;)
		{
			float seconds = Random.Range(this.minWaitTime, this.maxWaitTime);
			yield return new WaitForSeconds(seconds);
			yield return base.StartCoroutine(this.DoFlicker());
		}
		yield break;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000024A1 File Offset: 0x000006A1
	private IEnumerator DoFlicker()
	{
		int flickers = Random.Range(2, 5);
		int num;
		for (int i = 0; i < flickers; i = num + 1)
		{
			this.flashlight.intensity = this.flickerMinIntensity;
			yield return new WaitForSeconds(this.flickerDuration);
			this.flashlight.intensity = this.normalIntensity;
			yield return new WaitForSeconds(Random.Range(0.05f, 0.15f));
			num = i;
		}
		yield break;
	}

	// Token: 0x04000015 RID: 21
	public Light flashlight;

	// Token: 0x04000016 RID: 22
	[Header("Flicker Settings")]
	public float minWaitTime = 240f;

	// Token: 0x04000017 RID: 23
	public float maxWaitTime = 360f;

	// Token: 0x04000018 RID: 24
	public float flickerMinIntensity = 0.2f;

	// Token: 0x04000019 RID: 25
	public float flickerDuration = 0.15f;

	// Token: 0x0400001A RID: 26
	private float normalIntensity;
}
