using System.Windows;
using System.Windows.Controls;

namespace JsonEditor
{
    public class TsDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            //var value = item as TsField<object>;

            if (element == null || item == null)
                return null;

            if (item is TsField<string>)
            {
                return element.FindResource("StringFieldTemplate") as DataTemplate;
            }
            else if(item is TsField<TsArray<object>>)
            {
                return element.FindResource("ArrayTemplate") as DataTemplate;
            }
            else if (item is TsField<TsObject>)
            {
                return element.FindResource("ObjectTemplate") as DataTemplate;
            }
            else
            {
                return null;
            }
        }
    }
}