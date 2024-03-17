using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI fertilizerAmountText;
    [SerializeField] TMPro.TextMeshProUGUI insectAttackingAmountText;
    [SerializeField] TMPro.TextMeshProUGUI insectsAmountText;

    public int insectParts = 0;
    public int insectsAttacking = 0;
    public int fertilizier = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHud();
    }

    public void UpdateHud()
    {
        insectAttackingAmountText.text = insectsAttacking.ToString();
        fertilizerAmountText.text = fertilizier.ToString();
        insectsAmountText.text = insectParts.ToString();
    }
}
