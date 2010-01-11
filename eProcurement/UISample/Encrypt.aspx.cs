using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


using eProcurement_BLL;
using eProcurement_BLL.UserManagement;
using eProcurement_DAL;
public partial class UISample_Encrypt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void btnEncrypt_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPlain.Text.Trim() == "")
                return;

            txtCipher.Text = Encryption.Encrypt(txtPlain.Text.Trim()); 

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnDecrypt_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCipher.Text.Trim() == "")
                return;

            txtPlain.Text = Encryption.Decrypt(txtCipher.Text.Trim()); 

        }
        catch (Exception ex)
        {

        }
    }
}
