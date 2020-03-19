using CatchMeIfYouCanImproved.Canvases;
using CatchMeIfYouCanImproved.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace CatchMeIfYouCanImproved
{
    public class PartyPlayer
    {
        Queue<Party> StepsList { get; set; }


        public PartyPlayer()
        {
            StepsList = new Queue<Party>();
        }


        
        public Queue<Party> Deserialize(string fileName)
        {
            Queue<Party> step = null;

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream reader = new FileStream(fileName, FileMode.Open))
            {
                step = (Queue<Party>)formatter.Deserialize(reader);
            }
            
            return step;
        }

        public void Serialize(Player CurrentPlayer, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, StepsList);
            }
        }

        public void Add(Party party)
        {
            StepsList.Enqueue(party);
        }

        public void Clear()
        {
            StepsList.Clear();
        }
    }
}
