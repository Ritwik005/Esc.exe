using System;
using UnityEngine;

// Token: 0x0200001C RID: 28
public class ZombieDamage : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x000034CE File Offset: 0x000016CE
	private void Update()
	{
		this.timer -= Time.deltaTime;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x000034E4 File Offset: 0x000016E4
	private void OnTriggerStay(Collider other)
	{
		if (this.timer > 0f)
		{
			return;
		}
		if (other.CompareTag("Player"))
		{
			PlayerHealth component = other.GetComponent<PlayerHealth>();
			if (component != null)
			{
				component.TakeHit();
				this.timer = this.hitCooldown;
			}
		}
	}

	// Token: 0x04000067 RID: 103
	public float hitCooldown = 1f;

	// Token: 0x04000068 RID: 104
	private float timer;
}
