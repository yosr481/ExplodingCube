using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    private float duration = GameVar.CardFlipDuration;

    [SerializeField]
    private int _targetFacing = 0; // 0 == from DOWN to UP
                                   // 1 == from UP to DOWN

    public int TargetFacing
    {
        private get { return _targetFacing; }
        set
        {
            if (value == 0 || value == 1)
                _targetFacing = value;
            else
            {
                Debug.LogWarning("WARNING: Card _targetFacing must be 1 or 0, defaulting to 0.");
                _targetFacing = 0;
            }
        }
    }

    // add disabled and enable manually
    void Awake()
    {
        enabled = false;
    }

    // Update is called once per frame
    void OnEnable()
    {
        StartCoroutine(TurnOverAnimation());
    }

    private IEnumerator TurnOverAnimation()
    {

        float targetYRotation = TargetFacing == 0 ? 180f : 0f;
        float eulerY = transform.localEulerAngles.y;
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float timeStep = (timer / duration);
            eulerY = Mathf.Lerp(eulerY, targetYRotation, timeStep);

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, eulerY, transform.localEulerAngles.z);

            yield return 0;
        }

        yield return 0;
        enabled = false;
    }
}
