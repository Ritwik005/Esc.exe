using System;
using UnityEngine;
using UnityEngine.Video;

// Token: 0x0200001A RID: 26
public class WinCredits : MonoBehaviour
{
	// Token: 0x0600005E RID: 94 RVA: 0x0000322E File Offset: 0x0000142E
	private void Start()
	{
		if (this.videoPlayer == null)
		{
			this.videoPlayer = base.GetComponent<VideoPlayer>();
		}
		this.videoPlayer.loopPointReached += this.OnEnd;
		this.videoPlayer.Play();
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0000326C File Offset: 0x0000146C
	private void OnEnd(VideoPlayer vp)
	{
		Application.Quit();
	}

	// Token: 0x0400005E RID: 94
	[Header("Video")]
	public VideoPlayer videoPlayer;
}
