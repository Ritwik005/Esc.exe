using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000011 RID: 17
public class PlayerHealth : MonoBehaviour
{
	// Token: 0x06000037 RID: 55 RVA: 0x00002916 File Offset: 0x00000B16
	private void Start()
	{
		this.currentHits = this.maxHits;
		this.damageOverlay.color = new Color(1f, 0f, 0f, 0f);
		this.UpdateHealthUI();
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002950 File Offset: 0x00000B50
	public void TakeHit()
	{
		if (this.isDead || this.invulnTimer > 0f)
		{
			return;
		}
		this.invulnTimer = this.invulnTime;
		this.currentHits--;
		this.UpdateHealthUI();
		base.StartCoroutine(this.DamageFlash());
		if (this.currentHits <= 0)
		{
			this.Die();
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000029AF File Offset: 0x00000BAF
	private void UpdateHealthUI()
	{
		this.healthFill.fillAmount = (float)this.currentHits / (float)this.maxHits;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000029CB File Offset: 0x00000BCB
	private IEnumerator DamageFlash()
	{
		float timer = 0f;
		while (timer < this.flashDuration)
		{
			timer += Time.deltaTime;
			float a = Mathf.Lerp(this.maxAlpha, 0f, timer / this.flashDuration);
			this.damageOverlay.color = new Color(1f, 0f, 0f, a);
			yield return null;
		}
		this.damageOverlay.color = new Color(1f, 0f, 0f, 0f);
		yield break;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000029DA File Offset: 0x00000BDA
	private void Die()
	{
		this.isDead = true;
		Debug.Log("PLAYER DEAD");
		SceneManager.LoadScene("Failure");
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000029F7 File Offset: 0x00000BF7
	private void Update()
	{
		this.invulnTimer -= Time.deltaTime;
	}

	// Token: 0x0400002D RID: 45
	public int maxHits = 3;

	// Token: 0x0400002E RID: 46
	private int currentHits;

	// Token: 0x0400002F RID: 47
	[Header("Damage Effect")]
	public Image damageOverlay;

	// Token: 0x04000030 RID: 48
	public float flashDuration = 0.15f;

	// Token: 0x04000031 RID: 49
	public float maxAlpha = 0.35f;

	// Token: 0x04000032 RID: 50
	[Header("UI")]
	public Image healthFill;

	// Token: 0x04000033 RID: 51
	private bool isDead;

	// Token: 0x04000034 RID: 52
	[Header("Invulnerability")]
	public float invulnTime = 0.8f;

	// Token: 0x04000035 RID: 53
	private float invulnTimer;
}
