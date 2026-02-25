using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
[RequireComponent(typeof(Rigidbody))]
public class ZombieChase : MonoBehaviour
{
	// Token: 0x06000061 RID: 97 RVA: 0x0000327C File Offset: 0x0000147C
	private void Start()
	{
		this.player = Camera.main.transform;
		this.rb = base.GetComponent<Rigidbody>();
		this.rb.constraints = RigidbodyConstraints.FreezeRotation;
		this.rb.interpolation = RigidbodyInterpolation.Interpolate;
		this.rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000032CC File Offset: 0x000014CC
	private void FixedUpdate()
	{
		float num = Vector3.Distance(base.transform.position, this.player.position);
		bool flag = this.HasLineOfSight();
		if (num <= this.detectionRange && flag)
		{
			this.isChasing = true;
		}
		else if (num >= this.loseInterestRange || !flag)
		{
			this.isChasing = false;
		}
		if (this.isChasing)
		{
			this.MoveTowardsPlayer();
			this.FacePlayer();
		}
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000333C File Offset: 0x0000153C
	private bool HasLineOfSight()
	{
		Vector3 vector = base.transform.position + Vector3.up * 1.2f;
		Vector3 normalized = (this.player.position - vector).normalized;
		float maxDistance = Vector3.Distance(vector, this.player.position);
		RaycastHit raycastHit;
		return Physics.Raycast(vector, normalized, out raycastHit, maxDistance, this.obstacleMask | this.playerMask) && (1 << raycastHit.collider.gameObject.layer & this.playerMask) != 0;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x000033E0 File Offset: 0x000015E0
	private void MoveTowardsPlayer()
	{
		Vector3 normalized = (this.player.position - this.rb.position).normalized;
		normalized.y = 0f;
		this.rb.MovePosition(this.rb.position + normalized * this.moveSpeed * Time.fixedDeltaTime);
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00003450 File Offset: 0x00001650
	private void FacePlayer()
	{
		Vector3 vector = this.player.position - base.transform.position;
		vector.y = 0f;
		if (vector != Vector3.zero)
		{
			Quaternion rotation = Quaternion.LookRotation(vector);
			this.rb.MoveRotation(rotation);
		}
	}

	// Token: 0x0400005F RID: 95
	[Header("Detection")]
	public float detectionRange = 8f;

	// Token: 0x04000060 RID: 96
	public float loseInterestRange = 12f;

	// Token: 0x04000061 RID: 97
	[Header("Movement")]
	public float moveSpeed = 2.5f;

	// Token: 0x04000062 RID: 98
	[Header("Vision")]
	public LayerMask obstacleMask;

	// Token: 0x04000063 RID: 99
	public LayerMask playerMask;

	// Token: 0x04000064 RID: 100
	private Transform player;

	// Token: 0x04000065 RID: 101
	private bool isChasing;

	// Token: 0x04000066 RID: 102
	private Rigidbody rb;
}
