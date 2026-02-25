using System;
using UnityEngine;
using UnityEngine.Video;

// Token: 0x0200000D RID: 13
public class MainMenuVideoController : MonoBehaviour
{
	// Token: 0x06000029 RID: 41 RVA: 0x00002634 File Offset: 0x00000834
	private void Start()
	{
		this.intro.gameObject.SetActive(true);
		this.title.gameObject.SetActive(false);
		this.loop.gameObject.SetActive(false);
		this.intro.loopPointReached += this.OnIntroFinished;
		this.title.loopPointReached += this.OnTitleFinished;
		this.intro.Play();
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000026AD File Offset: 0x000008AD
	private void OnIntroFinished(VideoPlayer vp)
	{
		this.intro.gameObject.SetActive(false);
		this.title.gameObject.SetActive(true);
		this.title.Play();
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000026DC File Offset: 0x000008DC
	private void OnTitleFinished(VideoPlayer vp)
	{
		this.title.gameObject.SetActive(false);
		this.loop.gameObject.SetActive(true);
		this.loop.Play();
		if (!this.menuShown)
		{
			this.menuShown = true;
			if (this.menuFade != null)
			{
				this.menuFade.FadeIn(1f);
			}
		}
	}

	// Token: 0x04000021 RID: 33
	public VideoPlayer intro;

	// Token: 0x04000022 RID: 34
	public VideoPlayer title;

	// Token: 0x04000023 RID: 35
	public VideoPlayer loop;

	// Token: 0x04000024 RID: 36
	public MenuFadeIn menuFade;

	// Token: 0x04000025 RID: 37
	private bool menuShown;
}
