using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullUtilVK.Enums.SafetyEnums.VK
{
    public class AudioGenre
    {
        private static List<AudioGenre> Registered = new List<AudioGenre>();
        private static AudioGenre Register(string Name, int Id)
        {
            if (Registered.Where(c => c.Id == Id).Count() > 0)
                throw new ArgumentException("This id is already defined: " + Id, "Id");
            Registered.Add(new AudioGenre(Name, Id));
            return new AudioGenre(Name, Id);
        }
        public static AudioGenre GetById(int id)
        {
            if (Registered.Where(c => c.Id == id).Count() < 1)
                throw new ArgumentException("id " + " is undefined", "id");
            return Registered.First(c => c.Id == id);
        }
        public static AudioGenre GetByName(string name)
        {
            if (Registered.Where(c => c.Name == name).Count() < 1)
                throw new ArgumentException("name " + " is undefined", "name");
            return Registered.First(c => c.Name == name);
        }
        public static List<AudioGenre> GetRegistered()
        {
            return Registered;
        }
        public static AudioGenre FromVkNet(VkNet.Enums.AudioGenre? Genre)
        {
            if (Genre == null)
                return Other;
            switch ((VkNet.Enums.AudioGenre)Genre)
            {
                case VkNet.Enums.AudioGenre.AcousticAndVocal:
                    return AcousticVocal;
                case VkNet.Enums.AudioGenre.Alternative:
                    return Alternative;
                case VkNet.Enums.AudioGenre.Chanson:
                    return Chanson;
                case VkNet.Enums.AudioGenre.Classical:
                    return Classical;
                case VkNet.Enums.AudioGenre.DanceAndHouse:
                    return DanceHouse;
                case VkNet.Enums.AudioGenre.DrumAndBass:
                    return DrumnBass;
                case VkNet.Enums.AudioGenre.Dubstep:
                    return Dubstep;
                case VkNet.Enums.AudioGenre.EasyListening:
                    return EasyListening;
                case VkNet.Enums.AudioGenre.ElectropopAndDisco:
                    return ElectropopDisco;
                case VkNet.Enums.AudioGenre.Ethnic:
                    return Ethnic;
                case VkNet.Enums.AudioGenre.IndiePop:
                    return IndiePop;
                case VkNet.Enums.AudioGenre.Instrumental:
                    return Instrumental;
                case VkNet.Enums.AudioGenre.JazzAndBlues:
                    return JazzBlues;
                case VkNet.Enums.AudioGenre.Metal:
                    return Metal;
                case VkNet.Enums.AudioGenre.Other:
                    return Other;
                case VkNet.Enums.AudioGenre.Pop:
                    return Pop;
                case VkNet.Enums.AudioGenre.RapAndHipHop:
                    return RapHipHop;
                case VkNet.Enums.AudioGenre.Reggae:
                    return Reggae;
                case VkNet.Enums.AudioGenre.Rock:
                    return Rock;
                case VkNet.Enums.AudioGenre.Speech:
                    return Speech;
                case VkNet.Enums.AudioGenre.Trance:
                    return Trance;
                default:
                    return Other;
            }
        }

        private AudioGenre(string Name, int Id)
        {
            this.Name = Name;
            this.Id = Id;
        }

        public string Name;
        public int Id;

        public override int GetHashCode()
        {
            return Id;
        }
        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object obj)
        {
            if (obj != null && obj is AudioGenre)
                return (obj as AudioGenre).Id == this.Id;
            else
                return false;
        }

        public static AudioGenre Rock = Register("Rock", 1);
        public static AudioGenre Pop = Register("Pop", 2);
        public static AudioGenre RapHipHop = Register("Rap & Hip-Hop", 3);
        public static AudioGenre EasyListening = Register("Easy Listening", 4);
        public static AudioGenre DanceHouse = Register("Dance & House", 5);
        public static AudioGenre Instrumental = Register("Instrumental", 6);
        public static AudioGenre Metal = Register("Metal", 7);
        public static AudioGenre Alternative = Register("Alternative", 21);
        public static AudioGenre Dubstep = Register("Dubstep", 8);
        public static AudioGenre JazzBlues = Register("Jazz & Blues", 1001);
        public static AudioGenre DrumnBass = Register("Drum & Bass", 10);
        public static AudioGenre Trance = Register("Trance", 11);
        public static AudioGenre Chanson = Register("Chanson", 12);
        public static AudioGenre Ethnic = Register("Ethnic", 13);
        public static AudioGenre AcousticVocal = Register("Acoustic & Vocal", 14);
        public static AudioGenre Reggae = Register("Reggae", 15);
        public static AudioGenre Classical = Register("Classical", 16);
        public static AudioGenre IndiePop = Register("Indie Pop", 17);
        public static AudioGenre Speech = Register("Speech", 19);
        public static AudioGenre ElectropopDisco = Register("Electropop & Disco", 22);
        public static AudioGenre Other = Register("Other", 18);
    }
}
