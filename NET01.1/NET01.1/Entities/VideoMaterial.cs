using System;
using NET01._1.FormatEnums;

namespace NET01._1.Entities
{
    public class VideoMaterial : TrainingMaterial, IVersionable
    {
        private string _pictureSaver;
        private byte[] _version = new byte[IVersionable.VersionLength];
        private VideoFormat _videoFormat;

        public VideoMaterial(string description, VideoFormat videoFormat, string pictureSaver,
            params byte[] paramsVersion)
            : base(description)
        {
            VideoFormat = videoFormat;
            PictureSaver = pictureSaver;
            if (paramsVersion == null || paramsVersion.Length != IVersionable.VersionLength)
            {
                throw new NullReferenceException($"Version can't be empty or length should be = {IVersionable.VersionLength}");
            }

            Array.Copy(_version, paramsVersion, IVersionable.VersionLength);
        }

        public VideoFormat VideoFormat
        {
            get => _videoFormat;

            set
            {
                CheckEnumValue(value, nameof(value));
                _videoFormat = value;
            }
        }

        public string PictureSaver
        {
            get => _pictureSaver;

            set
            {
                CheckForNullString(value);
                _pictureSaver = value;
            }
        }

        public byte[] GetVersion()
        {
            return _version == null ? _version = new byte[IVersionable.VersionLength] : _version;
        }


        public void SetVersion(byte[] version)
        {
            if (version.Length > IVersionable.VersionLength)
            {
                throw new NullReferenceException($"Version length should be = {IVersionable.VersionLength}");
            }

            Array.Copy(_version, version, IVersionable.VersionLength);
        }


        private void CheckEnumValue<TEnum>(TEnum value, string paramName) where TEnum : Enum
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }
    }
}