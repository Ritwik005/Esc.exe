using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000017 RID: 23
public class TimerBar : MonoBehaviour
{
	// Token: 0x06000053 RID: 83 RVA: 0x000030CD File Offset: 0x000012CD
	private void Start()
	{
		this.currentTime = this.totalTime;
		if (this.timerSlider != null)
		{
			this.timerSlider.maxValue = this.totalTime;
			this.timerSlider.value = this.totalTime;
		}
	}

	// Token: 0x06000054 RID: 84 RVA: 0x0000310C File Offset: 0x0000130C
	private void Update()
	{
		if (this.currentTime > 0f)
		{
			this.currentTime -= Time.deltaTime;
			if (this.timerSlider != null)
			{
				this.timerSlider.value = this.currentTime;
				return;
			}
		}
		else
		{
			this.LoadNextScene();
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x0000315E File Offset: 0x0000135E
	private void LoadNextScene()
	{
		SceneManager.LoadScene(this.nextSceneName);
	}

	// Token: 0x04000056 RID: 86
	[Header("UI")]
	public Slider timerSlider;

	// Token: 0x04000057 RID: 87
	[Header("Timer Settings")]
	public float totalTime = 600f;

	// Token: 0x04000058 RID: 88
	public string nextSceneName;

	// Token: 0x04000059 RID: 89
	private float currentTime;
}
