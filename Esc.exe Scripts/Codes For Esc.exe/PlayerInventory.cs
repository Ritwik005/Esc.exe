using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000012 RID: 18
public class PlayerInventory : MonoBehaviour
{
	// Token: 0x0600003E RID: 62 RVA: 0x00002A3B File Offset: 0x00000C3B
	public void AddKey(string color)
	{
		if (!this.keys.Contains(color))
		{
			this.keys.Add(color);
			Debug.Log("Picked up " + color + " key!");
		}
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002A6D File Offset: 0x00000C6D
	public bool HasKey(string color)
	{
		return this.keys.Contains(color);
	}

	// Token: 0x04000036 RID: 54
	private HashSet<string> keys = new HashSet<string>();
}
