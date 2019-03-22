using MainView = RomanProject.View.UsersListControl;
using EditUserView = RomanProject.View.PersonInfoInputControl;
using System;

namespace RomanProject.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainView());
                    break;
                case ViewType.UserEditor:
                    ViewsDictionary.Add(viewType, new EditUserView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
