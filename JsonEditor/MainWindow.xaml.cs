using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TsObject parent = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader reader = new StreamReader(@"C:\Users\Raghu-Dinesh\Projects\SAMPLE\TestStepsManager\JsonEditor\JsonEditor\Sample.json");
                string json = reader.ReadToEnd();
                JObject obj = JObject.Parse(json);

                parent = JsonObject2Tree(obj);
                tvw_display.DataContext = parent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private TsObject JsonObject2Tree(JObject obj)
        {
            var container = new TsObject();

            foreach (var token in obj)
            {
                container.Add(JsonField2Tree(token));
            }

            return container;
        }

        private TsArray<object> JsonArray2Tree(JArray arr)
        {
            var tstSteps = new TsArray<object>();
            int ix = -1;
            foreach (var itm in arr)
            {
                ix++;
                string arrayItemName = "[" + ix + "]";
                var arrayItem = new KeyValuePair<string, JToken>(arrayItemName, itm);
                tstSteps.Add(JsonField2Tree(arrayItem));
            }

            return tstSteps;
        }

        private object JsonField2Tree(KeyValuePair<string, JToken> token)
        {
            object field = null;

            switch (token.Value.Type)
            {
                case JTokenType.Boolean:
                    field = new TsField<bool>
                    {
                        Name = token.Key,
                        Value = Convert.ToBoolean(token.Value)
                    };
                    break;
                case JTokenType.String:
                    field = new TsField<string>
                    {
                        Name = token.Key,
                        Value = Convert.ToString(token.Value)
                    };
                    break;
                case JTokenType.Null:
                    field = new TsField<string>
                    {
                        Name = token.Key,
                        Value = null
                    };
                    break;
                case JTokenType.Array:
                    field = new TsField<TsArray<object>>
                    {
                        Name = token.Key,
                        Value = JsonArray2Tree((JArray)token.Value)
                    };
                    break;
                case JTokenType.Object:
                    field = new TsField<TsObject>
                    {
                        Name = token.Key,
                        Value = JsonObject2Tree((JObject)token.Value)
                    };
                    break;
            }

            return field;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var jsonTc = JsonConvert.SerializeObject(parent);
        }
    }
}
