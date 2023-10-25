using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class orderRope : MonoBehaviour
{
    //LayoutRebuilder.MarkLayoutForRebuild((RectTransform) transform);
    //LayoutGroup[] parentLayoutGroups = gameObject.GetComponentsInParent<LayoutGroup>();
    //foreach (LayoutGroup group in parentLayoutGroups) {
    //LayoutRebuilder.MarkLayoutForRebuild((RectTransform) group.transform);
    void Start()
    {
        InvokeRepeating("UpdateLayout", 1.0f, 0.1f);
    }

    private void UpdateLayout()
    {
        // Mark the current RectTransform (usually attached to a UI element) for layout rebuild.
        LayoutRebuilder.MarkLayoutForRebuild((RectTransform)transform);

        // Get all LayoutGroup components in the parent hierarchy.
        LayoutGroup[] parentLayoutGroups = GetComponentsInParent<LayoutGroup>();

        // Iterate through the parentLayoutGroups and mark their RectTransforms for layout rebuild.
        foreach (LayoutGroup group in parentLayoutGroups)
        {
            if (group != null)
            {
                LayoutRebuilder.MarkLayoutForRebuild((RectTransform)group.transform);
            }
        }
    }

}
