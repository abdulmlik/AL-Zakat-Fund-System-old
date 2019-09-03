using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL_Zakat_Fund_System.Models
{
    class Office : BindableBase
    {
        #region private Member

        private int _office_no;
        private string _nameOffice;
        private int _branch_no;
        private string _nameBranch;

        #endregion

        #region public properties

        public int office_no
        {
            get { return _office_no; }
            set { SetProperty(ref _office_no, value); }
        }
        public string nameOffice
        {
            get { return _nameOffice; }
            set { SetProperty(ref _nameOffice, value); }
        }
        public int branch_no
        {
            get { return _branch_no; }
            set { SetProperty(ref _branch_no, value); }
        }
        public string nameBranch
        {
            get { return _nameBranch; }
            set { SetProperty(ref _nameBranch, value); }
        }

        #endregion

        #region Construct

        #region Construct without parameter
        public Office()
        { }
        #endregion

        #region Construct all parameter
        /// <summary>
        /// Construct all parameter
        /// </summary>
        /// <param name="office_no_"></param>
        /// <param name="nameOffice_"></param>
        /// <param name="branch_no_"></param>
        /// <param name="nameBranch_"></param>
        public Office(int office_no_, string nameOffice_, int branch_no_, string nameBranch_)
        {
            office_no = office_no_;
            nameOffice = nameOffice_;
            branch_no = branch_no_;
            nameBranch = nameBranch_;
        }
        #endregion

        #endregion
    }
}
