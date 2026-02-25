using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class KeyPickup : MonoBehaviour
{
	// Token: 0x06000022 RID: 34 RVA: 0x00002529 File Offset: 0x00000729
	private void Start()
	{
		this.uiPrompt = Object.FindObjectOfType<UIPrompt>();
		if (this.uiPrompt == null)
		{
			Debug.LogError("UIPrompt not found in scene!");
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002550 File Offset: 0x00000750
	private void OnTriggerEnter(Collider other)
	{
		if (this.pickedUp)
		{
			return;
		}
		if (other.CompareTag("Player"))
		{
			PlayerInventory component = other.GetComponent<PlayerInventory>();
			if (component != null)
			{
				component.AddKey(this.keyColor);
			}
			if (this.uiPrompt != null)
			{
				this.uiPrompt.Show(this.keyColor + " Key Obtained!", this.displayTime);
			}
			MeshRenderer component2 = base.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			this.pickedUp = true;
			Object.Destroy(base.gameObject, 0.5f);
		}
	}

	// Token: 0x0400001D RID: 29
	[Header("Key Settings")]
	public string keyColor;

	// Token: 0x0400001E RID: 30
	[Header("UI")]
	public float displayTime = 1f;

	// Token: 0x0400001F RID: 31
	private bool pickedUp;

	// Token: 0x04000020 RID: 32
	private UIPrompt uiPrompt;
}
