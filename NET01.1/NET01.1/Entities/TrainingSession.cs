using System;
using NET01._1.FormatEnums;

namespace NET01._1.Entities
{
    public class TrainingSession : Entity, ICloneable, IVersionable
    {
        private TrainingMaterial[] _trainingMaterials = new TrainingMaterial[0];
        private byte[] _version = new byte[IVersionable.VersionLength];

        public TrainingSession(string description, params byte[] paramsVersion)
            : base(description)
        {
            if (paramsVersion == null || paramsVersion.Length != IVersionable.VersionLength)
            {
                throw new NullReferenceException($"Version can't be empty or length should be  = {IVersionable.VersionLength}");
            }
               
            Array.Copy(_version, paramsVersion, IVersionable.VersionLength);
        }

        public object Clone()
        {
            var copy = (TrainingSession) MemberwiseClone();
            Array.Copy(_trainingMaterials, copy._trainingMaterials, _trainingMaterials.Length);
            return copy;
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

        public void AddMaterial(TrainingMaterial trainingMaterial)
        {
            if (trainingMaterial == null)
            {
                return;
            }

            Array.Resize(ref _trainingMaterials, _trainingMaterials.Length + 1);
            _trainingMaterials[^1] = trainingMaterial;
        }

        public LessonType GetTrainingMaterial()
        {
            if (_trainingMaterials.Length == 0)
            {
                return LessonType.None;
            }

            foreach (var material in _trainingMaterials)
            {
                if (material is VideoMaterial)
                {
                    return LessonType.VideoLesson;
                }
            }

            return LessonType.TextLesson;
        }

        public override string ToString()
        {
            return $"Training Session description - {Description}";
        }
    }
}