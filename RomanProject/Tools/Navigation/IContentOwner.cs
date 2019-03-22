using System.Windows.Controls;

namespace RomanProject.Tools.Navigation
{
    internal interface IContentOwner
    {
        ContentControl ContentControl { get; }
    }
}
