using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI fertilizerAmountText;
    [SerializeField] TMPro.TextMeshProUGUI insectsAmountText;

    public int insectParts = 0;
    public int fertilizier = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHud();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHud()
    {
        fertilizerAmountText.text = fertilizier.ToString();
        insectsAmountText.text = insectParts.ToString();
    }
}
