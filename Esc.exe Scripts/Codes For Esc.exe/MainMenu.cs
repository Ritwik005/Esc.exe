using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000C RID: 12
public class MainMenu : MonoBehaviour
{
	// Token: 0x06000025 RID: 37 RVA: 0x000025FF File Offset: 0x000007FF
	private void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0000260D File Offset: 0x0000080D
	public void PlayGame()
	{
		SceneManager.LoadScene("Game");
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002619 File Offset: 0x00000819
	public void ExitGame()
	{
		Debug.Log("Exit clicked");
		Application.Quit();
	}
}
