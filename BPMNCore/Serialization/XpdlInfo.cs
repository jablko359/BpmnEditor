using System;

namespace BPMNCore.Serialization
{
    public static class XpdlInfo
    {
        public const string Version = "2.2";
        public const string Format = "xpdl";
        public const string FormatInfo = "XML Process Definition Language";
        public const string MainPoolName = "Main Process";


        public static string GetFileFilter()
        {
            return string.Format("{0} | *.{1}", FormatInfo, Format);
        }

        public static string GetUtcDateTime(DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
        }
    }
}