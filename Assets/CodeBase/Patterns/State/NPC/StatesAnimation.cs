using UnityEngine;

namespace CodeBase.Patterns.State.NPC
{
    public static class StatesAnimation
    {
        public static int Idle = Animator.StringToHash("Idle");
        public static int Agressive = Animator.StringToHash("Agressive");
        public static int Talking = Animator.StringToHash("Talking");

    }
}