using System;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class SettingsManager : MonoBehaviour
{
	// Token: 0x06000049 RID: 73 RVA: 0x00002EF7 File Offset: 0x000010F7
	public void SetFPS(int fps)
	{
		Application.targetFrameRate = fps;
		PlayerPrefs.SetInt("FPS", fps);
		PlayerPrefs.Save();
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00002F10 File Offset: 0x00001110
	public void SetResolution(int height)
	{
		int width = 0;
		if (height == 480)
		{
			width = 854;
		}
		else if (height == 720)
		{
			width = 1280;
		}
		else if (height == 1080)
		{
			width = 1920;
		}
		Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow);
		PlayerPrefs.SetInt("ResolutionHeight", height);
		PlayerPrefs.Save();
	}
}
