using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<Rock> rocks;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private GameObject victoryPanel;
        
        private void OnEnable()
        {
            Frog.clicked += OnFrogClicked;
        }

        private void OnDisable()
        {
            Frog.clicked -= OnFrogClicked;
            
        }

        private void OnFrogClicked(Frog obj)
        {
            var frogIndex = 0;
            for (int i = 0; i < rocks.Count; i++)
            {
                if (rocks[i].Frog == obj)
                {
                    frogIndex = i;
                    break;
                }
            }

            if (obj.Type ==FrogType.Green)
            {
                if (frogIndex < 6)
                {
                    if (rocks[frogIndex+1].Frog==null)
                    {
                        rocks[frogIndex + 1].Frog = obj;
                        obj.transform.position = rocks[frogIndex + 1].transform.position+Vector3.up;
                        rocks[frogIndex].Frog = null;
                    }
                    else if (rocks[frogIndex+2].Frog == null)
                    {
                        rocks[frogIndex + 2].Frog = obj;
                            obj.transform.position = rocks[frogIndex + 2].transform.position+Vector3.up;
                            rocks[frogIndex].Frog = null;
                    }
                }
            }
            else
            {
                if (frogIndex > 0)
                {
                    if (rocks[frogIndex-1].Frog==null)
                    {
                        rocks[frogIndex - 1].Frog = obj;
                        obj.transform.position = rocks[frogIndex - 1].transform.position+Vector3.up;
                        rocks[frogIndex].Frog = null;
                    }
                    else if (rocks[frogIndex-2].Frog == null)
                    {
                        rocks[frogIndex - 2].Frog = obj;
                        obj.transform.position = rocks[frogIndex - 2].transform.position+Vector3.up;
                        rocks[frogIndex].Frog = null;
                        
                    }
                }
                
            }

            var result = CheckVictory();
            if (result)
            {
                _gameObject.SetActive(false);
                victoryPanel.SetActive(true);
            }

        }

        private bool CheckVictory()
        {
            for (int i = 0; i < 3; i++)
            {
                if (rocks[i].Frog==null)
                {
                    return false;
                }
                
                if (rocks[i].Frog.Type!=FrogType.Red)
                {
                    return false;
                }   
            }
            for (int i = rocks.Count-1; i > rocks.Count-4; i--)
            {
                if (rocks[i].Frog==null)
                {
                    return false;
                }
                
                if (rocks[i].Frog.Type!=FrogType.Green)
                {
                    return false;
                }   
            }

            return true;
        }
        
        public void Replay()
        {
            SceneManager.LoadScene(0);
        }


        public void Exit()
        {
            Application.Quit();
        }
    }
}