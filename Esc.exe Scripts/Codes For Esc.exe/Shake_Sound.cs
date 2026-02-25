using System;
using UnityEngine;

// Token: 0x02000015 RID: 21
public class Shake_Sound : MonoBehaviour
{
	// Token: 0x0600004C RID: 76 RVA: 0x00002F6D File Offset: 0x0000116D
	private void Awake()
	{
		this.audioSource = base.GetComponent<AudioSource>();
		if (this.cameraShake == null)
		{
			Debug.LogWarning("CameraShake reference not set on AudioPlayer!");
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002F94 File Offset: 0x00001194
	private void OnTriggerEnter(Collider other)
	{
		if (this.hasPlayed)
		{
			return;
		}
		if (other.CompareTag("Player"))
		{
			this.audioSource.Play();
			if (this.cameraShake != null)
			{
				this.cameraShake.Shake(this.shakeDuration, this.shakeMagnitude);
			}
			Object.Destroy(base.gameObject, this.audioSource.clip.length);
			this.hasPlayed = true;
		}
	}

	// Token: 0x04000049 RID: 73
	[Header("Camera Shake")]
	public CameraShake cameraShake;

	// Token: 0x0400004A RID: 74
	public float shakeDuration = 0.3f;

	// Token: 0x0400004B RID: 75
	public float shakeMagnitude = 0.2f;

	// Token: 0x0400004C RID: 76
	private bool hasPlayed;

	// Token: 0x0400004D RID: 77
	private AudioSource audioSource;
}
