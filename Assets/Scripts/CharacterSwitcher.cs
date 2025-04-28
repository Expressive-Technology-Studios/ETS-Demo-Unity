using System.Collections;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _modelTransition;

    [SerializeField]
    GameObject[] _characters;

    void OnEnable()
    {
        StartCoroutine(Switch());
    }

    IEnumerator Switch()
    {
        int index = 0;

        while (true)
        {
            _modelTransition.Play();
            yield return new WaitForSeconds(1f);
            _characters[index].SetActive(false);
            index = ++index % _characters.Length;
            _characters[index].SetActive(true);
            yield return new WaitForSeconds(3f);
        }
    }

    IEnumerator SwitchOld()
    {
        while (true)
        {
            for (int i = 0; i < _characters.Length; i++)
            {
                _modelTransition.Play();
                yield return new WaitForSeconds(1f);
                _characters[i].SetActive(true);
                yield return new WaitForSeconds(3f);
                _characters[i].SetActive(false);
            }
        }
    }
}
