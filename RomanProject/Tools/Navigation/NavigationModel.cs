namespace RomanProject.Tools.Navigation
{
    internal enum ViewType
    {
        UserEditor,
        Main
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
