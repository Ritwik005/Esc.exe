using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x0200000F RID: 15
public class MenuHoverBold : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	// Token: 0x06000031 RID: 49 RVA: 0x000027E5 File Offset: 0x000009E5
	private void Awake()
	{
		this.text = base.GetComponent<TMP_Text>();
		this.normalColor = this.text.color;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002804 File Offset: 0x00000A04
	public void OnPointerEnter(PointerEventData eventData)
	{
		this.text.fontStyle = FontStyles.Bold;
		this.text.color = this.hoverColor;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002823 File Offset: 0x00000A23
	public void OnPointerExit(PointerEventData eventData)
	{
		this.text.fontStyle = FontStyles.Normal;
		this.text.color = this.normalColor;
	}

	// Token: 0x04000028 RID: 40
	private TMP_Text text;

	// Token: 0x04000029 RID: 41
	private Color normalColor;

	// Token: 0x0400002A RID: 42
	public Color hoverColor = Color.white;
}
