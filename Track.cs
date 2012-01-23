using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Mix;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass.Misc;
using FileHelpers;

namespace OpenStation
{
    public class Track
    {

        public Track(string filename)
        {
            Filename = filename;
            Tags = BassTags.BASS_TAG_GetFromFile(Filename);
            if (Tags == null)
                throw new ArgumentException("File not valid or not found!");

            // we already create a stream handle
            // might not be the best place here (especially when having a larger playlist), but for the demo this is okay ;)
            CreateStream();
        }

        public Track(OpenStationDS.ScheduleRow Item) : this(Item.ItemFilename)
        {
            ScheduleID = Item.ID;
        }

        public override string ToString()
        {
            return String.Format("{0} [{1}]", Tags, Utils.FixTimespan(Tags.duration, "HHMMSS"));
        }

        // member
        public string Filename = String.Empty;
        public TAG_INFO Tags = null;
        public int Channel = 0;
        public long TrackLength = 0L;
        public SYNCPROC TrackSync;
        public int NextTrackSync = 0;
        public long NextTrackPos = 0L;
        public long StartTrackPos = 0L;
        public int ScheduleID = -1;
        public WaveForm Waveform;

        private bool CreateStream()
        {
            Channel = Bass.BASS_StreamCreateFile(Filename, 0L, 0L, BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_PRESCAN);
            if (Channel != 0)
            {
                TrackLength = Bass.BASS_ChannelGetLength(Channel);
                return true;
            }
            return false;
        }





    }
}
