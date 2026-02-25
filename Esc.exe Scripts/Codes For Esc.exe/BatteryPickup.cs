using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class BatteryPickup : MonoBehaviour
{
	// Token: 0x06000007 RID: 7 RVA: 0x0000212C File Offset: 0x0000032C
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			FlashlightBattery flashlightBattery = Object.FindObjectOfType<FlashlightBattery>();
			if (flashlightBattery != null)
			{
				flashlightBattery.RechargeBattery(this.rechargePercent);
			}
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04000005 RID: 5
	public float rechargePercent = 0.5f;
}
