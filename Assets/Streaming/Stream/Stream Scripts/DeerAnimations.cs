using UnityEngine;

public class DeerAnimations : MonoBehaviour
{
    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            anim.SetInteger("Emotion",1);

        if (Input.GetKeyDown(KeyCode.D))
            anim.SetInteger("Emotion", 2);
    }
}
