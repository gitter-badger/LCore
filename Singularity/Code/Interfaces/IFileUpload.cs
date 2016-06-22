namespace Singularity.Annotations
    {
    public interface IFileUpload
        {
        bool AllowDeactivate { get; set; }
        bool AllowMultipleUploads { get; set; }

        int SizeMinimum { get; set; }
        int SizeMaximum { get; set; }

        string[] AllowFileTypes { get; set; }
        }
    }
