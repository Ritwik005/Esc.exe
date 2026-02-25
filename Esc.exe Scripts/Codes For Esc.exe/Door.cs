using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Door : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x000021CE File Offset: 0x000003CE
	private void Start()
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
		this.player = ((gameObject != null) ? gameObject.transform : null);
		if (this.player == null)
		{
			Debug.LogError("Player not found! Make sure your player has the tag 'Player'.");
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002204 File Offset: 0x00000404
	private void Update()
	{
		if (this.isOpened || this.player == null)
		{
			return;
		}
		if (Vector3.Distance(base.transform.position, this.player.position) <= this.detectDistance)
		{
			PlayerInventory component = this.player.GetComponent<PlayerInventory>();
			if (component != null && component.HasKey(this.requiredKeyColor))
			{
				Object.Destroy(base.gameObject);
				this.isOpened = true;
			}
		}
	}

	// Token: 0x04000007 RID: 7
	public string requiredKeyColor;

	// Token: 0x04000008 RID: 8
	public float detectDistance = 1f;

	// Token: 0x04000009 RID: 9
	private Transform player;

	// Token: 0x0400000A RID: 10
	private bool isOpened;
}
