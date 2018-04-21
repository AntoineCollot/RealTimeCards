using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public bool isVisible;

    [SerializeField]
    GameObject panelEmpty;

    [SerializeField]
    GameObject panelCard;

    [SerializeField]
    GameObject panelHidden;

    [SerializeField]
    Text textHP;
    [SerializeField]
    Text textPower;
    [SerializeField]
    Text textName;

    public Card card
    {
        set
        {
            panelEmpty.SetActive(value == null);
            panelCard.SetActive(value != null && isVisible);
            panelHidden.SetActive(value != null && !isVisible);

            if (value != null)
            {
                textName.text = value.name;

                textPower.text = value.power.ToString();

                textHP.gameObject.SetActive(value.type == Card.Type.Monster);

                switch (value.type)
                {
                    case Card.Type.Monster:
                        CardMonster cm = (CardMonster)value;
                        textHP.text = cm.hp.ToString();
                        break;
                    case Card.Type.Spell:
                        break;
                    case Card.Type.Environment:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
