using CIS.Core;
using CIS.Model;
using System;

namespace App_OP
{
    public partial class FormSaveFavorite : BaseForm
    {
        public FormSaveFavorite()
        {
            InitializeComponent();
        }

        public string RecodeID { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TP_Favorite favorite = new TP_Favorite();
            favorite.ID = Guid.NewGuid().ToString();
            favorite.UserID = SysContext.CurrUser.user.Code;
            favorite.DeptCode = SysContext.RunSysInfo.currDept.Code;
            favorite.UpdateTime = DateTime.Now;
            favorite.XMLLink = RecodeID;
            favorite.NickName = this.textBoxX1.Text;
            DBHelper.CIS.Insert<TP_Favorite>(favorite);
            AlertBox.Info("保存到我的收藏夹成功");
            this.Close();
        }
    }
}
