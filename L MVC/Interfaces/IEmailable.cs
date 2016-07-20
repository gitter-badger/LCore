using LMVC.Models;

namespace LMVC.Annotations
    {
    public interface IEmailable : IModel
        {
        string[] GetEmails();
        string[] GetEmails(string Field);
        }
    }
