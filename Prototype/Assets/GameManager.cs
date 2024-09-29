using UnityEngine;
using UnityEngine.UI;  
using TMPro;         

public class GameManager : MonoBehaviour
{
    public GameObject winPanel; 
    public TextMeshProUGUI winText; 

    void Start()
    {
        
        winPanel.SetActive(false);
    }

    // 调用这个方法来显示弹窗
    public void ShowWinPanel()
    {
        winText.text = "You Win!"; 
        winPanel.SetActive(true);  
    }

    // 其他游戏逻辑...
}
