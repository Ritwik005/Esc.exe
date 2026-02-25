using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000A RID: 10
public class GameEnder : MonoBehaviour
{
	// Token: 0x06000020 RID: 32 RVA: 0x00002507 File Offset: 0x00000707
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			SceneManager.LoadScene(this.sceneToLoad);
		}
	}

	// Token: 0x0400001C RID: 28
	[Header("Scene Settings")]
	public string sceneToLoad;
}
