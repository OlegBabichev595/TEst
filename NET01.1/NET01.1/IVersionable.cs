namespace NET01._1
{
    public interface IVersionable
    {
        const byte VersionLength = 8;
        public byte[] GetVersion();
        public void SetVersion(byte[] version);
    }
}