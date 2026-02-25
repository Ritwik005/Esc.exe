using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
[ExecuteAlways]
public class Pixelation : MonoBehaviour
{
	// Token: 0x06000035 RID: 53 RVA: 0x00002858 File Offset: 0x00000A58
	private void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		float num = (float)src.width / (float)src.height;
		int num2 = Mathf.RoundToInt((float)this.verticalResolution * num);
		if (this.lowResTex == null || this.lowResTex.width != num2 || this.lowResTex.height != this.verticalResolution)
		{
			if (this.lowResTex != null)
			{
				this.lowResTex.Release();
			}
			this.lowResTex = new RenderTexture(num2, this.verticalResolution, 0);
			this.lowResTex.filterMode = FilterMode.Point;
		}
		Graphics.Blit(src, this.lowResTex);
		Graphics.Blit(this.lowResTex, dest);
	}

	// Token: 0x0400002B RID: 43
	[Range(64f, 480f)]
	public int verticalResolution = 180;

	// Token: 0x0400002C RID: 44
	private RenderTexture lowResTex;
}
