using System.Windows.Controls;

namespace JsonEditor.JsonTreeViewItem
{
    public class JtviString : JtviBase
    {
        public JtviString()
        {
            var stckpnl = new StackPanel();
            stckpnl.Orientation = Orientation.Horizontal;
            FieldName = new TextBlock();
            FieldValue = new TextBox();

            stckpnl.Children.Add(FieldName);
            stckpnl.Children.Add(FieldValue);

            this.Header = stckpnl;
        }

        public TextBlock FieldName { get; set; }
        public TextBox FieldValue { get; set; }
    }
}