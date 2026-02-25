using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000013 RID: 19
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	// Token: 0x06000041 RID: 65 RVA: 0x00002A90 File Offset: 0x00000C90
	private void Start()
	{
		this.controller = base.GetComponent<CharacterController>();
		this.sprintTimer = this.maxSprintTime;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		this.defaultCamY = this.cameraTransform.localPosition.y;
		if (this.staminaBar != null)
		{
			this.staminaBar.maxValue = this.maxSprintTime;
			this.staminaBar.value = this.sprintTimer;
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00002B07 File Offset: 0x00000D07
	private void Update()
	{
		this.HandleSprint();
		this.HandleMovement();
		this.HandleMouseLook();
		this.HandleHeadBob();
		this.UpdateStaminaUI();
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002B28 File Offset: 0x00000D28
	private void HandleMovement()
	{
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		float d = this.isSprinting ? this.sprintSpeed : this.moveSpeed;
		Vector3 a = base.transform.right * axis + base.transform.forward * axis2;
		this.controller.Move(a * d * Time.deltaTime);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002BA8 File Offset: 0x00000DA8
	private void HandleSprint()
	{
		if (this.cooldownTimer > 0f)
		{
			this.cooldownTimer -= Time.deltaTime;
			this.sprintTimer += this.maxSprintTime / this.sprintCooldown * Time.deltaTime;
			this.isSprinting = false;
			if (this.heavyBreathing != null && !this.heavyBreathing.isPlaying)
			{
				this.heavyBreathing.Play();
			}
		}
		else
		{
			if (this.heavyBreathing != null && this.heavyBreathing.isPlaying)
			{
				this.heavyBreathing.Stop();
			}
			if (Input.GetKey(KeyCode.LeftShift) && this.sprintTimer > 0f)
			{
				this.isSprinting = true;
				this.sprintTimer -= Time.deltaTime;
				if (this.sprintTimer <= 0f)
				{
					this.cooldownTimer = this.sprintCooldown;
				}
			}
			else
			{
				this.isSprinting = false;
				this.sprintTimer += Time.deltaTime * this.CooldownSpeed;
			}
		}
		this.sprintTimer = Mathf.Clamp(this.sprintTimer, 0f, this.maxSprintTime);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002CDC File Offset: 0x00000EDC
	private void HandleMouseLook()
	{
		float d = Input.GetAxis("Mouse X") * this.mouseSensitivity * 100f * Time.deltaTime;
		float num = Input.GetAxis("Mouse Y") * this.mouseSensitivity * 100f * Time.deltaTime;
		this.xRotation -= num;
		this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);
		this.cameraTransform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);
		base.transform.Rotate(Vector3.up * d);
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002D84 File Offset: 0x00000F84
	private void HandleHeadBob()
	{
		if (new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude > 0.1f)
		{
			this.bobTimer += Time.deltaTime * (this.isSprinting ? (this.bobSpeed * 1.5f) : this.bobSpeed);
			float num = Mathf.Sin(this.bobTimer) * this.bobAmount;
			Vector3 localPosition = this.cameraTransform.localPosition;
			localPosition.y = this.defaultCamY + num;
			this.cameraTransform.localPosition = localPosition;
			return;
		}
		this.bobTimer = 0f;
		Vector3 localPosition2 = this.cameraTransform.localPosition;
		localPosition2.y = Mathf.Lerp(localPosition2.y, this.defaultCamY, Time.deltaTime * 5f);
		this.cameraTransform.localPosition = localPosition2;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002E69 File Offset: 0x00001069
	private void UpdateStaminaUI()
	{
		if (this.staminaBar != null)
		{
			this.staminaBar.value = this.sprintTimer;
		}
	}

	// Token: 0x04000037 RID: 55
	[Header("Audio")]
	public AudioSource heavyBreathing;

	// Token: 0x04000038 RID: 56
	[Header("Stamina Cooldown")]
	public float CooldownSpeed = 0.2f;

	// Token: 0x04000039 RID: 57
	[Header("Movement")]
	public float moveSpeed = 5f;

	// Token: 0x0400003A RID: 58
	public float sprintSpeed = 9f;

	// Token: 0x0400003B RID: 59
	[Header("Sprint Settings")]
	public float maxSprintTime = 5f;

	// Token: 0x0400003C RID: 60
	public float sprintCooldown = 3f;

	// Token: 0x0400003D RID: 61
	[Header("Mouse Look")]
	public float mouseSensitivity = 2f;

	// Token: 0x0400003E RID: 62
	public Transform cameraTransform;

	// Token: 0x0400003F RID: 63
	[Header("Head Bob")]
	public float bobSpeed = 6f;

	// Token: 0x04000040 RID: 64
	public float bobAmount = 0.05f;

	// Token: 0x04000041 RID: 65
	[Header("UI")]
	public Slider staminaBar;

	// Token: 0x04000042 RID: 66
	private float xRotation;

	// Token: 0x04000043 RID: 67
	private CharacterController controller;

	// Token: 0x04000044 RID: 68
	private float sprintTimer;

	// Token: 0x04000045 RID: 69
	private float cooldownTimer;

	// Token: 0x04000046 RID: 70
	private bool isSprinting;

	// Token: 0x04000047 RID: 71
	private float defaultCamY;

	// Token: 0x04000048 RID: 72
	private float bobTimer;
}
