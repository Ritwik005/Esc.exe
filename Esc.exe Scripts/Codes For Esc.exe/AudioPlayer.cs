using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
public class AudioPlayer : MonoBehaviour
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Awake()
	{
		this.audioSource = base.GetComponent<AudioSource>();
	}

	// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
	private void OnTriggerEnter(Collider other)
	{
		if (this.hasPlayed)
		{
			return;
		}
		if (other.CompareTag("Player"))
		{
			this.audioSource.Play();
			Object.Destroy(base.gameObject, this.audioSource.clip.length);
			this.hasPlayed = true;
		}
	}

	// Token: 0x04000001 RID: 1
	private bool hasPlayed;

	// Token: 0x04000002 RID: 2
	private AudioSource audioSource;
}
