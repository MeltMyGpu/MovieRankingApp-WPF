using Moq;
using MovieRankingApplication.Model.Generated;
using MovieRankingApplication.ViewModels.PageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRankingApplication.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {

        [TestMethod]
        public void ChangeToEditView_ReturnDelegateThatChangesCurrentPageUri_ChangeCurrentPageUriToEditView()
        {
            var MainWinVM = new MainWindowViewModel("Test1");

            var ChangeToEditDelegate = MainWinVM.ChangeToEditView;
            ChangeToEditDelegate.Execute(new object());

            Assert.IsTrue(MainWinVM.EditMode);
            Assert.AreEqual("PlaceHolderStringForEditView", MainWinVM.CurrentPageUri);
        }

        [TestMethod]
        public void ChangeToAddView_ReturnDelegateThatChangesCurrentPageUri_ChangeCurrentPageUriToAddView()
        {
            var MainWinVM = new MainWindowViewModel("Test1");

            var ChangeToAddDelegate = MainWinVM.ChangeToAddView;
            ChangeToAddDelegate.Execute(new object());

            Assert.IsFalse(MainWinVM.EditMode);
            Assert.AreEqual("PlaceHolderStringForAddView", MainWinVM.CurrentPageUri);
        }

        [TestMethod]
        public void ChangeToListView_ReturnDelegateThatChangesCurrentPageUri_ChangeCurrentPageUriToListView()
        {
            var MainWinVM = new MainWindowViewModel("Test1");

            var ChangeToListDelegate = MainWinVM.ChangetoListView;
            ChangeToListDelegate.Execute(new object());


            Assert.AreEqual("PlaceHolderStringForListView", MainWinVM.CurrentPageUri);
            
            
            
        }

    }
}


            //MainWinVM.PropertyChanged += (s, e) =>
            //{
            //    DidFire = true;
            //    propName = e.PropertyName ?? "Failed";
            //};
            //Assert.IsTrue(DidFire);
            //Assert.AreEqual("ChangeToListView", propName);