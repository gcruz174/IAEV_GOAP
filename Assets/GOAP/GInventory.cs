using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GOAP
{
    public class GInventory
    {
        public List<GameObject> Items { get; } = new();

        public void AddItem(GameObject item)
        {
            Items.Add(item);
        }

        public GameObject FindItemWithTag(string tag)
        {
            return Items.FirstOrDefault(i => i != null && i.CompareTag(tag));
        }
        
        public void RemoveItem(GameObject item)
        {
            var indexToRemove = -1;
            foreach (var g in Items)
            {
                indexToRemove++;
                if (g == item)
                    break;
            }
            
            if (indexToRemove > -1)
                Items.RemoveAt(indexToRemove);
        }
    }
}