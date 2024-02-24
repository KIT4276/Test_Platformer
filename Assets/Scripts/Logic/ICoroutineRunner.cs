using System.Collections;
using UnityEngine;

namespace Platformer.Logic
{
    public  interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}