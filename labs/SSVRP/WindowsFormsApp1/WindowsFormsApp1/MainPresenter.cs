using System;
using System.Collections.Generic;
using System.Linq;
using Configuration;
using Model;

namespace WindowsFormsApp1
{
    public class MainPresenter
    {
        private IUnitOfWork _iUnitOfWork;
        private IMainView _iMainView;

        public MainPresenter(IUnitOfWork iUnitOfWork, IMainView iMainView)
        {
            _iUnitOfWork = iUnitOfWork;
            _iMainView = iMainView;
        }






        public void GetAllGroup()
        {
            _iMainView.ListGroupView = _iUnitOfWork.GroupRepository.GetAll().Select(x=>x.ToString()).ToList();
        }



    }
}