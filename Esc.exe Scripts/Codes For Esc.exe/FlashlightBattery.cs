using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000007 RID: 7
[RequireComponent(typeof(Light))]
public class FlashlightBattery : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x00002293 File Offset: 0x00000493
	private void Start()
	{
		this.flashLight = base.GetComponent<Light>();
		this.defaultIntensity = this.flashLight.intensity;
		this.currentBattery = this.maxBatteryLife;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000022BE File Offset: 0x000004BE
	private void Update()
	{
		this.DrainBattery();
		this.HandleFlicker();
		this.HandleLightState();
		this.UpdateBatteryUI();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000022D8 File Offset: 0x000004D8
	private void DrainBattery()
	{
		if (this.flashLight.enabled && this.currentBattery > 0f)
		{
			this.currentBattery -= Time.deltaTime;
			this.currentBattery = Mathf.Clamp(this.currentBattery, 0f, this.maxBatteryLife);
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000232D File Offset: 0x0000052D
	private void HandleLightState()
	{
		if (this.currentBattery <= 0f)
		{
			this.flashLight.enabled = false;
		}
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002348 File Offset: 0x00000548
	private void HandleFlicker()
	{
		if (this.currentBattery / this.maxBatteryLife <= this.lowBatteryThreshold && this.currentBattery > 0f && !this.isFlickering)
		{
			base.StartCoroutine(this.FlickerRoutine());
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002381 File Offset: 0x00000581
	private IEnumerator FlickerRoutine()
	{
		this.isFlickering = true;
		while (this.currentBattery > 0f && this.currentBattery / this.maxBatteryLife <= this.lowBatteryThreshold)
		{
			this.flashLight.intensity = Random.Range(this.flickerMinIntensity, this.defaultIntensity);
			yield return new WaitForSeconds(Random.Range(0.02f, this.flickerSpeed));
		}
		this.flashLight.intensity = this.defaultIntensity;
		this.isFlickering = false;
		yield break;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002390 File Offset: 0x00000590
	public void RechargeBattery(float percent)
	{
		float num = this.maxBatteryLife * percent;
		this.currentBattery += num;
		this.currentBattery = Mathf.Clamp(this.currentBattery, 0f, this.maxBatteryLife);
		if (!this.flashLight.enabled)
		{
			this.flashLight.enabled = true;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000023E9 File Offset: 0x000005E9
	public float BatteryPercent()
	{
		return this.currentBattery / this.maxBatteryLife;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000023F8 File Offset: 0x000005F8
	private void UpdateBatteryUI()
	{
		if (this.batterySlider != null)
		{
			this.batterySlider.value = this.BatteryPercent();
		}
	}

	// Token: 0x0400000B RID: 11
	[Header("UI")]
	public Slider batterySlider;

	// Token: 0x0400000C RID: 12
	[Header("Battery Settings")]
	[Tooltip("Total battery life in seconds (300 = 5 minutes)")]
	public float maxBatteryLife = 300f;

	// Token: 0x0400000D RID: 13
	[Tooltip("How much battery is restored by pickup (0.5 = 50%)")]
	[Range(0f, 1f)]
	public float pickupRechargePercent = 0.5f;

	// Token: 0x0400000E RID: 14
	[Header("Low Battery Flicker")]
	public float lowBatteryThreshold = 0.15f;

	// Token: 0x0400000F RID: 15
	public float flickerMinIntensity = 0.2f;

	// Token: 0x04000010 RID: 16
	public float flickerSpeed = 0.05f;

	// Token: 0x04000011 RID: 17
	private float currentBattery;

	// Token: 0x04000012 RID: 18
	private Light flashLight;

	// Token: 0x04000013 RID: 19
	private float defaultIntensity;

	// Token: 0x04000014 RID: 20
	private bool isFlickering;
}
