using Unity.VisualScripting;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public Transform hpBarGrid;
    public HpItemUI hpItemUI;
    public static GUIManager Instance;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
		gameOverUI.SetActive(true);
    }
	public void GameWin()
	{
		gameWinUI.SetActive(true);
	}
	public void DrawHpBarGrid(int curHp, int maxHp)
    {
        ClearChilds(hpBarGrid);

        for (int i = 1; i <= maxHp; i++)
        {
            var hpItemUIClone = Instantiate(hpItemUI, Vector3.zero, Quaternion.identity);
            hpItemUIClone.transform.SetParent(hpBarGrid);
            hpItemUIClone.transform.localScale = Vector3.one;
            hpItemUIClone.transform.localPosition = Vector3.zero;

            if (i > curHp)
            {
                hpItemUIClone.UpdateUI(false);
            }
            else
            {
                hpItemUIClone.UpdateUI();
            }
        }
    }
    public void ClearChilds(Transform root)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            var child = root.GetChild(i);

            if (!child) continue;

            Destroy(child.gameObject);
        }
    }
}
