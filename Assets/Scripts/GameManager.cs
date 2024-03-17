using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI fertilizerAmountText;
    [SerializeField] TMPro.TextMeshProUGUI insectAttackingAmountText;
    [SerializeField] TMPro.TextMeshProUGUI insectsAmountText;
    [SerializeField] FlowerScript flowerScript;
    public GameObject button;

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
        if (insectParts > 3)
            insectParts = 3;
        if (fertilizier > 2)
            fertilizier = 2;

        UpdateHud();

        if (insectsAttacking > 0)
            flowerScript.Shake();
        else
            flowerScript.UnShake();
    }

    public void UpdateHud()
    {
        insectAttackingAmountText.text = insectsAttacking.ToString();
        fertilizerAmountText.text = fertilizier.ToString();
        insectsAmountText.text = insectParts.ToString();
    }
   
}
