using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuotaSystem.Utility
{
    public class Utility
    {
        public static void limpiarControles(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    limpiarControles(control.Controls);
            }
        }

        public static void checkButtonDoubleClick(Button button, Page page)
        {
            System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
            sbValid.Append("if (typeof(Page_ClientValidate) == 'function') { ");
            sbValid.Append("if (Page_ClientValidate() == false) { return false; }} ");
            sbValid.Append("this.value = 'Procesando...';");
            sbValid.Append("this.disabled = true;");
            sbValid.Append(page.ClientScript.GetPostBackEventReference(button, ""));
            sbValid.Append(";");
            button.Attributes.Add("onclick", sbValid.ToString());
        }
    }
}