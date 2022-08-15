using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorRuneGenerator : MonoBehaviour
{
    public GameObject conveyorRune;
    public float waitTime;
    private Rune _selectedRune = null;

    public PlayerRuneSelection playerRuneSelectionScript;
    public GameController gameControllerScript;

    public TempoController tempoController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("CRune") == null)
        {
            StartCoroutine(StartConveyor());
        }
    }

    IEnumerator StartConveyor()
    {
        GameObject conveyorRuneClone = Instantiate(conveyorRune, conveyorRune.transform.position, conveyorRune.transform.rotation);
        conveyorRuneClone.transform.parent = gameObject.transform;
        tempoController.BellToll();
        yield return new WaitForSeconds(waitTime);
    }

    public Rune GetSelectedRune()
    {
        return _selectedRune;
    }

    public void ClearSelectedRune()
    {
        _selectedRune = null;
    }

    private void SelectionRune(Rune rune)
    {
        _selectedRune = rune;
        playerRuneSelectionScript.conveyorRune = _selectedRune.Id;
        gameControllerScript.RuneMatch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CRune"))
        {
            Rune rune = other.GetComponent<SpriteRendererImageRandomizerBinding>().GetRune();
            SelectionRune(rune);
        }
    }
}
