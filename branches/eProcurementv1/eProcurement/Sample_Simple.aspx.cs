using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel; 
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using eProcurement_DAL;
using eProcurement_BLL;

public partial class Sample_Simple : System.Web.UI.Page
{
    class UserVO
    {

        //USER_ID
        private string _UserId;
        public string Id
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        //USER_NAME
        private string _UserName;
        public string Name
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Collection<UserVO> vos = new Collection<UserVO>();

        for (int i = 0; i < 10; i++)
        {
            UserVO vo = new UserVO();
            vo.Id = i.ToString();
            vo.Name = "name " + i.ToString();
            vos.Add(vo);
        }

        gvUserDetails.DataSource = vos;
        gvUserDetails.DataBind();

        
    }
}
