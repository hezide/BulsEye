using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Project1
{
    public class Game
    {
        public const ushort k_numOfLetters = 4;
        private List<string> m_guessList;
        private List<sScorePerGuess> m_scoreList;
        private int m_currentGuess;
        private int m_numOfAllowedGuesses;
        private List<int> m_computerGuess;

        public Game()
        {
            m_guessList = new List<string>();
            m_scoreList = new List<sScorePerGuess>();
            m_computerGuess = new List<int>();
        }

        public void Init()
        {
            m_currentGuess = 0;
            m_numOfAllowedGuesses = 0;
            m_guessList.Clear();
            m_scoreList.Clear();
            CreateComputerGuess();
        }

        public int NumOfAllowedGuesses
        {
            get { return m_numOfAllowedGuesses; }
            set { m_numOfAllowedGuesses = value; }
        }

        public List<string> GuessList
        {
            get { return m_guessList; }
        }

        public List<sScorePerGuess> ScoreList
        {
            get { return m_scoreList; }
        }

        public List<int> ComputerGuess
        {
            get { return m_computerGuess; }
        }

        public sScorePerGuess AnalyzeScore(List<int> i_intColorsOfTheButton)
        {
            ushort o_numOfV = 0;
            ushort o_numOfX = 0;
            for (int i = 0; i < k_numOfLetters; i++)
            {
                ///exact match
                if (i_intColorsOfTheButton[i] == m_computerGuess[i])
                {
                    o_numOfV++;
                }
                else if (m_computerGuess.Contains(i_intColorsOfTheButton[i]))
                {
                    o_numOfX++;
                }
            }

            sScorePerGuess newScore = new sScorePerGuess(o_numOfV, o_numOfX);

            return newScore;
        }

        public bool CheckIfGameIsFinished()
        {
            bool o_isTheGameFinished = false;
            ///if he guessed all the letters
            ///else he used all the possible guesses
            if (m_scoreList[m_scoreList.Count() - 1].m_bul == k_numOfLetters)
            {
                System.Console.WriteLine("You guessed after {0} steps!", m_currentGuess);
                o_isTheGameFinished = true;
            }
            else if (m_currentGuess == m_numOfAllowedGuesses)
            {
                System.Console.WriteLine("No more guesses allowed. You lost.");
                o_isTheGameFinished = true;
            }

            return o_isTheGameFinished;
        }

        public void AddGuessToGuessList(string i_guess)
        {
            m_guessList.Add(i_guess);
            m_currentGuess++;
        }

        private void CreateComputerGuess()
        {
            Random randomGuessCreator = new Random();
            Array guessesArray = Enum.GetValues(typeof(UI.ePossibleColors));
            int i_currRndGuess = 0;
            bool i_isGoodGuess = false;

            for (int i = 0; i < k_numOfLetters; i++)
            {
                while (i_isGoodGuess == false)
                {
                    i_currRndGuess = randomGuessCreator.Next(0, guessesArray.Length);
                    i_isGoodGuess = CheckIfCharIsAlreadyPicked(i_currRndGuess);
                }

                i_isGoodGuess = false;
                m_computerGuess.Add(i_currRndGuess);
            }
        }

        private bool CheckIfCharIsAlreadyPicked(int i_currRndGuess)
        {
            bool o_res = true;
            foreach (int guess in m_computerGuess)
            {
                ///check if the int already exist  in the guess
                if (i_currRndGuess == guess)
                {
                    o_res = false;
                    break;
                }
            }

            return o_res;
        }
    }
}
