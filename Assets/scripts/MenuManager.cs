using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    
    public GameObject SpecialPanel;

    public void OpenSpecialPanel() {
        SpecialPanel.SetActive(true);
    }

    public void CloseSpecialPanel() {
        SpecialPanel.SetActive(false);
    }

}
