using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stopky_C_
{
    internal class StopwatchManager
    {
        private Stopwatch stopwatch = new Stopwatch();
        private Dictionary<string, TimeSpan> savedTimes = new Dictionary<string, TimeSpan>();

        public void Start()
        {
            if (!stopwatch.IsRunning)
                stopwatch.Start();
        }

        public void Pause()
        {
            if (stopwatch.IsRunning)
                stopwatch.Stop();
        }

        public void Stop()
        {
            if (stopwatch.IsRunning)
                stopwatch.Stop();
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        public TimeSpan GetElapsedTime()
        {
            return stopwatch.Elapsed;
        }

        public void SaveTime(string name)
        {
            savedTimes[name] = stopwatch.Elapsed;
            File.WriteAllText("times.json", JsonSerializer.Serialize(savedTimes));
        }

        public Dictionary<string, TimeSpan> LoadTimes()
        {
            if (File.Exists("times.json"))
            {
                string json = File.ReadAllText("times.json");
                savedTimes = JsonSerializer.Deserialize<Dictionary<string, TimeSpan>>(json);
            }
            return savedTimes;
        }
    }
}

