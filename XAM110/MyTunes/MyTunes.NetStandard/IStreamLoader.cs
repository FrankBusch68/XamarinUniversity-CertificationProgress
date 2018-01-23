namespace MyTunes
{
    public interface IStreamLoader
    {
        System.IO.Stream GetStreamForFilename(string filename);
    }
}