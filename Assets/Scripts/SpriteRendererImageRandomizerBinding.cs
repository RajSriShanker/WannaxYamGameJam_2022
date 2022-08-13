using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteRendererImageRandomizerBinding : MonoBehaviour
{
    [SerializeField] private Rune[] RunesList;

    private Rune _rune;
    private SpriteRenderer _spriteRenderer;

    private static readonly Queue<int> RuneSpawnQueue = new();
    
    public Rune GetRune()
    {
        return _rune;
    }
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Randomize Rune
        _rune = GetNextRuneToSpawn(RunesList);

        _spriteRenderer.sprite = _rune.Sprite;
    }

    private static Rune GetNextRuneToSpawn(Rune[] runesMasterList)
    {
        // Initialize spawn queue with runes 1-6 in a random order
        if (RuneSpawnQueue.Count == 0)
        {
            var runesList = runesMasterList.ToList();
            while (runesList.Count > 0)
            {
                int index = Random.Range(0, runesList.Count);
                RuneSpawnQueue.Enqueue(runesList.ElementAt(index).Id);
                runesList.RemoveAt(index);
            }
        }

        return runesMasterList[RuneSpawnQueue.Dequeue() - 1];
    }
}
