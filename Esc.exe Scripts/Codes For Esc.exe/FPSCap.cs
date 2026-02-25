using System;
using UnityEngine;

// Token: 0x02000009 RID: 9
public class FPSCap : MonoBehaviour
{
	// Token: 0x0600001E RID: 30 RVA: 0x000024E4 File Offset: 0x000006E4
	private void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = this.targetFPS;
	}

	// Token: 0x0400001B RID: 27
	public int targetFPS = 60;
}
