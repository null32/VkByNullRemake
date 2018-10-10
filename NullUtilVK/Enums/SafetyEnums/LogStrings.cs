using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NullUtilVK.Enums.SafetyEnums
{
    public class LogStrings
    {
        private const string NewLine = "\r\n";
        public struct Error
        {
            public struct General
            {
                public const string UnknownCommand = "Unknown command: ";
                public const string IndefOutOfBounds = "Index is out of bounds";
                public const string InvalidArgument = "Invalid argument: ";
                public const string InvalidUsage = "Invalid command usage";
                public const string UnknownCategory = "Unknown category: ";
                public const string AuthRequired = "Authorization required";
                public const string Downloading = "Failed to download file: ";
            }
            public struct Audio
            {
                public struct Player
                {
                    public const string EmptyPlaylist = "Audio Player: Playlist is empty";

                    public const string InvalidFile = "Audio Player: Invalid audio file: ";
                }
                public const string Delete = "Audio: Can't delete audio, that not belongs to you";
                public const string ListUndefined = "Audio: Can't use audio from undefined audiolist";
                public const string DownloadFileExists = "Audio Downlaoder: File already exists: ";
            }
            public struct Auth
            {
                public const string InvalidPassword = "Authorize: Invalid login or password";
                public const string InvalidAccKey = "Authorize: Invalid acccess key";

                public const string InstExists = "Auth Manger: Authorization instance with this name already exists: ";
                public const string InstNotExists = "Auth Manger: Authorization instance with this name does not exists: ";
            }
            public struct DB
            {
                public const string InvalidIndex = "DB: Item with id {0} doesn't exists";
            }
        }
        
        public struct Info
        {
            public struct General
            {
                //public static string SetConfigValue = "Set config value: ";
                //public static string GetConfigValue = "Config's value: ";
                public const string GetConfigValue = "Requested value of {0}" + NewLine
                                             + "Returned {1}";
                public const string SetConfigValue = "Client set the value of {0} to {1}";
            }
            public struct Auth
            {
                public const string NormSuccess = "Authorize: Authorize with email/phone and password succesed";
                public const string AltSucess = "Authorize: Authorize with access key probably succesed";
                public const string LogOut = "Authorize: Don't authorized anymore";

                public const string InstAdded = "Auth Manager: Successfuly added new instance: ";
                public const string InstDeleted = "Auth Manager: Successfuly deleted instance: ";
                public const string InstUpdated = "Auth Manager: Successfuly updated instance: ";
            }
            public struct Audio
            {
                public struct Player
                {
                    public const string PlaylistAdd = "Audio Player: Song added to playlist: ";
                    public const string PlaylistAddRange = "Audio Player: Songs added to playlist: ";
                    public const string PlaylistDell = "Audio PLayer: Song removed from playlist: ";
                    public const string PlaylistDellRange = "Audio PLayer: Songs removed from playlist: ";

                    public const string CacheFileNotExists = "Audio Player: File not found and will be downloaded: ";
                    public const string CacheFileExists = "Audio Player: File exists and will be played: ";
                    public const string PrecacheStarted = "Audio Player: Started downloading song: ";
                    public const string PrecacheDone = "Audio Player: Downloaded song: ";

                    public const string RetryPrecache = "Audio Player: Retrying download (Attempt {0})";
                    public const string FailStreak = "Audio Player: Got {0} errors in a row, maybe something wrong with song?";
                    public const string PlaylistOutdated = "Audio Player: Seems like playlist got outdated, reloading";
                    public const string PlaylistReloaded = "Audio Player: Reloaded playlist";
                    public const string RemovedInvalidSong = "Audio Player: Seems like just that song was broken, removing it from playlist";
                }

                public const string CountRequest = "Audio: Requseted count of user {0} audios";
                public const string CountResponse = "Audio: Returned {0}";

                public const string GetUserRequest = "Audio: Requested user audios (User ID = {0}, album ID = {1}, count = {2}, offset = {3})";
                public const string GetGroupRequst = "Audio: Requested group audios (Group ID = {0}, album ID = {1}, count = {2}, offset = {3})";

                public const string SearchRequest = "Audio: Requested search result of \"{0}\" (Is artist = {1}, count = {2}, offset = {3})";
                public const string RecommendRequest = "Audio: Requested user recommended audios (User ID = {0}, count = {1}, offset = {2})";
                public const string PopularRequest = "Audio: Requsted popular audios (count = {0}, offset = {1})";

                public const string LyricsRequest = "Audio: Requested lyrics (ID = {0})";

                public const string GetAlbumsRequest = "Audio: Requested albums of user (ID = {0})";
                public const string GetAlbumsResponse = "Audio: Got albums: ";
                public const string InfoRequest = "Audio: Requested info about audio(s): ";
                public const string InfoResponse = "Audio: Got info about audio(s): ";

                public const string ToStatusEnabled = "Audio: Broadcasting to status enabled";
                public const string ToStatusDisabled = "Audio: Broadcasing to status disabled";

                public const string Added = "Audio: Song has been added to your audios: ";
                public const string Deleted = "Audio: Song has beed deleted from your audios: ";
                public const string StartedDownloading = "Audio: Started downloading of song: ";

                public const string CacheCleanStarted = "Audio: Started cache cleaning...";
                public const string CacheCleanFinished = "Audio: Finished cache cleaning";
            }
            public struct User
            {
                public const string Get = "User: Got info about user (User id {0}, name {1})";
            }
            public struct Group
            {
                public const string Get = "Group: Got info about group (Group id {0}, title {1})";
            }
            public struct DB
            {
                public const string Created = "DB: Created/Updated database";
                public const string Command = "DB: Send command to database: ";
            }
        }

        public struct Help
        {
            public struct Audio
            {
                public struct Player
                {
                    public const string General = "Use \"listadd\" to form playilst, than \"play\"";

                    public const string Play = "Plays song from playlist, starting from START_INDEX";
                    public const string Next = "Plays next song from playlist";
                    public const string Prev = "Plays previous song from playlist";
                    public const string Pause = "Pauses player";
                    public const string Resume = "Resumes player";
                    public const string Stop = "Stops player";
                    public const string ListAdd = "Adds item or items listed by \',\' to playlist" + NewLine
                                                + "Use \"all\" to add full last audiolist";
                    public const string ListDel = "Removes item or items listed by \',\' from playlist" + NewLine
                                                + "Use \"all\" to clear playlist";
                    public const string Volume = "Set player volume to VOLUME";
                    public const string ShowPl = "Shows content of current playlist";
                    public const string ShufflePl = "Randomly mixes current playlist";
                }
                public const string General = "You can use audios from precached list by LIST_INDEX" + NewLine
                                                + "<AUDIO_ITEM> = <AUDIO_OWNER_ID> <AUDIO_ID>";
                public const string Count = "Returns USER_ID audios count";
                public const string Get = "Returns COUNT audios of USER_ID, skipping OFFSET audios";
                public const string Search = "Returns list of audios, which suits QUERRY";
                public const string Info = "Returns full information about item";
                public const string Albums = "Returns list of USER_ID albums";
                public const string Add = "Adds item to your audios";
                public const string Delete = "Deletes audio from your audios";
                public const string Download = "Downloads item to your disk";
            }
            public const string General = "Use \"help -full\" to get all help about all commands" + NewLine
                                                                                               + "Use \"login\" or \"loginalt\" to get started" + NewLine
                                                                                               + "Use \"list\" to get all avaible commands" + NewLine
                                                                                               + "Symbol \"?\" means, that argument has default value" + NewLine
                                                                                               + "Use \"_\" to pass default argument value" + NewLine
                                                                                               + "You can get help about command by parsing argument \"help\"";
            public const string Version = "Displays current NullUtilVK version";
            public const string OfHelp = "Displays help about COMMAND";
            public const string Login = "Logins to http://vk.com/";
            public const string Logout = "Logouts user from http://vk.com/";
            public const string List = "Prints all avaible commands and categories in CATEGORY";
            public const string Config = "Gets or Sets config CONFIG_VALUE of CONFIG_KEY";
        }
    }
}
