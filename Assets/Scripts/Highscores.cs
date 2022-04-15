using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Highscore
    {
        public int score;
        public DateTime time;

        public Highscore (int score)
        {
            this.score = score;
            this.time = DateTime.Now;
        }
    }

    public static class Highscores
    {
        
        private static List<Highscore> _highscores;
        private const string path = "highscores.json";

        static Highscores()
        {
            if (!File.Exists(path))
            {
                _highscores = new List<Highscore>();
                return;
            }
            
            var content = File.ReadAllText(path);
            _highscores = JsonConvert.DeserializeObject<List<Highscore>>(content);
        }
        
        public static void SaveHighscore()
        {
            var hud = GameObject.Find("/HUD");
            if (!hud) return;

            var score = new Highscore(hud.GetComponent<ScoreModel>().GetScore());

            var highscore = _highscores.Count == 0 ? new Highscore(-1) : _highscores[0];
            if (score.score <= highscore.score) return;

            _highscores.Insert(0, score);

            var content = JsonConvert.SerializeObject(_highscores);
            File.WriteAllText(path, content);
        }

        public static IEnumerable<Highscore> Get()
        {
            return _highscores;
        }
    }
}