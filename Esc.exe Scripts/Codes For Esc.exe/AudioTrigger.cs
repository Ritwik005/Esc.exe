using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class AudioTrigger : MonoBehaviour
{
	// Token: 0x06000004 RID: 4 RVA: 0x000020B8 File Offset: 0x000002B8
	private void OnTriggerEnter(Collider other)
	{
		if (this.hasTriggered)
		{
			return;
		}
		if (other.CompareTag("Player"))
		{
			if (this.targetAudio != null)
			{
				this.hasTriggered = true;
				this.targetAudio.Play();
				base.StartCoroutine(this.DestroyAfterSound());
				return;
			}
			Debug.LogWarning("AudioSource not assigned!");
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002113 File Offset: 0x00000313
	private IEnumerator DestroyAfterSound()
	{
		yield return new WaitForSeconds(this.targetAudio.clip.length);
		Object.Destroy(this.targetAudio.gameObject);
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000003 RID: 3
	[Header("Audio Source Object")]
	public AudioSource targetAudio;

	// Token: 0x04000004 RID: 4
	private bool hasTriggered;
}
