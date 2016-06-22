using Singularity.Models;

namespace Singularity.Annotations
    {
    public interface IEmailable : IModel
        {
        string[] GetEmails();
        string[] GetEmails(string Field);
        }
    }
