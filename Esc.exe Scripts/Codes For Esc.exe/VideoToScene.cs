using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

// Token: 0x02000019 RID: 25
public class VideoToScene : MonoBehaviour
{
	// Token: 0x0600005B RID: 91 RVA: 0x000031DB File Offset: 0x000013DB
	private void Start()
	{
		if (this.videoPlayer == null)
		{
			this.videoPlayer = base.GetComponent<VideoPlayer>();
		}
		this.videoPlayer.loopPointReached += this.OnVideoFinished;
		this.videoPlayer.Play();
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00003219 File Offset: 0x00001419
	private void OnVideoFinished(VideoPlayer vp)
	{
		SceneManager.LoadScene(this.nextSceneName);
	}

	// Token: 0x0400005C RID: 92
	[Header("Video")]
	public VideoPlayer videoPlayer;

	// Token: 0x0400005D RID: 93
	[Header("Scene Settings")]
	public string nextSceneName;
}
