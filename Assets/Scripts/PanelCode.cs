using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodeEntryPanelTMP : MonoBehaviour
{
   
    [SerializeField] private TextMeshProUGUI[] digitTexts = new TextMeshProUGUI[4];

    [SerializeField] private Button[] incrementButtons = new Button[4];

    [SerializeField] private Button[] decrementButtons = new Button[4];

    [SerializeField] private string targetCode = "1880";

    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject finalObject;

    private int[] digits = new int[4];

    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            int idx = i;
            digits[idx] = 0;
            UpdateText(idx);

            incrementButtons[idx].onClick.AddListener(() => ChangeDigit(idx, +1));
            decrementButtons[idx].onClick.AddListener(() => ChangeDigit(idx, -1));
        }

        if (finalObject != null) finalObject.SetActive(false);
    }

    private void ChangeDigit(int index, int delta)
    {
        digits[index] = (digits[index] + delta + 10) % 10;
        UpdateText(index);
        CheckCode();
    }

    private void UpdateText(int index)
    {
        digitTexts[index].text = digits[index].ToString();
    }

    private void CheckCode()
    {
        string code =
            digits[0].ToString() +
            digits[1].ToString() +
            digits[2].ToString() +
            digits[3].ToString();

        if (code == targetCode)
        {
            if (panel != null) panel.SetActive(false);
            if (finalObject != null) finalObject.SetActive(true);
        }
    }
}
