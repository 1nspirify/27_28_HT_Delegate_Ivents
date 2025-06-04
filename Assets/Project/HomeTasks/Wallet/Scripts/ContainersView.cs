using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContainersView : MonoBehaviour
{
    [SerializeField] private List<Container> _containers;
    [SerializeField] private List<StorageUIView> _uiElements;

    private Dictionary<StorageType, TMP_Text> _uiMap;

    private void Awake()
    {
        _uiMap = new Dictionary<StorageType, TMP_Text>();

        foreach (StorageUIView ui in _uiElements)
        {
            _uiMap[ui.Type] = ui.Text;
        }
    }
    
    private void OnEnable()
    {
        foreach (Container container in _containers)
        {
            container.OnCountChanged += () => Visualize(container);
        }
    }

    private void OnDisable()
    {
        foreach (Container container in _containers)
            container.OnCountChanged -= () => Visualize(container);
    }
    
    private void Visualize(Container container)
    {
        if (_uiMap.TryGetValue(container.Type, out TMP_Text text))
        {
            text.text = container.Count.ToString();
        }
    }
}