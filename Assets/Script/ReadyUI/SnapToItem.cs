using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnapToItem : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public RectTransform sampleListItem;

    public HorizontalLayoutGroup HLG;

    public TMP_Text NameLabel;
    public string[] ItemNames;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int currentItem = Mathf.RoundToInt((0 - contentPanel.localPosition.x / (sampleListItem.rect.width + HLG.spacing)));
        //Debug.Log(currentItem);

        if (scrollRect.velocity.magnitude < 100)
        {
            contentPanel.localPosition = new Vector3(0 - currentItem * (sampleListItem.rect.width + HLG.spacing), contentPanel.localPosition.y, contentPanel.localPosition.z);
        }

        if (Input.GetKeyDown("d"))
        {
            Debug.Log("下一個畫面test");
            contentPanel.localPosition -= new Vector3(sampleListItem.rect.width + HLG.spacing, 0, 0);
        }
        if (Input.GetKeyDown("a"))
        {
            Debug.Log("下一個畫面test");
            contentPanel.localPosition += new Vector3(sampleListItem.rect.width + HLG.spacing, 0, 0);
        }
    }
}
